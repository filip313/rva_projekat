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
        private string _username;

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
                    manager.ShowWindowAsync(new PlanerViewModel(new Models.UserModel() { UserId = id }, new Models.PlanerModel()));
                    this.TryCloseAsync();
                }
                else if(id == -1)
                {
                    Error = "Korisnicko ime ili sifra nisu dobri !";
                }else if(id == -2)
                {
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
