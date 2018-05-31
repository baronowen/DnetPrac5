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
    }
}
