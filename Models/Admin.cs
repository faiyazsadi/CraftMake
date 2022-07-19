using System.ComponentModel.DataAnnotations;

namespace CraftMake.Models
{
    public class Admin
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Key]
        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        public string phoneNumber { get; set; }
    }
}
