using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class ProductService
    {
        ProductRepository _productRepository;



        // Get all categories
        public IEnumerable<ProductModel> GetAllProducts()
        {
            ProductRepository _productRepository = new ProductRepository();
            return _productRepository.GetAll();
        }

        public async Task<T?> GetByIdAsync<T>(int id)
        {
            ProductRepository _productRepository = new ProductRepository();
            return await _productRepository.GetByIdAsync<T>(id, "ProductID"); 
        }

        public bool AddProduct(ProductModel product)
        {
            _productRepository = new ProductRepository();
            return _productRepository.Add(product);
        }


        public bool UpdateProduct(ProductModel product)
        {
            _productRepository = new ProductRepository();
            return _productRepository.Update(product);
        }

        public bool DeleteProduct(ProductModel product)
        {
            _productRepository = new ProductRepository();
            return _productRepository.Delete(product);
        }

        public async Task<IEnumerable<ProductModel>> GetProductsWithDetailsAsync()
        {
            ProductRepository _productRepository = new ProductRepository();
            return await _productRepository.GetProductsWithDetailsAsync();
        }

    }
}
