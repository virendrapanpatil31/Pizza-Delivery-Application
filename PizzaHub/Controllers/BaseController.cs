using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Entities;
using PizzaHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Controllers
{
    public class BaseController : Controller
    {
        // protected UserManager<User> _userManager;


        //public User CurrentUser
        // {
        //     get
        //     {
        //         if(User.Identity.Name != null)
        //         {
        //             return _userManager.FindByNameAsync(User.Identity.Name).Result;
        //         }
        //         else
        //         {
        //             return null;
        //         }
        //     }
        // }
        // public BaseController(UserManager<User> userManager)
        // {
        //     _userManager = userManager;
        // }

        IUserAccessor _userAccessor;

        public User CurrentUser
        {
            get
            {
                if (User != null)
                {
                    return _userAccessor.GetUser();
                }
                else
                {
                    return null;
                }
            }
        }
        public BaseController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

    }
}
