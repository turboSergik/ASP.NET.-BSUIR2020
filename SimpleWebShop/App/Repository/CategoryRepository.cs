using Microsoft.EntityFrameworkCore;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent _appDBContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            _appDBContent = appDbContent;
        }

        public IEnumerable<Category> GetAllCategories => _appDBContent.Category;
    }
}
