namespace CookItAll.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public override string ToString()
        {
            return String.Format("Navn: {0}", Name);
        }
    }
}
