using SmallBussinessMS.Models;
using SmallBussinessMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Save(Customer customer)
        {
            //bool isExist = _supplierRepository.IsExist(customer.Code);
            //if (isExist)
            //{
            //    throw new Exception("Sorry!! This Code No Already Exist !!");
            //}

            bool isSaved = _customerRepository.Save(customer);

            return isSaved;
        }
        public bool Update(Customer customer)
        {
            bool isUpdate = _customerRepository.Update(customer);
            return isUpdate;
        }
        

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
    }
}
