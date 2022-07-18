using System.ComponentModel.DataAnnotations;

namespace CraftMake.Models
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Key]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string confirmPassword { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string town { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        public string phoneNumber { get; set; }
    }
}
