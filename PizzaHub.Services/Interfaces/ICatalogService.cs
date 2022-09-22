using PizzaHub.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaHub.Services.Interfaces
{
    public interface ICatalogService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<ItemType> GetItemTypes();
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }
}
