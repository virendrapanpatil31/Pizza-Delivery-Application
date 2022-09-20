using PizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Interfaces
{
    public interface IUserAccessor
    {
        User GetUser();
    }
}
