using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShopServerLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShopService" in both code and config file together.
    [ServiceContract]
    public interface IShopService
    {

        // Methods related to products.
        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        string BuyProduct(int u, int p, int amount);



        // Methods related to users.        
        [OperationContract]
        int Login(string username, string password);

        [OperationContract]
        string Register(string username);


        [OperationContract]
        List<Product> GetBoughtProducts(int id);

        [OperationContract]
        User findUser(int id);
    }
}
