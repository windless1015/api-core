using System.ComponentModel.DataAnnotations;

namespace course_api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 60 characters")]
        [MinLength(3,  ErrorMessage = "This field must contain between 3 and 60 characters")]
        public string? Title { get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 60 characters")]
        [MinLength(3,  ErrorMessage = "This field must contain between 3 and 60 characters")]
        public string? CategoryName { get; set;}
    }
}