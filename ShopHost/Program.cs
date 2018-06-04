using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ShopServerLibrary;

namespace ShopHost
{
    class Program
    {
        static void Main(string[] args) {
            ShopService ss = new ShopService();
            ss.initialize();
            using (ServiceHost host = new ServiceHost(typeof(ShopService))) {

                host.Open();
                Console.WriteLine("Service ready");
                Console.ReadKey();
            }
        }
    }
}
