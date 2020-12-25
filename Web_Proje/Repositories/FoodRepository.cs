using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Models;

namespace Web_Proje.Repositories
{
    public class FoodRepository
    {
        Context c = new Context();

        public List<Food> FoodListele()
        {
            return c.Foods.ToList();
        }

        public void FoodEkle(Food f)
        {
            c.Foods.Add(f);
            c.SaveChanges();
        }

        public void FoodSil(Food f)
        {
            c.Foods.Remove(f);
            c.SaveChanges();
        }

        public void FoodFuncelle(Food f)
        {
            c.Foods.Update(f);
            c.SaveChanges();
        }

        public void FoodBul(int id)
        {
            c.Foods.Find(id);
            c.SaveChanges();
        }
    }
}
