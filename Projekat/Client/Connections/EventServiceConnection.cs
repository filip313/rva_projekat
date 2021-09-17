using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common.Interfaces;

namespace Client.Connections
{
    public class EventServiceConnection
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("EventServiceConnection");

        public IEventService eventServiceProxy;

        public EventServiceConnection()
        {
            Connect();
        }

        private void Connect()
        {
            var binding = new NetTcpBinding();
            ChannelFactory<IEventService> cf = new ChannelFactory<IEventService>(binding, new EndpointAddress("net.tcp://localhost:6003/EventServiceProvider"));
            eventServiceProxy = cf.CreateChannel();
            log.Info("Uspesno povezan na Event servis.");
        }
    }
}
