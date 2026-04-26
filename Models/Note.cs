using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class Note
    {
        [Key]
        [Display(Name = "Note ID")]
        public int NoteID { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        public ICollection<Meal>? Meals { get; set; }
    }
}
