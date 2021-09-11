using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Client.AbstraktnaFabrika
{
    public class AdministratroFactory : AbstractUserFactory
    {
        public override User CreateUser(string username, string password, string ime, string prezime, string email)
        {
            return new Administrator() { Username = username, Password = password, Ime = ime, Prezime = prezime, Email = email };
        }
    }
}
