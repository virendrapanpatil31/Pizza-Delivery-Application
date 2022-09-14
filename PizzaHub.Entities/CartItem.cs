using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PizzaHub.Entities
{
    public class CartItem
    {
        public CartItem()
        {
            
        }

        public CartItem(int itemId,int quantity, decimal unitPrice)
        {
            ItemId = itemId;
            Quantity = quantity;
            UnitPrice = unitPrice;

        }
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public int ItemId { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public Cart Cart { get; set; }
    }
}
