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
        public void PostNote(string from, string note)
        {
            Console.WriteLine("{0}: {1}", from, note);
        }

        // Methods related to products.
        public List<Product> GetAllProducts()
        {
            return p.GenerateProducts();
        }

        public string LowerProductAmount(Product p, int amount)
        {
            if(p.Amount == 0)
            {
                return "Product " + p.Name + " is no longer available";
            }
            else if(amount > p.Amount)
            {
                return "You are trying to buy more than there is available of product " 
                    + p.Name + ", please lower the amount you want to buy.";
            }
            else if(amount <= p.Amount)
            {
                p.Amount = p.Amount - amount;
                return "You have successfully bought " + amount + " " + p.Name + ".";
            }

            return "something";
        }

        // Methods related to users.
        public string Register(string username)
        {
            return "nope";
        }

        public string Login(string username, string password)
        {
            //hard coded stuff that needs to be changed when persistence has been done
            return username == "username" && password == "passworded" ? 
                string.Format("You entered: {0}, {1}", username, password) 
                : "Username and password combination is wrong!";
        }

        public string GetBalance(int id)
        {
            //hard coded stuff that needs to be changed when persistence has been done
            return "20";
        }

        //public string GetUserProductsJSON(int id)
        //{
        //    //hard coded user needs to be found using id
        //    User user = new User();
        //    return user.generateJsonFromProducts();
        //}
    }
}
