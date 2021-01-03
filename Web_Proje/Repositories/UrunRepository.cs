using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Contexts;
using Web_Proje.Entities;
using Web_Proje.Interfaces;

namespace Web_Proje.Repositories
{
    //Urun repository ile method gövdelerini , IUrunrepo ilede method ları getiriyoruz . Bu yüzden ikisinden de kalıtım yapılıyor
    public class UrunRepository : GenericRepository<Urun> ,IUrunRepository
    {
        // İnner Join sorgusu kategorileri getirebilmek için
      public List<Kategori> KategoriGetir(int urunId)
        {
            using var context = new Context0();
            return context.Urunler.Join(context.UrunKategoriler, urun => urun.Id, urunKategori => urunKategori.UrunId, (u, uk) => new
            {
                urun = u,
                urunKategori = uk 
            }).Join(context.Kategoriler,iki => iki.urunKategori.KategoriId,kategori=>kategori.Id,(uk,k) => new 
            { 
                urun = uk.urun,
                Kategori = k,
                UrunKategori = uk.urunKategori
            }).Where(I=>I.urun.Id==urunId).Select(I => new Kategori { 
            Ad = I.Kategori.Ad,
            Id = I.Kategori.Id
            }).ToList();
        }
    }
}
