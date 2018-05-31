using System.Collections.Generic;
using System.ServiceModel;

namespace ShopServerLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string login(string username, string password);

        [OperationContract]
        string Register(string username);

        [OperationContract]
        string getsaldo(int id);

        [OperationContract]
        string GetUserProductsJSON(int id);
       

    }
}