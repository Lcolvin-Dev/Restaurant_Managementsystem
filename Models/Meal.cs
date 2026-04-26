using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Meal
    {
        [Key]
        [Display(Name = "Meal ID")]
        public int MealID { get; set; }

        [Required]
        [Display(Name = "Meal Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public Category? Category { get; set; }

        [Display(Name = "Note")]
        public int? NoteID { get; set; }

        public Note? Note { get; set; }
    }
}
