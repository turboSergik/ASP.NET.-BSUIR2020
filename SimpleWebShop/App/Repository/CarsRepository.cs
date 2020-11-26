using Microsoft.EntityFrameworkCore;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Repository
{
    public class CarsRepository : IAllCars
    {
        private readonly AppDBContent _appDBContent;

        public CarsRepository(AppDBContent appDbContent)
        {
            _appDBContent = appDbContent;
        }

        public IEnumerable<Car> GetAllCars => _appDBContent.Car.Include(item => item.Category);
        public IEnumerable<Car> GetFavCars => _appDBContent.Car.Where(item => item.isFavorite).Include(item => item.Category);

        public Car GetObjectCar(int carID) => _appDBContent.Car.FirstOrDefault(item => item.id == carID);
    
    }
}
