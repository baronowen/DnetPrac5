using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShopServerLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in both code and config file together.
    public class ProductService : IProductService
    {
        Product p = new Product();

        public string GetAllProducts()
        {
            return p.GenerateProducts().ToString();
        }

        public string GetProductById(int id)
        {


            return "1 product";
        }
    }
}
