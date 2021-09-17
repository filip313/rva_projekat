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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("LoginServisProvider");

        public int Login(string username, string password)
        {
            Console.WriteLine($"{username} : {password} ");
            if(Program.ActiveUsers.Where(x => x.Username == username).FirstOrDefault() != null)
            {
                log.Error("Pokusaj prijavljivanja na vec prijavljen nalog.");

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

                    log.Info($"Korisniki [ {username} ] uspesno prijavljen.");

                    return ret.UserId;
                }
                catch
                {
                    log.Error("Neuspelo prijavljivanje korisnika.");
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

                log.Info("Korisnik uspesno odjavljen.");
                
                return true;
            }
            catch
            {
                log.Error("Doslo je do greske prilikom pokusaja odjavljivana korisnika.");
                return false;
            }

        }

        public string GetUserType(int id)
        {
            try
            {
                var user = Program.ActiveUsers.First(x => x.UserId == id);
                string ret = user.GetType().ToString();

                log.Info("Uspesno dobavljen tip priavljenog korisnika.");

                return ret;
            }
            catch
            {
                log.Error("Doslo je do greske prilikom dovaljanja tipa prijavljenog korisnika.");
                return string.Empty;
            }
        }
    }
}
