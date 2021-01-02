using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Interfaces;

namespace Web_Proje.ViewComponents
{
    public class KategoriList : ViewComponent
    { // ViewComponent kendi kendine çalışan asenkronik bir yapı
        // Conrollerdan bağımsız bir yapı
        
        private readonly IKategoriRepository _kategoriRepository;
        public KategoriList(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        public IViewComponentResult Invoke()
        { // default olarak Shared da oluşturulan Components içinde ilgili Componente ait default cshtml i arar
            return View(_kategoriRepository.Listele());
        }
    }
}
