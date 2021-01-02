using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Interfaces
{
    public interface IGenericRepository<Tablo> where Tablo: class , new()
    {
        public void Ekle(Tablo tablo);
        public void Sil(Tablo tablo);
        public void Guncelle(Tablo tablo);
        public List<Tablo> Listele();
        public Tablo BulId(int id);
    }
}
