using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common.Interfaces;

namespace Client.Connections
{
    public class Sync
    {
        public ServiceHost syncServiceHost;

        public Sync(int id)
        {
            StartSyncService(id);
        }

        public void StartSyncService(int id)
        {
            int port = 7000 + id;

            string address = $"net.tcp://localhost:{port}/Sync";
            syncServiceHost = new ServiceHost(typeof(SyncServiceProvider));
            var binding = new NetTcpBinding();
            syncServiceHost.AddServiceEndpoint(typeof(ISync), binding, new Uri(address));
            try
            {
                syncServiceHost.Open();
            }
            catch
            {

            }
        }
    }
}
