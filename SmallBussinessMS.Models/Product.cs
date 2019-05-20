using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmallBussinessMS.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        

        public string ReoderLevel { get; set; }
        public string Description { get; set; }

        public virtual List<ProductFile> ProductFiles { get; set; }


        [NotMapped]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }
}
