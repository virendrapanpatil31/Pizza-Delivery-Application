using PizzaHub.Entities;
using PizzaHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Services.Interfaces
{
    public interface IOrderService 
    {
        public IEnumerable<Order> GetUserOrders(int UserId);

        public int PlaceOrder(int userId, string orderId, string paymentId, CartModel cart, Address address);

        OrderModel GetOrderDetails(string OrderId);
        PagingListModel<OrderModel> GetOrderList(int page = 1, int pagesize = 10);
    }
}
