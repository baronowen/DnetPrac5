using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseShit
{
    class Program
    {
        static void Main(string[] args)
        {
            using (mymodelContainer ctx = new mymodelContainer())
            {
                //Product p1 = new Product { ProductName = "iPod", Price = 99, Amount = 20 };
                //Product p2 = new Product { ProductName = "iPad", Price = 499, Amount = 5 };
                //ctx.ProductSet.Add(p1);
                //ctx.ProductSet.Add(p2);
                //ctx.SaveChanges();

                var products = from p in ctx.ProductSet
                               where p.Price < 100
                               select p;
                foreach (Product p in products)
                    Console.WriteLine("Product met ID {0}, naam {1} en prijs {2}",
                        p.ProductId, p.ProductName, p.Price);
            }
        }
    }
}
