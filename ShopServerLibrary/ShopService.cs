﻿using DatabaseShit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace ShopServerLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShopService" in both code and config file together.
    public class ShopService : IShopService
    {
        Product p = new Product();

        User u = new User();
        CSV csv = new CSV();

        public List<User> Users { get; set; }





        public void initialize() {
            Generator gen = new Generator();
            Users = gen.GenerateUsers();
            foreach (User user in Users) {
                csv.saveUser(user);
            }
        }
        // Methods related to products.
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
            return p.GenerateProducts();
        }

        public string BuyProduct(User user, Product product, int amount) {
            if (product.Amount == 0) {
                return "Product " + product.Name + " is no longer available";
            }
            else if (amount <= product.Amount) {
                if (user.Balance >= (product.Price * amount)) {

                    user.Balance = user.Balance - (product.Price * amount);
                    product.Amount = product.Amount - amount;

                    if (u.BoughtProducts.Contains(product)) {
                        int index = u.BoughtProducts.FindIndex(a => a.Id == product.Id);
                        u.BoughtProducts[index].Amount++;
                    }
                    else {
                        u.BoughtProducts.Add(new Product {
                            Name = product.Name,
                            Price = product.Price,
                            Amount = amount,
                            Id = product.Id
                        });
                    }
                    return "You have bought " + product.Name + " for €" + (product.Price * amount) + ".\n" +
                        "Your new balance is €" + user.Balance;
                }
                else {
                    return "Your balance is insufficient";
                }
            }
            else {
                return product.Name + " is sold out.";
            }
        }

        // Methods related to users.        
        public string Register(string username) {
            //TODO check if username is already in use

            char[] passwordArray = username.ToArray();
            Array.Reverse(passwordArray);
            string s = new string(passwordArray);

            return s;
        }

        public int Login(string username, string password) {

            int login = 0;
            /*      using (mymodelContainer ctx = new mymodelContainer())
                  {
                      var user = from u in ctx.UserSet
                                 where u.UserName == username &&
                                 u.Password == password
                                 select u;

                      foreach(var u in user)
                      {
                          if(u.UserName == username 
                              && u.Password == password)
                          {
                              login = true;
                          }
                          else
                          {
                              login = false;
                          }
                      }
                  }

              */


            return login;

            //hard coded stuff that needs to be changed when persistence has been done
            //return username == "username" && password == "passworded"
            //    ? string.Format("You entered: {0}, {1}", username, password)
            //    : "Username and password combination is wrong!";
        }

        public List<Product> GetBoughtProducts(/*int id*/) {
            //TODO paramater is needed when database is in use.
            //NOTE dont forget to update service reference.
            return u.FillBoughtProducts();
        }

    }
}
