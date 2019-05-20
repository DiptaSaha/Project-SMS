using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.Models
{
    public class ProductFile
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
