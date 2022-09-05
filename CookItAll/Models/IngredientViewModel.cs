using Microsoft.AspNetCore.Mvc.Rendering;

namespace CookItAll.Models
{
    public class IngredientViewModel
    {
        public IngredientViewModel()
        {
            Categories = new List<Category>();
        }
        public Ingredient? Ingredient { get; set; }
        public List<Category> Categories { get; set; }
    }
}
