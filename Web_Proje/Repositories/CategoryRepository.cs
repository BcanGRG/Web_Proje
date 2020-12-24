using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Models;

namespace Web_Proje.Repositories
{
    public class CategoryRepository
    {
        Context c = new Context();

        public List<Category> CategoryListele()
        {
            return c.Categories.ToList();
        }

        public void CategoryEkle(Category ct)
        {
            c.Categories.Add(ct);
            c.SaveChanges();
        }

        public void CategorySil(Category ct)
        {
            c.Categories.Remove(ct);
            c.SaveChanges();
        }

        public void CategoryGuncelle(Category ct)
        {
            c.Categories.Update(ct);
            c.SaveChanges();
        }

        public void CategoryBul(int id)
        {
            c.Categories.Find(id);
        }
    }
}
