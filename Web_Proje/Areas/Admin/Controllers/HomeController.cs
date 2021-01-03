using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Proje.Entities;
using Web_Proje.Interfaces;
using Web_Proje.Models;

namespace Web_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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

        public IActionResult Ekle()
        {
            return View(new UrunEkleModel());
        }
        [HttpPost]
        public IActionResult Ekle(UrunEkleModel model)
        {
            if (ModelState.IsValid)
            {
                Urun urun = new Urun();
                if (model.Resim != null)
                {
                    var uzanti = Path.GetExtension(model.Resim.FileName);
                    var yeniResimAdi = Guid.NewGuid() + uzanti;
                    var yuklenecekyer = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/"+yeniResimAdi);
                    var stream = new FileStream(yuklenecekyer,FileMode.Create);
                    model.Resim.CopyTo(stream);

                    urun.Resim = yeniResimAdi;
                }

                urun.Ad = model.Ad;
                urun.Fiyat = model.Fiyat;

                _urunRepository.Ekle(urun);
                return RedirectToAction("Index", "Home",new { area = "Admin"});
            }
            return View(new UrunEkleModel());
        }

        public IActionResult Guncelle(int id)
        {
            var gelenUrun = _urunRepository.BulId(id);
            UrunGuncelleModel model = new UrunGuncelleModel
            {
                Ad = gelenUrun.Ad,
                Fiyat = gelenUrun.Fiyat,
                Id = gelenUrun.Id

            };
            return View(model);

        }

        [HttpPost]
        public IActionResult Guncelle(UrunGuncelleModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekUrun = _urunRepository.BulId(model.Id);
                if (model.Resim != null)
                {
                    var uzanti = Path.GetExtension(model.Resim.FileName);
                    var yeniResimAdi = Guid.NewGuid() + uzanti;
                    var yuklenecekyer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + yeniResimAdi);
                    var stream = new FileStream(yuklenecekyer, FileMode.Create);
                    model.Resim.CopyTo(stream);

                    guncellenecekUrun.Resim = yeniResimAdi;
                }

                guncellenecekUrun.Ad = model.Ad;
                guncellenecekUrun.Fiyat = model.Fiyat;

                _urunRepository.Guncelle(guncellenecekUrun);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(model);
        }

        public IActionResult Sil(int id)
        {
            _urunRepository.Sil(new Urun { Id = id });
            return RedirectToAction("Index");
        }
    }
}
