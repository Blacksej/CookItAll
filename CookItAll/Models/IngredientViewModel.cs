using Microsoft.AspNetCore.Mvc.Rendering;

namespace CookItAll.Models
{
    public class IngredientViewModel
    {
        public Ingredient? Ingredient { get; set; }
        public List<Category> Categories { get; set; }
        public int CategoryID { get; set; }
    }
}
