using DatabaseShit;
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
        public List<Product> Products { get; set; }




        /*  public void initialize() {
              Generator gen = new Generator();
              Users = gen.GenerateUsers();
              foreach (User user in Users) {
                  csv.saveUser(user);
              }
              Products = gen.GenerateProducts();
              foreach (Product p in Products) {
                  csv.saveProduct(p);
              }
          }
          */
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

            CSV csv = new CSV();
            return csv.readProducts();
        }

        public string BuyProduct(int user, int product, int amount) {
            CSV csv = new CSV();
            List<Product> inventory = csv.readInventory(user);
            User user = findUser(user);
            bool itemexists = (from item in inventory
                               where item.Id == product
                               select item).Any();
            if (itemexists) {
                int indexProduct = inventory.FindIndex(x => x.Id == product);
                inventory[indexProduct].Amount += amount;
                csv.saveInventoryFromScratch(inventory, user);
            }
            else {
                csv.saveInventory(product, user, amount);
            }


        }

        // Methods related to users.        
        public string Register(string username) {
            //TODO check if username is already in use
            CSV csv = new CSV();
            List<User> users = csv.readUsers();

            bool userExists = (from user in users
                               where user.Username == username
                               select user).Any();

            if (!userExists) {
                char[] passwordArray = username.ToArray();
                Array.Reverse(passwordArray);
                string s = new string(passwordArray);
                User newUser = new User {
                    Username = username,
                    Password = s,
                    Balance = 50.0
                };
                csv.saveUser(newUser);
                return "your password is : " + s;

            }
            else {
                return "username has already been taken.";
            }
        }

        public int Login(string username, string password) {

            int login = 0;
            CSV csv = new CSV();
            List<User> users = csv.readUsers();
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

            bool exists = (from user in users
                           where user.Username == username && user.Password == password
                           select user).Any();
            if (exists) {
                login = (from user in users
                         where user.Username == username && user.Password == password
                         select user.Id).First();
            }

            return login;

            //hard coded stuff that needs to be changed when persistence has been done
            //return username == "username" && password == "passworded"
            //    ? string.Format("You entered: {0}, {1}", username, password)
            //    : "Username and password combination is wrong!";
        }

        //TODO extra function that gets the user id based on username and password

        public List<Product> GetBoughtProducts(/*int id*/) {
            //TODO paramater is needed when database is in use.
            //NOTE dont forget to update service reference.
            return u.FillBoughtProducts();
        }
        public User findUser(int id) {
            CSV csv = new CSV();
            List<User> users = csv.readUsers();
            User user = (from i in users
                         where i.Id == id
                         select i).First();
            return user;
        }
        public Product findProduct(int id) {
            CSV csv = new CSV();
            List<Product> products = csv.readProducts();
            Product product = (from i in products
                               where i.Id == id
                               select i).First();
            return product;
        }
    }
}
