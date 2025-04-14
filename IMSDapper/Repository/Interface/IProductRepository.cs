using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;

namespace IMSDapper.Repository.Interface
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        Task<IEnumerable<ProductModel>> GetProductsWithDetailsAsync();
    }
}
