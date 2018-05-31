using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServerLibrary
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public double saldo { get; set; }
        public List<Product> products { get; set; }



        public string generateJsonFromProducts() {
            //hard coded products

            this.products.Add(
                new Product { Name = "wortel",
                    amount = 12,
                    Price = 2.4,
                    Id = 1 };)
            return "je moeder";
        }
    }
}
