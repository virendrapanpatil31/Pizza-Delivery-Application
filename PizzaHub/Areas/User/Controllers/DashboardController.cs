using Microsoft.AspNetCore.Mvc;
using PizzaHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Areas.User.Controllers
{

    public class DashboardController : BaseController
    {
        public DashboardController(IUserAccessor userAccessor): base(userAccessor)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
