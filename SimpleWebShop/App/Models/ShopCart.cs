using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Models
{
    public class ShopCart
    {
        private readonly AppDBContent _appDBContent;

        public ShopCart(AppDBContent appDbContent)
        {
            _appDBContent = appDbContent;
        }

        public string shopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { shopCartId = shopCartId };
        }

        public void AddItemToCart(Car car)
        {
            this._appDBContent.ShopCartItem.Add(new ShopCartItem 
            { 
                shopCartId = this.shopCartId,
                car = car,
                price = car.price
            });

            this._appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return _appDBContent.ShopCartItem.Where(item => item.shopCartId == this.shopCartId).ToList();
        }
    }
}
