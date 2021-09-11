using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common.Interfaces;

namespace Server
{
    public class ServiceProvider
    {
        public ServiceHost loginServiceHost;
        public ServiceHost userServiceHost;
        public ServiceHost planerServiceHost;
        public ServiceHost eventServiceHost;

        public ServiceProvider()
        {
            StartLoginService();
            StartUserService();
            StartPlanerService();
            StartEventService();
        }

        
        private void StartLoginService()
        {
            loginServiceHost = new ServiceHost(typeof(LoginServiceProvider));
            NetTcpBinding binding = new NetTcpBinding();
            loginServiceHost.AddServiceEndpoint(typeof(ILogin), binding, new Uri("net.tcp://localhost:6000/LoginServiceProvider"));
            try{
                loginServiceHost.Open();
                Console.WriteLine("Login Servis Uspesno pokrenut.");
            }
            catch
            {
                Console.WriteLine("Nije moguce otvoriti vezu za Login Servis !");
            }
        }

        private void StartUserService()
        {
            userServiceHost = new ServiceHost(typeof(UserServiceProvider));
            var binding = new NetTcpBinding();
            userServiceHost.AddServiceEndpoint(typeof(IUserService), binding, new Uri("net.tcp://localhost:6001/UserServiceProvider"));
            try
            {
                userServiceHost.Open();
                Console.WriteLine("User Service je uspesno pokrenut!");
            }
            catch
            {
                Console.WriteLine("Nije uspelo pokretanje User Servisa");
            }
        }

        private void StartPlanerService()
        {
            planerServiceHost = new ServiceHost(typeof(PlanerServiceProvider));
            var binding = new NetTcpBinding();
            planerServiceHost.AddServiceEndpoint(typeof(IPlanerService), binding, new Uri("net.tcp://localhost:6002/PlanerServiceProvider"));
            try
            {
                planerServiceHost.Open();
                Console.WriteLine("Planer Service uspesno pokrenut!");
            }
            catch
            {
                Console.WriteLine("Nije uspelo pokretanje Planer Servisa!");
            }
        }

        private void StartEventService()
        {
            eventServiceHost = new ServiceHost(typeof(EventServiceProvider));
            var binding = new NetTcpBinding();
            eventServiceHost.AddServiceEndpoint(typeof(IEventService), binding, new Uri("net.tcp://localhost:6003/EventServiceProvider"));
            try
            {
                eventServiceHost.Open();
                Console.WriteLine("Event Service uspeno pokrenut!");
            }
            catch
            {
                Console.WriteLine("Nije uspelo pokretanje Event Servisa!");
            }
        }
    }
}
