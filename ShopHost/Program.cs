using ShopServerLibrary;
using System;
using System.ServiceModel;

namespace ShopHost
{
    internal class Program
    {
        private static void Main(string[] args) {
            // ShopService ss = new ShopService();
            //ss.initialize();
            using (ServiceHost host = new ServiceHost(typeof(ShopService))) {
                host.Open();
                Console.WriteLine("Service ready");
                Console.ReadKey();
            }
        }
    }
}