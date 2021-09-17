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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("ServiceProvider");
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
                log.Info("Login servis uspesno podignut.");
            }
            catch(Exception e)
            {
                log.Fatal("Podizanje Login servisa nije uspelo.", e);
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
                log.Info("User servis uspesno podignut");
            }
            catch(Exception e)
            {
                log.Fatal("Podizanje User servisa nije uspelo.", e);
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
                log.Info("Podzianje Planer servisa uspesno.");
            }
            catch(Exception e)
            {
                log.Fatal("Nije uspelo podizanje Planer servisa", e);
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
                log.Info("Event servis uspesno podignut");
            }
            catch(Exception e)
            {
                log.Fatal("Nije uspelo pokretanje Event servisa.", e);
                Console.WriteLine("Nije uspelo pokretanje Event Servisa!");
            }
        }
    }
}
