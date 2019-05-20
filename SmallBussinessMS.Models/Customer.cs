using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmallBussinessMS.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(11)]
        public string Contact { get; set; }
        public int LoyalityPoint { get; set; }
 

        public virtual List<CustomerFile> CustomerFiles { get; set; }


        [NotMapped]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }
}
