using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common.Models;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool AddNewUser(User user);

        [OperationContract]
        User GetActiveUserData(int id);

        [OperationContract]
        bool ChangeUserData(int id, string ime, string prezime, string email);
    }
}
