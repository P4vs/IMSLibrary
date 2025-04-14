using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;
using IMSDapper.Repository;

namespace IMSDapper.Services
{
    public class SupplierService
    {

        public async Task<T?> GetByIdAsync<T>(int id)
        {
            SupplierRepository _supplierRepository = new SupplierRepository();
            return await _supplierRepository.GetByIdAsync<T>(id, "SupplierID");
        }
        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            SupplierRepository _supplierRepository = new SupplierRepository();
            return _supplierRepository.GetAll();
        }

        public bool AddSupplier(SupplierModel supplier)
        {
            SupplierRepository _supplierRepository = new SupplierRepository();
            return _supplierRepository.Add(supplier);
        }


        public bool UpdateSupplier(SupplierModel supplier)
        {
            SupplierRepository _supplierRepository = new SupplierRepository();
            return _supplierRepository.Update(supplier);
        }


        public bool DeleteSupplier(SupplierModel supplier)
        {
            SupplierRepository _supplierRepository = new SupplierRepository();
            return _supplierRepository.Delete(supplier);
        }
    }
}
