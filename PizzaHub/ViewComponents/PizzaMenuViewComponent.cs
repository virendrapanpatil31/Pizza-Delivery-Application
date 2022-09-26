using Microsoft.AspNetCore.Mvc;
using PizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.ViewComponents
{
    public class PizzaMenuViewComponent: ViewComponent
    {
        ICatalogService _catalogService;
        public PizzaMenuViewComponent(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IViewComponentResult Invoke()
        {
            var items = _catalogService.GetItems();
            return View("~/Views/Shared/_PizzaMenu.cshtml",items);
        }
    }
}
