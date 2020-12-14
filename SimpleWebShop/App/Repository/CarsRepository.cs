using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using SimpleWebShop.App.SignalR;
using SimpleWebShop.ViewModels;
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
        public IEnumerable<Car> GetFavCars => _appDBContent.Car.Include(item => item.Category);

        public Car GetObjectCar(int carID) => _appDBContent.Car.FirstOrDefault(item => item.id == carID);


        public Car CreateCar(CreateCarViewModel model)
        {
            var category = _appDBContent.Category.Where(item => item.name.ToLower() == model.categoryName.ToLower()).FirstOrDefault();

            var newCar = _appDBContent.Car.Add(new Car()
            {
                Category = category,
                image = model.image,
                name = model.name,
                price = model.price,
                description = model.description,
                shortDescription = model.description,
                avaliable = 0,
                isFavorite = false
            }).Entity;

            _appDBContent.SaveChanges();

            return newCar;
        }

    }
}
