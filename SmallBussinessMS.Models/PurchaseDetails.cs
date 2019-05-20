using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.Models
{
    public class PurchaseDetails
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal NewCostPrice { get; set; }
        public decimal NewMRP { get; set; }

        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
    }
}
