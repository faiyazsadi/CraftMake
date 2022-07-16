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
                if(context.Product.Any())
                {
                    /*List<Product> remove = new List<Product>();
                    remove = context.Product.ToList();
                    context.Product.RemoveRange(remove);*/

                    return;
                }
                context.Product.AddRange(
                    new Product
                    {
                        ProductName = "Modern Chair",
                        ProductPrice = 180,
                        ProductDescription = "This is a custom made chair",
                        ImagePath = "/img/bg-img/1.jpg"
                    },
                    new Product
                    {
                        ProductName = "Minimalistic Plant Pot",
                        ProductPrice = 100,
                        ProductDescription = "Stone Plant Pot",
                        ImagePath = "/img/bg-img/2.jpg"
                    },
                    new Product
                    {
                        ProductName = "Plant Pot",
                        ProductPrice = 100,
                        ProductDescription = "Stone Plant Pot",
                        ImagePath = "/img/bg-img/5.jpg"
                    },
                    new Product
                    {
                        ProductName = "Small Table",
                        ProductPrice = 100,
                        ProductDescription = "Stone Plant Pot",
                        ImagePath = "/img/bg-img/6.jpg"
                    },
                    new Product
                    {
                        ProductName = "Night Stand",
                        ProductPrice = 100,
                        ProductDescription = "Stone Plant Pot",
                        ImagePath = "/img/bg-img/4.jpg"
                    },
                    new Product
                    {
                        ProductName = "Modern Rocking Chair",
                        ProductPrice = 100,
                        ProductDescription = "Stone Plant Pot",
                        ImagePath = "/img/bg-img/8.jpg"
                    },
                    new Product
                    {
                        ProductName = "Modern Rocking Chair",
                        ProductPrice = 100,
                        ProductDescription = "Stone Plant Pot",
                        ImagePath = "/img/bg-img/3.jpg"
                    },
                    new Product
                    {
                        ProductName = "Modern Rocking Chair",
                        ProductPrice = 100,
                        ProductDescription = "Stone Plant Pot",
                        ImagePath = "/img/bg-img/9.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
