using CraftMake.Context;
using Microsoft.EntityFrameworkCore;

namespace CraftMake.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CraftMakeDatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<CraftMakeDatabaseContext>>()))
            {
                if(!context.Product.Any())
                {
                    /*List<Product> remove = new List<Product>();
                    remove = context.Product.ToList();
                    context.Product.RemoveRange(remove);*/

                    /*return;*/
                    context.Product.AddRange(
                        new Product
                        {
                            ProductName = "Modern Chair",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 180,
                            userEmail = "user@gmail.com",
                            ProductDescription = "This is a custom made chair",
                            ImagePath = "/img/bg-img/1.jpg"
                        },
                        new Product
                        {
                            ProductName = "Minimalistic Plant Pot",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 100,
                            userEmail = "user@gmail.com",
                            ProductDescription = "Stone Plant Pot",
                            ImagePath = "/img/bg-img/2.jpg"
                        },
                        new Product
                        {
                            ProductName = "Plant Pot",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 100,
                            userEmail = "user@gmail.com",
                            ProductDescription = "Stone Plant Pot",
                            ImagePath = "/img/bg-img/5.jpg"
                        },
                        new Product
                        {
                            ProductName = "Small Table",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 100,
                            userEmail = "user@gmail.com",
                            ProductDescription = "Stone Plant Pot",
                            ImagePath = "/img/bg-img/6.jpg"
                        },
                        new Product
                        {
                            ProductName = "Night Stand",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 100,
                            userEmail = "user@gmail.com",
                            ProductDescription = "Stone Plant Pot",
                            ImagePath = "/img/bg-img/4.jpg"
                        },
                        new Product
                        {
                            ProductName = "Modern Rocking Chair",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 100,
                            userEmail = "user@gmail.com",
                            ProductDescription = "Stone Plant Pot",
                            ImagePath = "/img/bg-img/8.jpg"
                        },
                        new Product
                        {
                            ProductName = "Modern Rocking Chair",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 100,
                            userEmail = "user@gmail.com",
                            ProductDescription = "Stone Plant Pot",
                            ImagePath = "/img/bg-img/3.jpg"
                        },
                        new Product
                        {
                            ProductName = "Modern Rocking Chair",
                            ProductQuantity = 10,
                            IsApproved = 1,
                            ProductPrice = 100,
                            userEmail = "user@gmail.com",
                            ProductDescription = "Stone Plant Pot",
                            ImagePath = "/img/bg-img/9.jpg"
                        }
                    );

                }
                if(!context.Admin.Any())
                {
                    context.Admin.AddRange(
                        new Admin
                        {
                            firstName = "Faiyaz",
                            lastName = "Sadi",
                            email = "admin1@gmail.com",
                            password = "admin",
                            phoneNumber = "01761995722"
                        },
                        new Admin
                        {
                            firstName = "Nabil",
                            lastName = "Faiyaz",
                            email = "admin2@gmail.com",
                            password = "admin",
                            phoneNumber = "01761995722"
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
