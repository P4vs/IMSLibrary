using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class StockService
    {
        public async Task<T?> GetByIdAsync<T>(int id)
        {
            StockRepository _stockRepository = new StockRepository();
            return await _stockRepository.GetByIdAsync<T>(id, "StockID");
        }

        public IEnumerable<StockModel> GetAllStocks()
        {
            StockRepository _stockRepository = new StockRepository();
            return _stockRepository.GetAll();
        }

        public bool AddStock(StockModel stock)
        {
            StockRepository _stockRepository = new StockRepository();
            return _stockRepository.Add(stock);
        }


        public bool UpdateStock(StockModel stock)
        {
            StockRepository _stockRepository = new StockRepository();
            return _stockRepository.Update(stock);
        }

        public bool DeleteStock(StockModel stock)
        {
            StockRepository _stockRepository = new StockRepository();
            return _stockRepository.Delete(stock);
        }
    }
}
