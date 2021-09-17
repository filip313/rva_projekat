using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using DataAccess;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Server
{
    class Program
    {
        public static List<User> ActiveUsers = new List<User>();
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                context.InitDatabase();
                context.SaveChanges();
            }
            ServiceProvider server = new ServiceProvider();
            Console.ReadLine();
        }
    }
}
