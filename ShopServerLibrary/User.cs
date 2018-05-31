using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServerLibrary
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Saldo { get; set; }
        public List<Product> Products { get; set; }



        public string generateJsonFromProducts() {
            //hard coded products

            this.products.Add(
                new Product {
                    Name = "carrot",
                    Amount = 12,
                    Price = 2.4,
                    Id = 1
                });

             this.products.Add(
            new Product {
                Name = "pear",
                Amount = 12,
                Price = 2.4,
                Id = 2
            });
            this.products.Add(
            new Product {
                Name = "papaya",
                Amount = 12,
                Price = 2.4,
                Id = 3
            });
            return "je moeder";
        }
    }
}
