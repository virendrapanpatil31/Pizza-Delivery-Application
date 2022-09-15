using Microsoft.AspNetCore.Mvc;
using PizzaHub.Entities;
using PizzaHub.Models;
using PizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Controllers
{
    public class AccountController : Controller
    {

        IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                var result = _authService.CreateUser(user, model.Password);

                if (result)
                {
                    RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}
