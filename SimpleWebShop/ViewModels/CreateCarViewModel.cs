using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.ViewModels
{
    public class CreateCarViewModel
    {
        public string name { get; set; }
        public int price {get; set;}
        public string description { get; set; }
        public string image { get; set; }

        public string categoryName { get; set; }
    }
}
