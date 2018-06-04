using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServerLibrary
{
    class Generator


    {
        public List<Product> GenerateProducts() {
            List<Product> Products = new List<Product>();
            Products.Add(
                new Product {
                    Name = "Carrot",
                    Amount = 20,
                    Price = 2.50,
                    Id = 1
                });
            Products.Add(
                new Product {
                    Name = "Apple",
                    Amount = 30,
                    Price = 1,
                    Id = 2
                });
            Products.Add(
                new Product {
                    Name = "Lettuce",
                    Amount = 50,
                    Price = 3,
                    Id = 3
                });
            return Products;
        }



        public List<User> GenerateUsers() {
            List<User> users = new List<User>();
            users.Add(new User {
                Id = 1,
                Username = "owen",
                Password = "newo",
                Balance = 50,
                BoughtProducts = new List<Product>()
            });
            users.Add(new User {
                Id = 2,
                Username = "patrick",
                Password = "kcirtap",
                Balance = 50,
                BoughtProducts = new List<Product>()
            });
            return users;
        }
    }
}
