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
        [OperationContract]
        void PostNote(string from, string note);

        // Methods related to products.
        [OperationContract]
        List<Product> GetAllProducts();

        // Methods related to users.
        [OperationContract]
        string Login(string username, string password);

        [OperationContract]
        string Register(string username);

        [OperationContract]
        string GetSaldo(int id);

        //[OperationContract]
        //string GetUserProductsJSON(int id);
    }
}
