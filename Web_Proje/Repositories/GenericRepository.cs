using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Models;

namespace Web_Proje.Repositories
{
    public class GenericRepository<T> where T:class , new()
    {
        Context c = new Context();

        public List<T> Listele()
        {
            return c.Set<T>().ToList();
        }

        public void Ekle(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }

        public void Sil(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }

        public void Guncelle(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }

        public void Bul(int id)
        {
            c.Set<T>().Find(id);
        }
    }
}
