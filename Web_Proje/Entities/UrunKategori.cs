using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Entities
{
    public class UrunKategori
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int KategoriId { get; set; }
        public Urun Urun { get; set; }
        public Kategori Kategori { get; set; }

    }
}
