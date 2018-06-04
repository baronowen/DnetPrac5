using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShopServerLibrary
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public double Balance { get; set; }

        [DataMember]
        public List<Product> BoughtProducts { get; set; }

        public List<Product> FillBoughtProducts() {
            BoughtProducts = new List<Product>();
            this.BoughtProducts.Add(
                new Product {
                    Name = "Carrot",
                    Amount = 1,
                    Price = 2.50,
                    Id = 1
                });

            return BoughtProducts;
        }
    }
}