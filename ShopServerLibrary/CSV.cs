using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServerLibrary
{
    class CSV
    {

        public void saveProduct(Product product) {
            var path = "\\products.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, product.Name, product.Price, product.Amount);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }

        public void saveUser(User user) {
            var path = "\\users.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, user.Balance, user.Password, user.Username);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }
        public void saveInventory(Product product, User user, int amount) {
            var path = "\\inventory.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, product.Id, user.Id, amount);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }

        public List<User> readUsers() {
            var path = "\\users.csv";
            String[] csv = File.ReadAllLines(path);
            List<User> users = new List<User>();
            foreach (string line in csv) {
                string[] userline = line.Split(',');

                User user = new User {

                    Id = Int32.Parse(userline[0]),
                    Balance = Double.Parse(userline[1]),
                    Password = userline[2],
                    Username = userline[3]

                };
                users.Add(user);



            }
            return users;
        }

        public List<Product> readProducts() {
            var path = "\\products.csv";
            String[] csv = File.ReadAllLines(path);
            List<Product> products = new List<Product>();
            foreach (string line in csv) {
                string[] productline = line.Split(',');

                Product newProduct = new Product {
                    Id = Int32.Parse(productline[0]),
                    Name = productline[1],
                    Price = Double.Parse(productline[2]),
                    Amount = Int32.Parse(productline[3])
                };
                products.Add(newProduct);

            }
            return products;
        }

        public List<Product> readInventory(int user) {
            var path = "\\inventory.csv";
            List<Product> products = readProducts();

            String[] csv = File.ReadAllLines(path);
            List<Product> results = new List<Product>();
            foreach (string line in csv) {
                string[] inventoryline = line.Split(',');
                //check if user
                if (Int32.Parse(inventoryline[2]) == user) {
                    Product item = (from product in products
                                    where product.Id == Int32.Parse(inventoryline[1])
                                    select product).First();
                    results.Add(
                        new Product {
                            Amount = Int32.Parse(inventoryline[3]),
                            Id = item.Id,
                            Name = item.Name,
                            Price = item.Price
                        });
                }
            }
            return results;
        }


    }
}
