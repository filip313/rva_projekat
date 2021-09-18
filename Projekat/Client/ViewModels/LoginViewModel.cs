using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Common;

namespace Client.ViewModels
{
    public class LoginViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("LoginViewModel");
        private string _username;

        private LogViewModel LogView;

        public LoginViewModel()
        {
            LogView = new LogViewModel();
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
            }
        }

        private string _password;

        public string Password
        { 
            get { return _password; }
            set { _password = value; }
        }

        private string _error;

        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                NotifyOfPropertyChange();
            }
        }


        public void LoginClick()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrWhiteSpace(Username) || String.IsNullOrEmpty(Password) || String.IsNullOrWhiteSpace(Password))
            {
                Error = "Polja moraju biti popunjena";
            }
            else
            {
                LoginServiceConnection connection = new LoginServiceConnection();
                int id = connection.loginProxy.Login(Username, Password);
                if (id > 0)
                {   
                    Error = String.Empty;
                    IWindowManager manager = new WindowManager();
                    var planer = new PlanerViewModel(new Models.UserModel() { UserId = id }, new Models.PlanerModel(), connection);
                    manager.ShowWindowAsync(new ShellViewModel(planer, LogView));
                    log.Info($"Korisnik [ {Username} ] uspesno ulogovan.");
                    LogViewModel.AddLog(DateTime.Now, "INFO", $"Korisnik [ {Username} ] uspesno ulogovan.");

                    this.TryCloseAsync();
                }
                else if(id == -1)
                {
                    log.Error("Pokusaj logovanja sa ne ispravnim podacima.");
                    Error = "Korisnicko ime ili sifra nisu dobri !";
                }else if(id == -2)
                {
                    log.Error("Pokusaj logovanja na vec ulogovan nalog.");
                    Error = "Korisnik je vec ulogovan!";
                }
                
            }
        }

        public void OnPasswordChanged(PasswordBox source)
        {
            Password = source.Password;
        }

    }
}
