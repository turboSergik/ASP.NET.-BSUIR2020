using SimpleWebShop.App.intefraces;
using SimpleWebShop.App.Intefraces;
using SimpleWebShop.App.Models;
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
                        price = 45000,
                        Category = _categoryCars.GetAllCategories.First()
                    },
                    new Car
                    {
                        name = "Tesla Model E",
                        description = "Tesla",
                        price = 60000,
                        Category = _categoryCars.GetAllCategories.First()
                    },
                    new Car
                    {
                        name = "Tesla Model X",
                        description = "Tesla",
                        price = 65000,
                        Category = _categoryCars.GetAllCategories.First()
                    },
                    new Car
                    {
                        name = "Tesla Model Y",
                        description = "Tesla",
                        price = 75000,
                        Category = _categoryCars.GetAllCategories.First()
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

        public Car GetObjectCar(int carID)
        {
            return null;
        }
    }
}
