using SmallBussinessMS.DatabaseContext;
using SmallBussinessMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.Repository
{
    public class SupplierRepository
    {
        SBMSDbContext db = new SBMSDbContext();
        public bool Save(Supplier supplier)
        {
            bool isSaved = false;
            db.Suppliers.Add(supplier);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                isSaved = true;
            }
            return isSaved;
        }
        public bool Update(Supplier supplier)
        {

            bool isUpdated = false;

            db.Entry(supplier).State = EntityState.Modified;

            int updated = db.SaveChanges();
            if (updated > 0)
            {
                isUpdated = true;
            }

            return isUpdated;
        }
        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }
    }
}
