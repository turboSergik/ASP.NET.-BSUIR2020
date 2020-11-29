using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Models
{
    public class ShopCartItem
    {
        public int id { set; get; }
        public Car car { get; set; }
        public int price { get; set; }

        public string shopCartId { get; set; }
    }
}
