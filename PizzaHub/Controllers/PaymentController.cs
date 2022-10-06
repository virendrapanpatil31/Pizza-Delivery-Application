using Microsoft.AspNetCore.Mvc;
using PizzaHub.Repositories.Models;
using PizzaHub.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaHub.Models;
using PizzaHub.Services.Models;
using Microsoft.Extensions.Options;
using PizzaHub.Services.Interfaces;
using PizzaHub.Interfaces;
using Microsoft.AspNetCore.Http;
using PizzaHub.Entities;

namespace PizzaHub.Controllers
{
    public class PaymentController : BaseController
    {
        //key_Id - rzp_test_sE0vItjXEAJfam
        //key_secret - UkOqVm15HEurXmvsyRbJqgiu

        //Master Card: 5104 0600 0000 0008
        //Visa : 4111 1111 1111 1111
        private readonly IOptions<RazorPayConfig> _razorPayConfig;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;

        public PaymentController(IOptions<RazorPayConfig> razorPayConfig,IPaymentService paymentService,IOrderService orderService,IUserAccessor userAccessor):base(userAccessor)
        {
            _razorPayConfig = razorPayConfig;
            _paymentService = paymentService;
            _orderService = orderService;
        }
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
            payment.RazorpayKey = _razorPayConfig.Value.Key;
            payment.Receipt = Guid.NewGuid().ToString();

            payment.OrderId = _paymentService.CreateOrder(payment.GrandTotal * 100, payment.Currency, payment.Receipt);
            return View(payment);
        }
        [HttpPost]
        public IActionResult Status(IFormCollection form)
        {
            try
            {
                if(form.Keys.Count > 0 && !String.IsNullOrWhiteSpace(form["rzp_paymentid"]))
                {
                    string paymentId = form["rzp_paymentid"];
                    string orderId = form["rzp_orderid"];
                    string signature = form["rzp_signature"];
                    string transactionId = form["Receipt"];
                    string currency = form["Currency"];


                    var payment = _paymentService.GetPaymentDetails(paymentId);
                    bool IsSignVerified = _paymentService.VerifySignature(signature, orderId, paymentId);

                    if (IsSignVerified && payment != null)
                    {
                        CartModel cart = TempData.Get<CartModel>("Cart");
                        PaymentDetails model = new PaymentDetails();

                        model.CartId = cart.Id;
                        model.Total = cart.Total;
                        model.Tax = cart.Tax;
                        model.GrandTotal = cart.GrandTotal;

                        model.Status = payment.Attributes["status"]; //captured
                        model.TransactionId = transactionId;
                        model.Currency = payment.Attributes["currency"];
                        model.Email = payment.Attributes["email"];
                        model.Id = paymentId;
                        model.UserId = CurrentUser.Id;

                        int status = _paymentService.SavePaymentDetails(model);

                        if(status > 0)
                        {
                            Response.Cookies.Append("CId", "");//resetting CartId in Cookie
                            Address address = TempData.Get<Address>("Address");
                            _orderService.PlaceOrder(CurrentUser.Id, orderId,paymentId, cart, address);

                            TempData.Set("PaymentDetails", model);
                            return RedirectToAction("Receipt");

                        }
                        else
                        {
                            ViewBag.Message = "Although, due to some technical issues it's not get updated in our side, we will contact you soon..";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            ViewBag.Message = "Your payment has been failed. You can contact us at virendrapanpatil31@gmail.com";
            return View();

        }

        public IActionResult Receipt()
        {
            PaymentDetails model = TempData.Peek<PaymentDetails>("PaymentDetails");
            return View(model);
        }
    }
}
