using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Client.Connections
{
    public class UserServiceConnection
    {
        public IUserService userServiceProxy;

        public UserServiceConnection()
        {
            Connect();
        }

        private void Connect()
        {
            var binding = new NetTcpBinding();
            ChannelFactory<IUserService> cf = new ChannelFactory<IUserService>(binding, new EndpointAddress("net.tcp://localhost:6001/UserServiceProvider"));
            userServiceProxy = cf.CreateChannel();
        }
    }
}
