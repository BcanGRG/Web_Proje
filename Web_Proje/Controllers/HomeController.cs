using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Proje.Interfaces;

namespace Web_Proje.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrunRepository _urunRepository;
        public HomeController(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public IActionResult Index()
        {

            return View(_urunRepository.Listele());
        }

        public IActionResult UrunDetay(int id)
        {
            return View(_urunRepository.BulId(id));
        }
    }
}
