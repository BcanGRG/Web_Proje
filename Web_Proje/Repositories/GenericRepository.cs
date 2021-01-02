using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Contexts;

namespace Web_Proje.Repositories
{
    public class GenericRepository<Tablo> where Tablo : class, new()
    { // Bu tablo bir class olmalı ve newlenebilmeli

        public void Ekle(Tablo tablo)
        {
            // İlgili nesne ile iş bittiği anda dispose etmesini sağlıyor using ramden kurtarıyor
            using var context = new Context0();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public void Sil(Tablo tablo)
        {
            // İlgili nesne ile iş bittiği anda dispose etmesini sağlıyor using ramden kurtarıyor
            using var context = new Context0();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }

        public void Guncelle(Tablo tablo)
        {
            // İlgili nesne ile iş bittiği anda dispose etmesini sağlıyor using ramden kurtarıyor
            using var context = new Context0();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }

        public List<Tablo> Listele()
        {
            // İlgili nesne ile iş bittiği anda dispose etmesini sağlıyor using ramden kurtarıyor
            using var context = new Context0();
            // Id ye göre son eklenenden vaşlayarak listeler
            return context.Set<Tablo>().ToList();
        }

        public Tablo BulId(int id)
        {
            // İlgili nesne ile iş bittiği anda dispose etmesini sağlıyor using ramden kurtarıyor
            using var context = new Context0();
            return context.Set<Tablo>().Find(id);
        }
    }
}
