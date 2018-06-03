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

            Customer user = new Customer();

            Product p = new Product();
            ShopService ss = new ShopService();
            Console.WriteLine(ss.GetAllProducts());
            

            Console.WriteLine("\n--------------------------------\n");

            
        }
    }
}
