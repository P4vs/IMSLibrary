using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class CategoryService
    {

        public async Task<T?> GetByIdAsync<T>(int id)
        {
            CategoryRepository _categoryRepository = new CategoryRepository();
            return await _categoryRepository.GetByIdAsync<T>(id, "CategoryID");
        }

        public IEnumerable<CategoryModel> GetAllCategory()
        {
            CategoryRepository _categoryRepository = new CategoryRepository();
            return _categoryRepository.GetAll();
        }

        public bool AddCategory(CategoryModel category)
        {
            CategoryRepository _categoryRepository = new CategoryRepository();
            return _categoryRepository.Add(category);
        }


        public bool UpdateCategory(CategoryModel category)
        {
            CategoryRepository _categoryRepository = new CategoryRepository();
            return _categoryRepository.Update(category);
        }

        public bool DeleteCategory(CategoryModel category)
        {
            CategoryRepository _categoryRepository = new CategoryRepository();
            return _categoryRepository.Delete(category);
        }
    }
}
