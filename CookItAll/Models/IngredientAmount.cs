namespace CookItAll.Models
{
    public class IngredientAmount
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public virtual Ingredient? Ingredient { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}
