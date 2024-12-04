using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rainbowcat_web_1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]//當此屬性不需要被印涉到資料庫使用，忽略屬性進行資料庫欄位映射
        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/150";
        [ValidateNever]//當屬性不需要被驗證時使用，忽略屬性進行驗證
        public Category? Category { get; set; } //A product belongs to a category
        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; } //A product can be in many order items
        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngredients { get; set; } //A product can have many ingredients
    }
}