namespace CookItAll.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientAmount> IngredientAmounts { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Fridge? Fridge { get; set; }
    }
}
