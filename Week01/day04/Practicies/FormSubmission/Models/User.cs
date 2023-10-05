#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Range(0, 120, ErrorMessage = "Age must be a positive number")]
        public int Age { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at aleast 8 characters")]
        public string Password { get; set; }
    }
}