using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_Proje.Entities;
using Web_Proje.Interfaces;
using Web_Proje.Models;

namespace Web_Proje.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrunRepository _urunRepository;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(IUrunRepository urunRepository , SignInManager<AppUser> signInManager)
        {
            _urunRepository = urunRepository;
            _signInManager = signInManager;
        }
        public IActionResult Index(int? kategoriId)
        {
            ViewBag.KategoriId = kategoriId;
            return View();
        }

        public IActionResult UrunDetay(int id)
        {
            return View(_urunRepository.BulId(id));
        }

        public IActionResult GirisYap()
        {
            return View(new KullaniciGirisModel());
        }
        
        [HttpPost]
        public IActionResult GirisYap(KullaniciGirisModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = _signInManager.PasswordSignInAsync(model.KullaniciAdi, model.Sifre, model.BeniHatirla, false).Result;
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("", "kullanıcı adınız veya şifreniz hatalı");
            }

                return View(new KullaniciGirisModel());
        }
    }
}
