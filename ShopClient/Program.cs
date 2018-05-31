using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopClient.ShopService;

namespace ShopClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopServiceClient shopProxy = new ShopServiceClient();

            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Type a note (or hit enter to quit): ");
                string note = Console.ReadLine();
                if (string.IsNullOrEmpty(note))
                {
                    break;
                }
                shopProxy.PostNote(name, note);
            }
        }
    }
}
