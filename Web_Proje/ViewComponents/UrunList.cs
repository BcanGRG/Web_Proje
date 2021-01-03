using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Interfaces;

namespace Web_Proje.ViewComponents
{
    public class UrunList :ViewComponent
    {
        private readonly IUrunRepository _urunRepository;
        public UrunList(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }

        public IViewComponentResult Invoke(int? kategoriId)
        {
            if (kategoriId.HasValue)
            {
                return View(_urunRepository.GetirKategoriIdile((int)kategoriId));
            }
            return View(_urunRepository.Listele());
        }
    }
}
