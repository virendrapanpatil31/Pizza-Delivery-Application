using PizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUserOrders(int UserId);
    }
}
