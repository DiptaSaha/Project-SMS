using SmallBussinessMS.Models;
using SmallBussinessMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.BLL
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();

        public bool Create(Product product)
        {
            return _productRepository.Create(product);
        }
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public bool Update(Product product)
        {
            bool isUpdated = _productRepository.Update(product);
            return isUpdated;
        }
        public bool Delete(Product product)
        {
            bool isDeleted = _productRepository.Delete(product);
            return isDeleted;
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
