using SmallBussinessMS.Models;
using SmallBussinessMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();
        public bool Save(Supplier supplier)
        {
            
            bool isSaved = _supplierRepository.Save(supplier);

            return isSaved;
        }
        public bool Update(Supplier supplier)
        {
            bool isUpdate = _supplierRepository.Update(supplier);
            return isUpdate;
        }
        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }
    }
}
