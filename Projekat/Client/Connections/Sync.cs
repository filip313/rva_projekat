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
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("Sync");


        public Sync(int id)
        {
            StartSyncService(id);
        }

        private void StartSyncService(int id)
        {
            int port = 7000 + id;

            string address = $"net.tcp://localhost:{port}/Sync";
            syncServiceHost = new ServiceHost(typeof(SyncServiceProvider));
            var binding = new NetTcpBinding();
            syncServiceHost.AddServiceEndpoint(typeof(ISync), binding, new Uri(address));
            try
            {
                syncServiceHost.Open();
                log.Info("Uspesno pokrenut Sync servis");
                ViewModels.LogViewModel.AddLog(DateTime.Now, "INFO", "Uspesno pokrenut Sync servis");
            }
            catch (Exception e)
            {
                log.Fatal("Doslo je do greske prilikom pokretanja Sync servisa.", e);
                ViewModels.LogViewModel.AddLog(DateTime.Now, "FATAL", "Doslo je do greske prilikom pokretanja Sync servisa.\n" + e.Message);
            }
        }
    }
}
