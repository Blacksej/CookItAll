namespace CookItAll.Models
{
    public class RecipeViewModel
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; } = new List<Step>();
        public Recipe? Recipe { get; set; }
    }
}
