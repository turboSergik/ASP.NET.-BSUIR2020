using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Mocks
{
    public class MockCarsCategory : ICarsCategory
    {
        public IEnumerable<Category> GetAllCategories
        {
            get
            {
                return new List<Category> { 
                    new Category
                    {
                        name = "Электромобили",
                        description = "Новейшие разработки"
                    },
                    new Category
                    {
                        name = "Автомобили на ДВС",
                        description = "Устаревшие технологии"
                    }
                };
            }
        }
    }
}
