using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageURL { get; set; }
        public string ThumbNailImageURL { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }

        public virtual Category Category { get; set; }
        
        public int CategoryID { get; set; }


    }
}
