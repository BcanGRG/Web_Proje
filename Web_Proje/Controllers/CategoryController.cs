using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Proje.Repositories;

namespace Web_Proje.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            CategoryRepository ctgRepo = new CategoryRepository();
            return View(ctgRepo.Listele());
        }
    }
}
