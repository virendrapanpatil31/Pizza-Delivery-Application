using Microsoft.EntityFrameworkCore;
using PizzaHub.Entities;
using PizzaHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaHub.Repositories.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext appDbContext
        {
            get
            {
                return _dbContext as AppDbContext; 
            }
        }
        public OrderRepository(DbContext dbConntext): base(dbConntext)
        {

        }
        public IEnumerable<Order> GetUserOrders(int UserId)
        {
            return appDbContext.Orders.Include(o => o.OrderItems).Where(x => x.UserId == UserId).ToList();
        }
    }
}
