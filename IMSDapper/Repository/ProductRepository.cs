using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IMSDapper.Model;
using IMSDapper.Repository.Interface;
using Microsoft.Data.SqlClient;

namespace IMSDapper.Repository
{
    public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
    {
        public ProductRepository() : base() // Calls the base constructor to initialize the connection
        {
        }
        public async Task<IEnumerable<ProductModel>> GetProductsWithDetailsAsync()
        { 
            
            var query = @"
    SELECT 
        p.ProductID, p.Name, p.Description, p.Price, p.CategoryID, p.SupplierID, p.DefaultWarehouseID, p.CreatedAt,
        c.CategoryID, c.Name AS CategoryName, c.Description AS CategoryDescription,
        s.SupplierID, s.Name AS SupplierName, s.ContactName, s.Phone, s.Email, s.Address,
        w.WarehouseID,w.Name AS WarehouseName, w.Location, w.Manager, w.Phone
    FROM Products p
    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
    INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
    INNER JOIN Warehouses w ON p.DefaultWarehouseID = w.WarehouseID
    ";

            var products = await _connection.QueryAsync<ProductModel, CategoryModel, SupplierModel, WarehouseModel, ProductModel>(
                query,
                (product, category, supplier, warehouse) =>
                {
                    product.Category = category;
                    product.Supplier = supplier;
                    product.Warehouses = warehouse;
                    return product;
                },
                splitOn: "CategoryID,SupplierID,WarehouseID"
            );

            return products;
        }



    }
}
