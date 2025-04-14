using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class CustomerService
    {
        public async Task<T?> GetByIdAsync<T>(int id)
        {
            CustomerRepository _costumerRepository = new CustomerRepository();
            return await _costumerRepository.GetByIdAsync<T>(id, "CustomerID");
        }

        public IEnumerable<CustomerModel> GetAllCostumer()
        {
            CustomerRepository _costumerRepository = new CustomerRepository();
            return _costumerRepository.GetAll();
        }

        public bool AddCategory(CustomerModel customer)
        {
            CustomerRepository _costumerRepository = new CustomerRepository();
            return _costumerRepository.Add(customer);
        }


        public bool UpdateCategory(CustomerModel customer)
        {
            CustomerRepository _costumerRepository = new CustomerRepository();
            return _costumerRepository.Update(customer);
        }

        public bool DeleteCategory(CustomerModel customer)
        {
            CustomerRepository _costumerRepository = new CustomerRepository();
            return _costumerRepository.Delete(customer);
        }
    }
}
