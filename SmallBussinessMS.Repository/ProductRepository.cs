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
    public class ProductRepository
    {
        private SBMSDbContext db = new SBMSDbContext();

        public bool Create(Product product)
        {

            bool isSaved = false;

            db.Products.Add(product);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                isSaved = true;
            }

            return isSaved;
        }
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }
        public bool Update(Product product)
        {

            bool isUpdated = false;
            db.Entry(product).State = EntityState.Modified;

            int updated = db.SaveChanges();
            if (updated > 0)
            {
                isUpdated = true;
            }

            return isUpdated;
        }
        public bool Delete(Product product)
        {
            db.Products.Remove(product);
            int deleted = db.SaveChanges();
            if (deleted > 0)
            {
                return true;
            }
            return false;
        }
        public Product GetProductById(int id)
        {
            Product product = db.Products.FirstOrDefault(c => c.Id == id);


            return product;
        }
    }
}
