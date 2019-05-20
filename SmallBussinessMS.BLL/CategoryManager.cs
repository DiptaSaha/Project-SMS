using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmallBussinessMS.Models;
using SmallBussinessMS.Repository;

namespace SmallBussinessMS.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Create(Category category)
        {
            return _categoryRepository.Create(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public bool Delete(Category category)
        {
            bool isDeleted = _categoryRepository.Delete(category);
            return isDeleted;
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public bool Update(Category category)
        {
            bool isUpdated = _categoryRepository.Update(category);
            return isUpdated;
        }
    }
}