using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopServerLibrary;
namespace quickTestApp
{
    class Program
    {
        static void Main(string[] args) {

            User user = new User();
            Console.WriteLine(user.generateJsonFromProducts());

            Console.WriteLine("\n--------------------------------\n");

            Product p = new Product();
            ShopService ss = new ShopService();
            Console.WriteLine(ss.GetAllProducts());
            foreach (Product product in p.GenerateProducts())
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("\n--------------------------------\n");

            
        }
    }
}
