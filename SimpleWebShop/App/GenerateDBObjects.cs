using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App
{
    public class GenerateDBObjects
    {
        public static void GenerateObjects(IApplicationBuilder app)
        {
            using (var scrope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scrope.ServiceProvider.GetRequiredService<AppDBContent>();

                if (!content.Category.Any())
                    content.Category.AddRange(Categories.Select(item => item.Value));

                if (!content.Car.Any())
                    GenerateDBObjects.GenerateCars(ref content);

                content.SaveChanges();
            }
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
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

                    category = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        category.Add(item.name, item);
                    }
                }

                return category;
            }
        }

        private static void GenerateCars(ref AppDBContent content)
        {
            content.AddRange(
                new Car
                {
                    name = "Tesla Model S",
                    description = "Tesla",
                    shortDescription = "Tesla",
                    price = 45000,
                    Category = Categories["Электромобили"],
                    image = "/img/Tesla_S.jpg",
                    isFavorite = true,
                },
                new Car
                {
                    name = "Tesla Model E",
                    description = "Tesla",
                    shortDescription = "Tesla",
                    price = 60000,
                    Category = Categories["Электромобили"],
                    image = "/img/Tesla_E.jpg",
                    isFavorite = true,
                },
                new Car
                {
                    name = "Tesla Model X",
                    description = "Tesla",
                    shortDescription = "Tesla",
                    price = 65000,
                    Category = Categories["Электромобили"],
                    image = "/img/Tesla_X.jpg",
                    isFavorite = true,
                },
                new Car
                {
                    name = "Tesla Model Y",
                    description = "Tesla",
                    shortDescription = "Tesla",
                    price = 75000,
                    Category = Categories["Электромобили"],
                    image = "/img/Tesla_Y.jpg",
                    isFavorite = false,
                }
            );
        }
    }
}
