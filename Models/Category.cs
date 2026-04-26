using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; } = string.Empty;

        public ICollection<Meal>? Meals { get; set; }
    }
}