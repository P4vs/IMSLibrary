using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class WarehouseService
    {

        public async Task<T?> GetByIdAsync<T>(int id)
        {
            WarehouseRepository _warehouserRepository = new WarehouseRepository();
            return await _warehouserRepository.GetByIdAsync<T>(id, "WarehouseID");
        }
        public IEnumerable<WarehouseModel> GetAllWarehouse()
        {
            WarehouseRepository _warehouseRepository = new WarehouseRepository();
            return _warehouseRepository.GetAll();
        }

        public bool AddWarehouse(WarehouseModel warehouse)
        {
            WarehouseRepository _warehouseRepository = new WarehouseRepository();
            return _warehouseRepository.Add(warehouse);
        }


        public bool UpdateWarehouse(WarehouseModel warehouse)
        {
            WarehouseRepository _warehouseRepository = new WarehouseRepository();
            return _warehouseRepository.Update(warehouse);
        }


        public bool DeleteWarehouse(WarehouseModel warehouse)
        {
            WarehouseRepository _warehouseRepository = new WarehouseRepository();
            return _warehouseRepository.Delete(warehouse);
        }
    }
}
