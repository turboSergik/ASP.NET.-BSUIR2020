using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountController> _logger;


        public CarsController(IAllCars allCars, ICarsCategory allCategories, ILogger<AccountController> logger)
        {
            _allCars = allCars;
            _allCategories = allCategories;
            _logger = logger;
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
                cars = _allCars.GetAllCars.Where(item => item.Category.name.ToLower() == _category.ToLower());
                curCategory = _category;
            }

            _logger.LogInformation("LOG Show cars for special category");

            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = cars.ToList();
            obj.currentCategory = _category;

            return View(obj);
        }
    }
}
