using Microsoft.AspNetCore.Mvc;
using PizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Areas.Admin.Controllers
{
    public class ItemController : BaseController
    {
        private ICatalogService _catalogService;

        public ItemController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }
        public IActionResult Index()
        {
            var data = _catalogService.GetItems();
            return View(data);
        }
    }
}
