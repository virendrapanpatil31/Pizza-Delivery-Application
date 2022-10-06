using PizzaHub.Entities;
using PizzaHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetUserOrders(int UserId);
        OrderModel GetOrderDetails(string id);
        PagingListModel<OrderModel> GetOrderList(int page, int pagesize);
    }
}
