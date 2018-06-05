﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShopServerLibrary;
using System.ServiceModel;
namespace ShopServerLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShopService" in both code and config file together.

    /*
    Code structure statistics for file 'D:\c#projects\DnetPrac5\ShopServerLibrary\ShopService.cs'

	    C# classes        :         1
	    C# interfaces     :         0
	    C# structs        :         0
	    C# enums          :         0

	    C# functions      :         7
	    C# properties     :         2

    ---------------------------------------------------------------

    Code line count  statistics for file 'D:\c#projects\DnetPrac5\ShopServerLibrary\ShopService.cs'

	    C# comment lines  :        44
	    C# empty lines    :        34
	    C# pure code lines:       130
	-----------------------------
	    Total C# lines    :       208


        Class that interacts with the frontend
    */


//[ServiceBehavior]
    public class ShopService : IShopService
    {
        private Product p = new Product();

        private User u = new User();
        private CSV csv = new CSV();

        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }



        // Methods related to products.

        //get all products from csv
        public List<Product> GetAllProducts() {
            //List<Product> pList = new List<Product>();
            //using (mymodelContainer ctx = new mymodelContainer())
            //{
            //    var products = from p in ctx.ProductSet
            //                   select new Product
            //                   {
            //                       Name = p.ProductName,
            //                       Amount = p.Amount,
            //                       Price = p.Price,
            //                       Id = p.ProductId
            //                   };
            //    foreach(Product p in products)
            //    {
            //        pList.Add(p);
            //    }
            //}
            //return pList;

            CSV csv = new CSV();
            return csv.readProducts();
        }


        public string BuyProduct(int user, int product, int amount) {
            //read multiple csv files
            CSV csv = new CSV();
            List<Product> inventory = csv.readInventory(user);
            User foundUser = findUser(user);
            Product foundProduct = findProduct(product);
            List<User> allUsers = csv.readUsers();
            List<Product> allProducts = csv.readProducts();

            // calculate total price
            double totalPrice = foundProduct.Price * amount;
            // if item in stock
            if (foundProduct.Amount - amount >= 0) {
                //if user has enough balance
                if (foundUser.Balance - totalPrice >= 0) {

                    //check if item has been bought before
                    bool itemexists = (from item in inventory
                                       where item.Id == product
                                       select item).Any();

                    if (itemexists) {
                        //update the inventory to update amount of bought product
                        int indexProduct = inventory.FindIndex(x => x.Id == product);
                        inventory[indexProduct].Amount += amount;
                        csv.saveInventoryFromScratch(inventory, user);
                    }
                    else {
                        Product found2 = foundProduct;
                        found2.Amount = amount;
                        List<Product> foundprods = csv.readInventory(user);
                        foundprods.Add(found2);
                        //add new product to inventory
                        csv.saveInventoryFromScratch(foundprods, user);
                    }
                    //update user balance
                    int indexUser = allUsers.FindIndex(x => x.Id == user);
                    allUsers[indexUser].Balance -= totalPrice;
                    csv.updateUser(allUsers);
                    //update shop stock amount of bought product
                    int indexShop = allProducts.FindIndex(x => x.Id == product);
                    allProducts[indexShop].Amount -= amount;
                    csv.updateProduct(allProducts);

                    return "Item has been bought";
                }
                else {
                    return "Balance is too low";
                }
            }
            else {
                return "Item is not in stock";
            }
        }

        // Methods related to users.
        public string Register(string username) {
            
            CSV csv = new CSV();
            List<User> users = csv.readUsers();

            //check if username exists

            bool userExists = (from user in users
                               where user.Username == username
                               select user).Any();

            if (!userExists) {
                //generate password (reverse username)
                char[] passwordArray = username.ToArray();
                Array.Reverse(passwordArray);
                string s = new string(passwordArray);
                //make new user object in csv
                User newUser = new User {
                    Username = username,
                    Password = s,
                    Balance = 50.0
                };
                users.Add(newUser);
                csv.updateUser(users);
                return "your password is : " + s;
            }
            else {
                return "username has already been taken.";
            }
        }

        public int Login(string username, string password) {
            //define id, in frontend login needs to be checked if bigger than 0
            int login = 0;
            //read csv
            CSV csv = new CSV();
            List<User> users = csv.readUsers();

            //check if user exists
            bool exists = (from user in users
                           where user.Username == username && user.Password == password
                           select user).Any();
            if (exists) {
                //set id that is passed to frontend
                login = (from user in users
                         where user.Username == username && user.Password == password
                         select user.Id).First();
            }

            return login;


        }



        public List<Product> GetBoughtProducts(int id) {
            // get inventory of user
            return csv.readInventory(id);
        }

        //find user by id
        public User findUser(int id) {

            CSV csv = new CSV();
            List<User> users = csv.readUsers();
            //find user in list
            User user = (from i in users
                         where i.Id == id
                         select i).First();
            return user;
        }

        //find product by id
        public Product findProduct(int id) {
            CSV csv = new CSV();

            List<Product> products = csv.readProducts();
            //find product in list
            Product product = (from i in products
                               where i.Id == id
                               select i).First();
            return product;
        }
    }
}