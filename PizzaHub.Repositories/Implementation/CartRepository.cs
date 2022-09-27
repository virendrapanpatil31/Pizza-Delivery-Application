using Microsoft.EntityFrameworkCore;
using PizzaHub.Entities;
using PizzaHub.Repositories.Interfaces;
using PizzaHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaHub.Repositories.Implementation
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext appDbContext
        {
            //Inheritance behaiour in C#. Accessing Parent class instance using child class
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public CartRepository(DbContext dbContext): base(dbContext)
        {

        }
        public Cart GetCart(Guid CartId)
        {
            return appDbContext.Carts.Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault();
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = appDbContext.CartItems.Where(ci => ci.CartId == cartId && ci.Id == itemId).FirstOrDefault();
            if(item != null)
            {
                appDbContext.CartItems.Remove(item);
                return appDbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);

            if(cart != null)
            {
                for(int i = 0;i < cart.Items.Count ; ++i)
                {
                    flag = true;
                    if(Quantity < 0 && cart.Items[i].Quantity > 1)
                    {
                        cart.Items[i].Quantity += (Quantity);
                    }else if(Quantity > 0)
                    {
                        cart.Items[i].Quantity += (Quantity);
                    }
                    break;
                }
                if (flag)
                    return appDbContext.SaveChanges();
            }
            return 0;

        }

        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return appDbContext.SaveChanges();
        }

        public CartModel GetCartDetails(Guid CartId)
        {
            var model = (from cart in appDbContext.Carts
                         where cart.Id == CartId && cart.IsActive == true
                         select new CartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreateDate,
                             Items = (from cartItem in appDbContext.CartItems
                                      join item in appDbContext.Items
                                      on cartItem.ItemId equals item.Id
                                      where cartItem.CartId == CartId
                                      select new ItemModel {
                                          Id = cartItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = cartItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = item.UnitPrice
                                      }).ToList(),
                         }).FirstOrDefault();
            return model;
        }
    }
}
