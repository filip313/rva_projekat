using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using System.ServiceModel;

namespace Client
{
    public class LoginServiceConnection
    {
        public ILogin loginProxy;

        public LoginServiceConnection()
        {
            Connect();
        }

        private void Connect()
        {
            var binding = new NetTcpBinding();
            ChannelFactory<ILogin> cf = new ChannelFactory<ILogin>(binding, new EndpointAddress("net.tcp://localhost:6000/LoginServiceProvider"));
            loginProxy = cf.CreateChannel();
        }
    }
}
