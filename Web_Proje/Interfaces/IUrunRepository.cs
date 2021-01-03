using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Entities;

namespace Web_Proje.Interfaces
{
    public interface IUrunRepository : IGenericRepository<Urun>
    {
        List<Kategori> KategoriGetir(int urunId);
        void EkleKategori(UrunKategori urunKategori);
        void SilKategori(UrunKategori urunKategori);

        List<Urun> GetirKategoriIdile(int kategoriId);


    }
}
