using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
        {
            _appDBContent = appDbContent;
            _shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.date = DateTime.Now;

            _appDBContent.Order.Add(order);
            _appDBContent.SaveChanges();

            var items = _shopCart.listShopItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = item.car.id,
                    orderID = order.id,
                    price = item.car.price,
                };
                _appDBContent.OrderDetail.Add(orderDetail);
            }


            _appDBContent.SaveChanges();
        }
    }
}
