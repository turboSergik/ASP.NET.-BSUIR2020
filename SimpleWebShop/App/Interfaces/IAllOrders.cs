using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
    }
}
