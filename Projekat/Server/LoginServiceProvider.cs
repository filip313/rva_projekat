using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common;
using DataAccess;

namespace Server
{
    public class LoginServiceProvider : ILogin
    {
        public int Login(string username, string password)
        {
            Console.WriteLine($"{username} : {password} ");
            if(Program.ActiveUsers.Where(x => x.Username == username).FirstOrDefault() != null)
            {
                return -2;
            }
            using (var context = new DataContext())
            {
                var Users = context.Users.ToList();
                Console.WriteLine(context.Database.Connection.ConnectionString);
                try
                {
                    var ret = Users.First(x => x.Username == username && x.Password == password);
                    Program.ActiveUsers.Add(ret);
                    Console.WriteLine(ret.GetType());
                    return ret.UserId;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public bool Logout(int id)
        {
            try
            {
                var toRemove = Program.ActiveUsers.First(x => x.UserId == id);
                Program.ActiveUsers.Remove(toRemove);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public string GetUserType(int id)
        {
            try
            {
                var user = Program.ActiveUsers.First(x => x.UserId == id);
                string ret = user.GetType().ToString();
                return ret;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
