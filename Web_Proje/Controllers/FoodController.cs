using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Proje.Repositories;

namespace Web_Proje.Controllers
{
    public class FoodController : Controller
    {
        public IActionResult Index()
        {
            FoodRepository foodRepo = new FoodRepository();

            return View(foodRepo.Listele());
        }
    }
}
