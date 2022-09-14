﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PaymentId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public string Locality { get; set; }
        public string PhoneNumber { get; set; }
    }
}
