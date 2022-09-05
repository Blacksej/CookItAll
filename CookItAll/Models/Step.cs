using System.ComponentModel.DataAnnotations.Schema;

namespace CookItAll.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey("Step")]
        public virtual Recipe? Recipe { get; set; }
        [ForeignKey("Step")]
        public virtual Step? NextStep { get; set; }
    }
}
