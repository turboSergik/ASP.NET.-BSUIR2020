using Microsoft.AspNetCore.Mvc;
using SimpleWebShop.App.Algorithms;
using SimpleWebShop.App.Interfaces;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace SimpleWebShop.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUsers _users;

        public AccountController(IUsers users)
        {
            _users = users;
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;

                user = _users.GetAllUsers.FirstOrDefault(item => item.email == model.email);

                if (user == null)
                {
                    _users.CreateUser(model);
                    user = _users.GetAllUsers.FirstOrDefault(item => item.email == model.email);

                    // success creating user
                    if (user != null)
                    {
                        HttpContext.SignOutAsync();
                        var listClaims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Email, model.email),
                            new Claim(ClaimTypes.Role, "User")
                        };

                        var claimIndentity = new ClaimsIdentity(listClaims, "Claims");

                        var userPrincipal = new ClaimsPrincipal(new[] { claimIndentity });

                        HttpContext.SignInAsync(userPrincipal);


                        ViewBag.message = "Успешная регистрация.";
                        return Redirect("/Home/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким email-ом уже существует!");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {

            await HttpContext.SignOutAsync();
            
            var kek1 = User;

            if (ModelState.IsValid)
            {
                User user = null;
                var hashPassword = HashingPassword.GetHashPassword(model.password);

                user = _users.GetAllUsers.FirstOrDefault(item => item.email == model.email && item.password == hashPassword);

               
                if (user != null)
                {
                    await HttpContext.SignOutAsync();
                    
                    var listClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.name),
                        new Claim(ClaimTypes.Email, user.email),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var claimIndentity = new ClaimsIdentity(listClaims, "Claims");
                    var userPrincipal = new ClaimsPrincipal(new[] { claimIndentity });
                    await HttpContext.SignInAsync(userPrincipal);

                    await SendingEmails.SendEmailAsync(user.email);

                    ViewBag.message = "Успешная авторизация.";
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль!");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }
    
    }
}
