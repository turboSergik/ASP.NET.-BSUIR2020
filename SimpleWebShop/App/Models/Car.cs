using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Models
{
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int price { get; set; }
        public bool isFavorite { get; set; }
        public int avaliable { get; set; }
        public int categoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
