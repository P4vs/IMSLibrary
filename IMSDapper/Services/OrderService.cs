using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class OrderService
    {
        public async Task<T?> GetByIdAsync<T>(int id)  
        {
            OrderRepository _orderRepository = new OrderRepository();
            return await _orderRepository.GetByIdAsync<T>(id, "OrderID");
        }

        public IEnumerable<OrderModel> GetAllOrders()
        {
            OrderRepository _orderRepository = new OrderRepository();
            return _orderRepository.GetAll();
        }

        public bool AddOrder(OrderModel orders)
        {
            OrderRepository _orderRepository = new OrderRepository();
            return _orderRepository.Add(orders);
        }


        public bool UpdateOrder(OrderModel orders)
        {
            OrderRepository _orderRepository = new OrderRepository();
            return _orderRepository.Update(orders);
        }

        public bool DeleteOrder(OrderModel orders)
        {
            OrderRepository _orderRepository = new OrderRepository();
            return _orderRepository.Delete(orders);
        }
    }
}
