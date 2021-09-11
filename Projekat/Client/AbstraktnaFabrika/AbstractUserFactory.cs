using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Client.AbstraktnaFabrika
{
    public abstract class AbstractUserFactory
    {
        public abstract User CreateUser(string username, string password, string ime, string prezime, string email);
    }
}
