using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Entities
{
    public class Role: IdentityRole<int>
    {
        //taking temporary variable 
        public string Description { get; set; }
    }
}
