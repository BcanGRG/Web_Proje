using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Interfaces;

namespace Web_Proje.TagHelpers
{
    [HtmlTargetElement("KategoriAdGetir")]
    // Kendi Tag Helperım ile Ürünlerin kategorilerinin getirilmesini sağlama
    public class KategoriAd : TagHelper
    {
        private readonly IUrunRepository _urunRepository;
        public KategoriAd(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public int UrunId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
           var gelenKategoriler = _urunRepository.KategoriGetir(UrunId).Select(I => I.Ad);
            foreach (var item in gelenKategoriler)
            {
                data += item;
            }
            output.Content.SetContent(data);
            // Ayrıca namespace i de viewimport a eklemek gerekir
        }
    }
}
