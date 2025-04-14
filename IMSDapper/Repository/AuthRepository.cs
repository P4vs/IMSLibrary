using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IMSDapper.Helpers;
using IMSDapper.Model;
using IMSDapper.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace IMSDapper.Repository
{
    public class AuthRepository : GenericRepository<UserModel>, IAuthRepository
    {
        public AuthRepository() : base() // Calls the base constructor to initialize the connection
        {
        }


        // ✅ Get user by username
        public async Task<UserModel?> GetUserByUsername(string username)
        {

            string query = "SELECT * FROM Users WHERE Username = @Username";
            return await _connection.QueryFirstOrDefaultAsync<UserModel>(query, new { Username = username });
        }

        // ✅ Create a new user
        public async Task<int> CreateUser(UserModel user)
        {
            
            string query = @"
                INSERT INTO Users (Username, PasswordHash, Role, CreatedAt) 
                VALUES (@Username, @PasswordHash, @Role, @CreatedAt);
                SELECT CAST(SCOPE_IDENTITY() as int)"; // Returns the new UserID

            return await _connection.ExecuteScalarAsync<int>(query, user);
        }
    }
}
