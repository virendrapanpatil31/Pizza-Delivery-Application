using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Entities
{
    public class Cart
    {

        public Cart()
        {
            Items = new List<CartItem>();
            CreateDate = DateTime.Now;
            IsActive = true;
        }
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public List<CartItem> Items { get;private set; }
        public bool IsActive { get; set; }
    }
}
