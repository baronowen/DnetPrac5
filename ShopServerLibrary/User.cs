
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopServerLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        //cant be public, why we will never know??????????????????
        public List<Product> BoughtProducts = new List<Product>();

        }
    }
}
