using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int CarID { get; set; }
        public int price { get; set; }
        public virtual Car car { get; set; }
        public virtual Order order { get; set; }
    }
}
