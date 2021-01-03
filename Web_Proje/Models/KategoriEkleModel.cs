using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class KategoriEkleModel
    {
        [Required(ErrorMessage ="Ad Alanı boş bırakılamaz")]
        public string Ad { get; set; }
    }
}
