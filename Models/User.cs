using System.ComponentModel.DataAnnotations;

namespace CraftMake.Models
{
    public class User
    {
        public int Id { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
    }
}
