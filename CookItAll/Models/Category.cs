using System.ComponentModel.DataAnnotations;

namespace CookItAll.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name="Kategori")]
        [Required]
        public string? Name { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

        //public override string ToString()
        //{
        //    return String.Format("Navn: {0}", Name);
        //}
    }
}
