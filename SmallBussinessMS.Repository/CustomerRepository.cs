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
    public class CustomerRepository
    {
        SBMSDbContext db = new SBMSDbContext();
        public bool Save(Customer customer)
        {
            bool isSaved = false;
            db.Customers.Add(customer);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                isSaved = true;
            }
            return isSaved;
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }
        public bool Update(Customer customer)
        {

            bool isUpdated = false;

            db.Entry(customer).State = EntityState.Modified;

            int updated = db.SaveChanges();
            if (updated > 0)
            {
                isUpdated = true;
            }

            return isUpdated;
        }
        //public bool Delete(Customer customer)
        //{
        //    bool isDeleted = false;

        //    db.Customers.Remove(customer);

        //    int deleted = db.SaveChanges();
        //    if (deleted > 0)
        //    {
        //        isDeleted = true;
        //    }

        //    return isDeleted;
        //}
    }
}
