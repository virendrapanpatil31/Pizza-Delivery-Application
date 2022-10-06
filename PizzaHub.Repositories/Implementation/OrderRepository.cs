using Microsoft.EntityFrameworkCore;
using PizzaHub.Entities;
using PizzaHub.Repositories.Interfaces;
using PizzaHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.PagedList;

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
        public OrderRepository(DbContext dbConntext) : base(dbConntext)
        {

        }

        public IEnumerable<Order> GetUserOrders(int UserId)
        {
            return appDbContext.Orders.Include(o => o.OrderItems).Where(x => x.UserId == UserId).ToList();
        }

        public OrderModel GetOrderDetails(string orderId)
        {
            var model = (from order in appDbContext.Orders
                         where order.Id == orderId
                         select new OrderModel
                         {
                             Id = order.Id,
                             UserId = order.UserId,
                             CreatedDate = order.CreatedDate,
                             Items = (from orderItem in appDbContext.OrderItems
                                      join item in appDbContext.Items
                                      on orderItem.ItemId equals item.Id
                                      where orderItem.OrderId == orderId
                                      select new ItemModel
                                      {
                                          Id = orderItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity =  orderItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = orderItem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;   
        }

        public PagingListModel<OrderModel> GetOrderList(int page, int pagesize)
        {
            var pagingModel = new PagingListModel<OrderModel>();
            var data = (from order in appDbContext.Orders
                        join payment in appDbContext.PaymentDetails
                        on order.PaymentId equals payment.Id
                        select new OrderModel
                        {
                            Id = order.Id,
                            UserId = order.UserId,
                            PaymentId = payment.Id,
                            CreatedDate = order.CreatedDate,
                            GrandTotal = payment.GrandTotal,
                            Locality = order.Locality
                        });
            int itemCounts = data.Count();
            var orders = data.Skip((page - 1) * pagesize).Take(pagesize);

            var pagedListData = new StaticPagedList<OrderModel>(orders, page, pagesize, itemCounts);

            pagingModel.Data = pagedListData;
            pagingModel.Page = page;
            pagingModel.PageSize = pagesize;
            pagingModel.TotalRows = itemCounts;

            return pagingModel;
        }
    }
}
