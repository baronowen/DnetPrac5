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
                Product p1 = new Product {
                    ProductName = "Carrot",
                    Price = 2.50,
                    Amount = 20 };
                Product p2 = new Product {
                    ProductName = "Apple",
                    Price = 1,
                    Amount = 10 };
                Product p3 = new Product
                {
                    ProductName = "Lettuce",
                    Price = 2.99,
                    Amount = 15
                };
                ctx.ProductSet.Add(p1);
                ctx.ProductSet.Add(p2);
                ctx.ProductSet.Add(p3);
                ctx.SaveChanges();

                var products = from p in ctx.ProductSet
                               select p;
                foreach (Product p in products)
                    Console.WriteLine("Product met ID {0}, naam {1} en prijs {2}",
                        p.ProductId, p.ProductName, p.Price);
            }
        }
    }
}
