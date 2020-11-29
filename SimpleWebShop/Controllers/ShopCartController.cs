using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using SimpleWebShop.App.Repository;
using SimpleWebShop.ViewModels;

namespace SimpleWebShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart) 
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult CartView()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel();
            obj.shopCart = _shopCart;

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.GetAllCars.FirstOrDefault(item => item.id == id);
            if (item != null)
            {
                _shopCart.AddItemToCart(item);
            }

            return RedirectToAction("CartView");
        }
    }
}
