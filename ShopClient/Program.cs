using ShopClient.ShopService;
using System;

namespace ShopClient
{
    internal class Program
    {
        private static void Main(string[] args) {
            ShopServiceClient shopProxy = new ShopServiceClient();

            Console.WriteLine("All Products\n");
            foreach (Product p in shopProxy.GetAllProducts()) {
                Console.WriteLine(p.Name);
            }

            //Console.WriteLine("Please enter your name: ");
            //string name = Console.ReadLine();
            //while (true)
            //{
            //    Console.WriteLine("Type a note (or hit enter to quit): ");
            //    string note = Console.ReadLine();
            //    if (string.IsNullOrEmpty(note))
            //    {
            //        break;
            //    }
            //    shopProxy.PostNote(name, note);
            //}
        }
    }
}