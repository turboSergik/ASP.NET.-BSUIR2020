using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _orders;
        private readonly ShopCart _shopCart;
        private readonly ILogger<AccountController> _logger;

        public OrderController(IAllOrders allOrders, ShopCart shopCart, ILogger<AccountController> logger)
        {
            _orders = allOrders;
            _shopCart = shopCart;
            _logger = logger;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.listShopItems = _shopCart.GetShopItems();

            if (_shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина не должна быть пуста!");
                _logger.LogInformation("LOG cart is empty!");
            }

            if (ModelState.IsValid)
            {
                _orders.createOrder(order);
                _logger.LogInformation("LOG cart success added!");
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
