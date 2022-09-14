using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace PizzaHub.Entities
{
    public class User: IdentityUser<int>
    {
        public string Name { get; set; }
        [NotMapped]
        public string[] Roles { get; set; }
    }
}
