using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LogViewModel log;

        public LogViewModel Log
        {
            get { return log; }
            set { log = value; }
        }


        private PlanerViewModel planer;

        public PlanerViewModel Planers
        {
            get { return planer; }
            set { planer = value; NotifyOfPropertyChange(); }
        }


        public ShellViewModel()
        {
        }

        public void OnClose(CancelEventArgs args)
        {
            Planers.connection.loginProxy.Logout(Planers.User.UserId);
            this.TryCloseAsync();
        }
    }
}
