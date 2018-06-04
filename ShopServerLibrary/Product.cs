using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShopServerLibrary
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int Amount { get; set; }



        //Hardcoded product list:
        //Will later be replaced by database.



        public override string ToString() {
            return "Product: " + Id + " " + Name + " " + Price + " " + Amount;
        }
    }
}