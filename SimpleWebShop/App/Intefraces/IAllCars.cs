using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Intefraces
{
    public interface IAllCars
    {
        IEnumerable<Car> GetAllCars { get; set; }
        IEnumerable<Car> GetFavCars { get; set; }
        Car GetObjectCar(int carID);
    }
}
