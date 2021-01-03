using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class UrunEkleModel
    {
        [Required(ErrorMessage ="Ad Alanı Gereklidir")]
        public string Ad { get; set; }

        
        [Range(1,double.MaxValue, ErrorMessage="Fiyat 0 dan fazla olmalıdır")]
        public decimal Fiyat { get; set; }
        public IFormFile Resim { get; set; }
    }
}
