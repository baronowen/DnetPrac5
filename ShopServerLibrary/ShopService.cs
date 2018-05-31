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

        public string BuyProduct(User u, Product p, int amount)
        {
            if(p.Amount == 0)
            {
                return "Product " + p.Name + " is no longer available";
            }
            else if (amount <= p.Amount)
            {
                if(u.Balance >= (p.Price * amount)){
                    u.Balance = u.Balance - (p.Price * amount);
                    p.Amount = p.Amount - amount;
                    // bought product has yet to be added to BoughtProducts

                    return "You have bought " + p.Name + " for €" + (p.Price * amount) + ".\n" +
                        "Your new balanse is €" + u.Balance;
                }
                else
                {
                    return "Your balance is insufficient";
                }
            }
            else
            {
                return p.Name + " is sold out.";
            }
        }

        // Methods related to users.        
        public string Register(string username)
        {
            return "nope";
            //TODO password generation needs to be added.
        }

        public string Login(string username, string password)
        {
            //hard coded stuff that needs to be changed when persistence has been done
            return username == "username" && password == "passworded" ? 
                string.Format("You entered: {0}, {1}", username, password) 
                : "Username and password combination is wrong!";
        }

        //public string GetUserProductsJSON(int id)
        //{
        //    //hard coded user needs to be found using id
        //    User user = new User();
        //    return user.generateJsonFromProducts();
        //}
        //TODO this one too wants to be fixed.
    }
}
