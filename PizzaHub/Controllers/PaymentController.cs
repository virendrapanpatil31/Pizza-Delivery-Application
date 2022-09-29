using Microsoft.AspNetCore.Mvc;
using PizzaHub.Repositories.Models;
using PizzaHub.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHub.Models;

namespace PizzaHub.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            PaymentModel payment = new PaymentModel();
            CartModel cart = TempData.Peek<CartModel>("Cart");
            if(cart != null)
            {
                payment.Cart = cart;
            }
            payment.GrandTotal = Math.Round(cart.GrandTotal);
            payment.Currency = "INR";
            string items = "";
            foreach(var item in cart.Items)
            {
                items += item.Name + ",";
            }
            payment.Description = items;
            return View(payment);
        }
    }
}
