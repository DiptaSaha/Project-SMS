using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Code { get; set; }
       

        [NotMapped]
        public List<Category> Categories { get; set; }

    }
}
