using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDapper.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T?> GetByIdAsync<T>(int id, string primaryKey);

        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

    }
}
