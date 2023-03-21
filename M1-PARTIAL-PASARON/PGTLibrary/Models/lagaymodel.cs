using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTLibrary.Models
{
    public class lagaymodel
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string GastosName { get; set; }
        public int Price { get; set; }  
        public string GastosType { get; set; }
        public string Remarks { get; set; }
        public DateTime dateAdded { get; set; }
        public string Code { get; set; }
        public string Brand { get; set; }

        //input or add gastos for d day
    }
}
