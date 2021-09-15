using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
namespace Server
{
    public class SyncConnection
    {
        public ISync proxy;

        public SyncConnection()
        {
            
        }

        public void Connect(int id)
        {
            int port = 7000 + id;

            string address = $"net.tcp://localhost:{port}/Sync";
            var binding = new NetTcpBinding();
            ChannelFactory<ISync> cf = new ChannelFactory<ISync>(binding, new EndpointAddress(address));
            proxy = cf.CreateChannel();
        }
    }
}
