using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServerLibrary
{
    class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public List<Product> Products { get; set; }


        public string GenerateProductList()
        {
            this.Products.Add(
                new Product
                {
                    Name = "Carrot",
                    Amount = 20,
                    Price = 2.50,
                    Id = 1
                });
            this.Products.Add(
                new Product
                {
                    Name = "Apple",
                    Amount = 30,
                    Price = 1,
                    Id = 2
                });
            this.Products.Add(
                new Product
                {
                    Name = "Lettuce",
                    Amount = 50,
                    Price = 3,
                    Id = 3
                });
            return this.Products.ToString();
        }
    }
}
