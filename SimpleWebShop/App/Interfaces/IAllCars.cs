using Microsoft.AspNetCore.SignalR;
using SimpleWebShop.App.Models;
using SimpleWebShop.App.SignalR;
using SimpleWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> GetAllCars { get; }
        IEnumerable<Car> GetFavCars { get; }
        Car GetObjectCar(int carID);
        Car CreateCar(CreateCarViewModel model);
    }
}
