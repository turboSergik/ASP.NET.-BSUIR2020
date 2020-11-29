using Microsoft.AspNetCore.Mvc;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
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

        [Route("Cars/CarsView")]
        [Route("Cars/CarsView/{category}")]
        public ViewResult CarsView(string category)
        {
            string _category = category;
            string curCategory = "";
            IEnumerable<Car> cars = null;

            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.GetAllCars;
                curCategory = "";
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.GetAllCars.Where(item => item.Category.name.Equals("Электромобили"));
                    curCategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.GetAllCars.Where(item => item.Category.name.Equals("ДВС"));
                    curCategory = "Классические автомобили";
                }
            }

            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = cars.ToList();
            obj.currentCategory = curCategory;

            return View(obj);
        }
    }
}
