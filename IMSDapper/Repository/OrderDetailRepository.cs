using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IMSDapper.Model;
using IMSDapper.Repository.Interface;

namespace IMSDapper.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetailModel>, IOrderDetailRepository
    {

        public async Task<int> AddAsync(OrderDetailModel orderDetail)
        {
            string query = @"INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice)
                        VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
            return await _connection.ExecuteScalarAsync<int>(query, orderDetail);
        }

    }
}
