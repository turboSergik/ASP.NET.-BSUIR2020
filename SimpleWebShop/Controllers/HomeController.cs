using Microsoft.AspNetCore.Mvc;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
   
            var obj = new HomeViewModel();
            obj.favCars = _carRep.GetFavCars;

            return View(obj);
        }
    }
}
