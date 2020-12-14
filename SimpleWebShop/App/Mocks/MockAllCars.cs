using Microsoft.AspNetCore.SignalR;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using SimpleWebShop.App.SignalR;
using SimpleWebShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Mocks
{
    public class MockAllCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCarsCategory();

        public IEnumerable<Car> GetAllCars
        {
            get
            {
                return new List<Car> {
                    new Car
                    {
                        name = "Tesla Model S",
                        description = "Tesla",
                        shortDescription = "Tesla",
                        price = 45000,
                        Category = _categoryCars.GetAllCategories.First(),
                        image = "/img/Tesla_S.jpg",
                    },
                    new Car
                    {
                        name = "Tesla Model E",
                        description = "Tesla",
                        shortDescription = "Tesla",
                        price = 60000,
                        Category = _categoryCars.GetAllCategories.First(),
                        image = "/img/Tesla_E.jpg",
                    },
                    new Car
                    {
                        name = "Tesla Model X",
                        description = "Tesla",
                        shortDescription = "Tesla",
                        price = 65000,
                        Category = _categoryCars.GetAllCategories.First(),
                        image = "/img/Tesla_X.jpg",
                    },
                    new Car
                    {
                        name = "Tesla Model Y",
                        description = "Tesla",
                        shortDescription = "Tesla",
                        price = 75000,
                        Category = _categoryCars.GetAllCategories.First(),
                        image = "/img/Tesla_Y.jpg",
                    }
                };
            }
            set
            {

            }
        }

        public IEnumerable<Car> GetFavCars
        {
            get
            {
                return null;
            }
            set
            {

            }
        }

        public Car CreateCar(CreateCarViewModel model)
        {
            throw new NotImplementedException();
        }

        public Car GetObjectCar(int carID)
        {
            return null;
        }
    }
}
