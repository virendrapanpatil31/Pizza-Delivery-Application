using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Entities
{
    public class OrderItem
    {
        private OrderItem()
        {

        }
        
        public OrderItem(int itemId, decimal unitPrice,int quantity,decimal total)
        {
            ItemId = itemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            total = Total;
        }
        public int Id { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
