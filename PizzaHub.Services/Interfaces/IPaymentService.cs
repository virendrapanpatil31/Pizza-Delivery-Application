using PizzaHub.Entities;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Services.Interfaces
{
    public interface IPaymentService
    {
        string CreateOrder(decimal amount, string currency, string receipt);
        string CapturePayment(string paymentId, string orderId);
        Payment GetPaymentDetails(string paymentId);
        bool VerifySignature(string signature, string orderId, string paymentId);
        int SavePaymentDetails(PaymentDetails model);
    }
}
