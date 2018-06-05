using ShopServerLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShopServerLibrary
{
    internal class CSV
    {
        /*
          
            class that interacts with csv persistency
          
            Code structure statistics for file 'D:\c#projects\DnetPrac5\ShopServerLibrary\CSV.cs'

	        C# classes        :         1
	        C# interfaces     :         0
	        C# structs        :         0
	        C# enums          :         0

	        C# functions      :         9
	        C# properties     :         0

        ---------------------------------------------------------------

        Code line count  statistics for file 'D:\c#projects\DnetPrac5\ShopServerLibrary\CSV.cs'

        	C# comment lines  :        30
        	C# empty lines    :        21
	        C# pure code lines:       129
	    -----------------------------
	        Total C# lines    :       180


         */


        // save Product, used when no attribute has to be changed




        //save all products, used when attribute needs to be changed
        public void updateProduct(List<Product> products) {
            //method same idea as: updateUser and saveInventoryFromScratch
            //get path and define lines to input
            var path = "\\products.csv";
            List<String> lines = new List<string>();

            //define id
            int id = 1;

            //loop through all products and add product to lines
            foreach (Product product in products) {
                //format is: ProductID,name,price,amount
                String newLine = string.Format("{0},{1},{2},{3}", id, product.Name, product.Price, product.Amount);
                id++;
                lines.Add(newLine);
            }
            //save list
            File.WriteAllLines(path, lines);
        }

        // save User, used when no attribute has to be changed 


        //save all users, used when attribute needs to be changed
        public void updateUser(List<User> users) {
            var path = "\\users.csv";
            List<String> lines = new List<string>();
            int id = 1;
            foreach (User user in users) {
                //format is: userID,balance,password,username
                String newLine = string.Format("{0},{1},{2},{3}", id, user.Balance, user.Password, user.Username);
                id++;
                lines.Add(newLine);
            }

            File.WriteAllLines(path, lines);
        }
        // save Inventory line, used when no attribute has to be changed



        //save all inventory lines, used when attribute needs to be changed
        public void saveInventoryFromScratch(List<Product> products, int user) {
            var path = "\\inventory.csv";
            List<String> lines = new List<string>();
            int id = 1;
            foreach (Product product in products) {
                //format is: inventoryLineID,productID,userID,amount
                String newLine = string.Format("{0},{1},{2},{3}", id, product.Id, user, product.Amount);
                id++;
                lines.Add(newLine);
            }

            File.WriteAllLines(path, lines);
        }

        // read all users
        public List<User> readUsers() {

            //method same idea as: readProducts,readInventory
            //define path and read lines
            var path = "\\users.csv";
            List<User> users = new List<User>();
            var csvFileLenth = new FileInfo(path).Length;
            if (csvFileLenth != 0) {
                String[] csv = File.ReadAllLines(path);
                //define userlist

                //loop through csv file, makes new user for each line
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
            }
            return users;
        }
        // read all products
        public List<Product> readProducts() {
            var path = "\\products.csv";
            List<Product> products = new List<Product>();
            var csvFileLenth = new FileInfo(path).Length;
            if (csvFileLenth != 0) {
                String[] csv = File.ReadAllLines(path);
               
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
            }
            return products;
        }

        // read all inventory lines from an user

        public List<Product> readInventory(int user) {
            var path = "\\inventory.csv";
            var csvFileLenth = new FileInfo(path).Length;
            List<Product> results = new List<Product>();
            if (csvFileLenth != 0) {
                List<Product> products = readProducts();

                String[] csv = File.ReadAllLines(path);

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
            }
            return results;

        }


    }
}