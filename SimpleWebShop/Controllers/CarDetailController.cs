using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using SimpleWebShop.App.SignalR;
using SimpleWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.Controllers
{
    public class CarDetailController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        private readonly IHubContext<EventHub> _hubContext;
        private readonly ILogger<AccountController> _logger;

        public CarDetailController(IAllCars allCars, ICarsCategory allCategories, IHubContext<EventHub> hubContext, ILogger<AccountController> logger)
        {
            _allCars = allCars;
            _allCategories = allCategories;
            _hubContext = hubContext;
            _logger = logger;
        }


        [Route("Cars/CarDetailView")]
        [Route("Cars/CarDetailView/{id}")]
        public async Task<ViewResult> CarView(string carID)
        {

            Car car = null;

            if (string.IsNullOrEmpty(carID))
            {
                return View();
            }
            else
            {
                car = _allCars.GetObjectCar(Int32.Parse(carID));
            }

            CarDetailViewModel obj = new CarDetailViewModel();
            obj.car = car;

            await _hubContext.Clients.All.SendAsync("needUpdateCars", car);

            return View(obj);
        }

        public RedirectToActionResult showCarDetail(int id)
        {
            _logger.LogInformation($"LOG Reddirect to Car Detail fiew for carID= {id}");
            return RedirectToAction($"/Cars/CarDetailView/{id}");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel form)
        {
            var newCar = _allCars.CreateCar(form);
            await _hubContext.Clients.All.SendAsync("needUpdateCars", newCar);
          
            _logger.LogInformation($"LOG Creatind new car Model; Sending hubs");
            
            // await Task.Delay(1000);

            return Redirect("/Home/Index");
        }


        [Route("CarDetail/AddNewCar/")]
        [Route("CarDetail/AddNewCar/{category}")]
        public ViewResult AddNewCar(string category)
        {
            _logger.LogInformation($"LOG View to creationg car");

            CreateCarViewModel obj = new CreateCarViewModel();
            obj.categoryName = category;

            return View(obj);
        }
    }
}
