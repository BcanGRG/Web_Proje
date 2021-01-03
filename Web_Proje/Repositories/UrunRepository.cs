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
    public class UrunRepository : GenericRepository<Urun>, IUrunRepository
    {
        private readonly IUrunKategoriRepository _urunKategoriRepository;

        public UrunRepository(IUrunKategoriRepository urunKategoriRepository)
        {
            _urunKategoriRepository = urunKategoriRepository;
        }


        // İnner Join sorgusu kategorileri getirebilmek için
        public List<Kategori> KategoriGetir(int urunId)
        {
            using var context = new Context0();
            return context.Urunler.Join(context.UrunKategoriler, urun => urun.Id, urunKategori => urunKategori.UrunId, (u, uk) => new
            {
                urun = u,
                urunKategori = uk
            }).Join(context.Kategoriler, iki => iki.urunKategori.KategoriId, kategori => kategori.Id, (uk, k) => new
            {
                urun = uk.urun,
                Kategori = k,
                UrunKategori = uk.urunKategori
            }).Where(I => I.urun.Id == urunId).Select(I => new Kategori
            {
                Ad = I.Kategori.Ad,
                Id = I.Kategori.Id
            }).ToList();
        }
        public void EkleKategori(UrunKategori urunKategori)
        {
            var kontrolKayit = _urunKategoriRepository.GetirFiltreile(I => I.KategoriId
            == urunKategori.KategoriId && I.UrunId == urunKategori.UrunId);
            if (kontrolKayit == null)
            {
                _urunKategoriRepository.Ekle(urunKategori);
            }
        }

        public void SilKategori(UrunKategori urunKategori)
        {
            var kontrolKayit = _urunKategoriRepository.GetirFiltreile(I => I.KategoriId
          == urunKategori.KategoriId && I.UrunId == urunKategori.UrunId);
            if (kontrolKayit != null)
            {
                _urunKategoriRepository.Sil(kontrolKayit);
            }
        }

        public List<Urun> GetirKategoriIdile(int kategoriId)
        {
            using var context = new Context0();
            return context.Urunler.Join(context.UrunKategoriler, u => u.Id, uk => uk.UrunId, (urun, urunKategori) => new
            {
                Urun = urun,
                UrunKategori = urunKategori
            }).Where(I => I.UrunKategori.KategoriId == kategoriId).Select(I => new Urun
            {
                Ad = I.Urun.Ad,
                Id = I.Urun.Id,
                Fiyat = I.Urun.Fiyat,
                Resim = I.Urun.Resim
            }).ToList();
        }
    }
}
