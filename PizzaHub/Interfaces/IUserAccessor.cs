﻿using PizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Interfaces
{
    interface IUserAccessor
    {
        User GetUser();
    }
}