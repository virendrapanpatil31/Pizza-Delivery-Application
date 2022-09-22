using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHub.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Item Name")]
        public string Name { get; set; }
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "Please Add Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter appropriate UnitPrice for Item")]
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Assign Cateory Id")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please select type")]
        public int ItemTypeId { get; set; }
    }
}
