using System.ComponentModel.DataAnnotations;

namespace CraftMake.Models
{
    public class Product
    {
        public int Id { get; set; }
        [EmailAddress]
        public string userEmail { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ImagePath { get; set; }
    }
}
