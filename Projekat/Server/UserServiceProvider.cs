using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using Common;
using DataAccess;

namespace Server
{
    public class UserServiceProvider : IUserService
    {
        public bool AddNewUser(User user)
        {
            using(var context = new DataContext())
            {
                try
                {
                    context.Users.First(x => x.Username == user.Username);
                    return false;
                }
                catch
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            return true;
        }

        public User GetActiveUserData(int id)
        {
            User temp = Program.ActiveUsers.First(x => x.UserId == id);
            User ret;
            if(temp.GetType() == typeof(Administrator))
            {
                ret = new Administrator() { UserId = temp.UserId, Ime = temp.Ime, Prezime = temp.Prezime, Email = temp.Email, Username = temp.Username };
            }
            else
            {
                ret = new ObicanUser() { UserId = temp.UserId, Ime = temp.Ime, Prezime = temp.Prezime, Email = temp.Email, Username = temp.Username};
            }
            return ret.Clone() as User;
        }

        public bool ChangeUserData(int id , string ime, string prezime, string email)
        {
            using (var context = new DataContext())
            {
                try
                {
                    var user = context.Users.First(x => x.UserId == id);
                    user.Ime = ime;
                    user.Prezime = prezime;
                    user.Email = email;
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }

            try
            {
                var user = Program.ActiveUsers.First(x => x.UserId == id);
                user.Ime = ime;
                user.Prezime = prezime;
                user.Email = email;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
