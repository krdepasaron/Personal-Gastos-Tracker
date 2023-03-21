using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTLibrary.Models
{
    public class listgastos
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string GastosName { get; set; }
        public int Price { get; set; }
        public string GastosType { get; set; }
        public string Remarks { get; set; }
        public DateTime dateAdded { get; set; }
        public string Code { get; set; }
        public string Brand { get; set; }
    }
}
