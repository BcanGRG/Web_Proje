using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class KullaniciGirisModel
    {
        [Required(ErrorMessage="Kullanıcı Adı Boş Olamaz")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifre Boş Olamaz")]
        public string Sifre { get; set; }
        public bool BeniHatirla { get; set; }
    }
}
