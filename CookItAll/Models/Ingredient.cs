namespace CookItAll.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientAmount> IngredientAmounts { get; set; }
        public Category Category { get; set; }
        public Fridge Fridge { get; set; }
    }
}
