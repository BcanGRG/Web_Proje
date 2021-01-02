using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Entities
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Resim { get; set; }
        public decimal Fiyat { get; set; }
    }
}
