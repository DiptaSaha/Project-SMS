using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SmallBussinessMS.DatabaseContext;
using SmallBussinessMS.Models;

namespace SmallBussinessMS.Repository
{
    public class CategoryRepository
    {
        private SBMSDbContext db = new SBMSDbContext();

        public bool Create(Category category)
        {
            bool isSaved = false;

            db.Categories.Add(category);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                isSaved = true;
            }

            return isSaved;
        }


        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public bool Delete(Category category)
        {
            db.Categories.Remove(category);
            int deleted = db.SaveChanges();
            if (deleted>0)
            {
                return true;
            }
            return false;
        }

        public Category GetCategoryById(int id)
        {
            Category category = db.Categories.FirstOrDefault(c => c.Id==id);
            

            return category;
        }

        public bool Update(Category category)
        {

            bool isUpdated = false;
            db.Entry(category).State = EntityState.Modified;

            int updated = db.SaveChanges();
            if (updated > 0)
            {
                isUpdated = true;
            }

            return isUpdated;
        }

    }
}