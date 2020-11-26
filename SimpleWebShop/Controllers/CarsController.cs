using Microsoft.AspNetCore.Mvc;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory allCategories)
        {
            _allCars = allCars;
            _allCategories = allCategories;
        }

        public ViewResult CarsView()
        {
            ViewBag.Title = "Страница с тачками";

            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = _allCars.GetAllCars;
            obj.currentCategory = "Автомобили";

            var cars = _allCars.GetAllCars;
            return View(obj);
        }
    }
}
