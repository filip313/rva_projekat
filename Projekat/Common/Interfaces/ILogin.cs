using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface ILogin
    {
        [OperationContract]
        int Login(string username, string password);

        [OperationContract]
        bool Logout(int id);

        [OperationContract]
        string GetUserType(int id);
    }
}
