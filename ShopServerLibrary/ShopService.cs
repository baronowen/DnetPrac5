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

        public List<Product> GetAllProducts()
        {
            return p.GenerateProducts();
        }
    }
}
