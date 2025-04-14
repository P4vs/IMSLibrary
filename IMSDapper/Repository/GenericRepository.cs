using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Dapper;
using IMSDapper.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace IMSDapper.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbConnection _connection; // Change to protected
        private readonly string connectionString = "Server=LAPTOP-N2BOHR7P; Database=IMSDb; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True;";

        public GenericRepository()
        {
            _connection = new SqlConnection(connectionString);
        }



        public async Task<T?> GetByIdAsync<T>(int id, string primaryKey)
        {
            if (id <= 0)
                throw new ArgumentException("ID must be greater than zero.", nameof(id));

            var tableAttribute = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttribute?.Name ?? typeof(T).Name;

            if (string.IsNullOrWhiteSpace(tableName))
                throw new InvalidOperationException("Table name could not be determined.");

            string query = $"SELECT * FROM [{tableName}] WHERE [{primaryKey}] = @Id";

            try
            {
                return await _connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                throw new DataException("Error fetching data by ID.", ex);
            }
        }
    




        public bool Add(T entity)
        {
            string tableName = GetTableName();
            string columns = GetColumnNames(true);
            string values = GetColumnValues(true);
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";


            int affectedRows = 0;

            affectedRows = _connection.Execute(query, entity);
                
            return affectedRows == 1;
        }




        public bool Update(T entity)
        {
            string tableName = GetTableName();
            string keyColumn = GetKeyColumn();

            try
            {
                var properties = typeof(T).GetProperties()
                    .Where(p => p.GetCustomAttribute<KeyAttribute>() == null) // Exclude key column from SET
                    .ToList();

                if (!properties.Any())
                    throw new InvalidOperationException("No columns to update. Ensure the entity has properties other than the key.");

                var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
                var sql = $"UPDATE {tableName} SET {setClause} WHERE {keyColumn} = @{keyColumn}";

                var result = _connection.Execute(sql, entity);
                return result > 0;
            } 
            catch (Exception ex)
            { 
                Console.WriteLine($"Error updating entity: {ex.Message}");
                return false;
            }
        }


        public bool Delete(T entity)
        {
            string tableName = GetTableName();
            string keyColumn = GetKeyColumn();

            try
            {
                var sql = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyColumn}";
                var result = _connection.Execute(sql, entity);
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting entity: {ex.Message}");
                return false;
            }
        }





        //Get all Data
        public IEnumerable<T> GetAll()
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM {tableName}";
            return _connection.Query<T>(query);
        }



        // Function on getting Name
        public string GetTableName()
        {
            string tableName = "";
            var type = typeof(T);
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr != null)
            {
                tableName = tableAttr.Name;

            }

            return tableName;
        }

        //Function Column
        public string GetColumnNames(bool excludeKey = false)
        {
            string columnNames = "";
            var type = typeof(T);
            var columns = string.Join(", ", type.GetProperties()
                .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
                .Select(p =>
                {
                    var columnAttr = p.GetCustomAttribute<ColumnAttribute>();
                    return columnAttr != null ? columnAttr.Name : p.Name;

                }
                ));
            return columns;


        }


        public string GetColumnValues(bool excludeKey = false)
        {
            var columnValues = typeof(T).GetProperties()
            .Where(p => !excludeKey || p.GetCustomAttribute(typeof(KeyAttribute)) == null);
            var values = string.Join(", ", columnValues.Select(p =>
            {
                return $"@{p.Name}";
            }));

            return values;

        }

        public string GetKeyColumn()
        {
            var type = typeof(T);
            var keyProperty = type.GetProperties()
                                  .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);

            return keyProperty?.Name ?? throw new InvalidOperationException("No key column found.");
        }
    }
}
