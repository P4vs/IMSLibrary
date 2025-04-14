using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class OrderDetailService
    {
        public async Task<T?> GetByIdAsync<T>(int id)
        {
            OrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
            return await _orderDetailRepository.GetByIdAsync<T>(id, "OrderDetailID");
        }

        public IEnumerable<OrderDetailModel> GetAllOrderDetails()
        {
            OrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
            return _orderDetailRepository.GetAll();
        }

        public async Task<int> AddAsync(OrderDetailModel orderDetail)
        {
            OrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
            return await _orderDetailRepository.AddAsync(orderDetail);
        }


        public bool UpdateOrderDetail(OrderDetailModel orderDetail)
        {
            OrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
            return _orderDetailRepository.Update(orderDetail);
        }

        public bool DeleteOrderDetail(OrderDetailModel orderDetail)
        {
            OrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
            return _orderDetailRepository.Delete(orderDetail);
        }
    }
}
