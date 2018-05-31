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

            Console.WriteLine("--------------------------------");

            Product p = new Product();
            Console.WriteLine(p.GenerateProducts());

            Console.WriteLine("--------------------------------");            
        }
    }
}
