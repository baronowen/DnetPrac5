using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopServerLibrary
{
    public class User
    {
       

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Saldo { get; set; }
        //cant be public, why we will never know??????????????????
        List<Product> UserProducts = new List<Product>();

        

        public string generateJsonFromProducts() {
            //hard coded products

            this.UserProducts.Add(
                new Product {
                    Name = "carrot",
                    Amount = 12,
                    Price = 2.4,
                    Id = 1
                });

            this.UserProducts.Add(
           new Product {
               Name = "pear",
               Amount = 12,
               Price = 2.4,
               Id = 2
           });
            this.UserProducts.Add(
            new Product {
                Name = "papaya",
                Amount = 12,
                Price = 2.4,
                Id = 3
            });


            var json = JsonConvert.SerializeObject(this.UserProducts);
            return json;
        }
    }
}
