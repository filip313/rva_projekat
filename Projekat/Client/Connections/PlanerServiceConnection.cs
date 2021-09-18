using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common.Interfaces;

namespace Client.Connections
{
    public class PlanerServiceConnection
    {
        public IPlanerService planerServiceProxy;
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("PlanerServiceConnection");

        public PlanerServiceConnection()
        {
            Connect();
        }

        private void Connect()
        {
            var binding = new NetTcpBinding();
            ChannelFactory<IPlanerService> cf = new ChannelFactory<IPlanerService>(binding, new EndpointAddress("net.tcp://localhost:6002/PlanerServiceProvider"));
            planerServiceProxy = cf.CreateChannel();
            log.Info("Uspesno povezan na Planer servis.");
            ViewModels.LogViewModel.AddLog(DateTime.Now, "INFO", "Uspesno povezan na Planer servis.");

        }
    }
}
