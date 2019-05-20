using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBussinessMS.Models
{
    public class SupplierFile
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
