using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Server
{
    class Program
    {
        public static List<User> ActiveUsers = new List<User>();
        static void Main(string[] args)
        {
            ServiceProvider server = new ServiceProvider();
            Console.ReadLine();
        }
    }
}
