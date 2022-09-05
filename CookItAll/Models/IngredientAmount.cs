namespace CookItAll.Models
{
    public class IngredientAmount
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
