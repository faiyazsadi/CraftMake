using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CraftMake.Models
{
    public class Product
    {
        public int Id { get; set; }
        [EmailAddress]
        public string userEmail { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public int? IsApproved { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile CoverPhoto { get; set; }
    }
}
