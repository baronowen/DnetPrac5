using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopServerLibrary
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        List<Product> products;


        //Hardcoded product list:
        //Will later be replaced by database.
        public List<Product> GenerateProducts() {
            products = new List<Product>();
            this.products.Add(
                new Product {
                    Name = "Carrot",
                    Amount = 20,
                    Price = 2.50,
                    Id = 1
                });
            this.products.Add(
                new Product {
                    Name = "Apple",
                    Amount = 30,
                    Price = 1,
                    Id = 2
                });
            this.products.Add(
                new Product {
                    Name = "Lettuce",
                    Amount = 50,
                    Price = 3,
                    Id = 3
                });

            //var json = JsonConvert.SerializeObject(this.products);
            //foreach(Product p in products)
            //{
            //    Console.WriteLine("{0} voor {1}", p.Name, p.Price);
            //}
            return products;
        }

        public override string ToString() {
            return "Product: " + Id + " " + Name + " " + Price + " " + Amount;
        }
    }
}
