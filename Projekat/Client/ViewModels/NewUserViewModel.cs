using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Common;
using Client.Connections;
using System.Windows;

namespace Client.ViewModels
{
    public class NewUserViewModel : Screen
    {
        public IReadOnlyList<Tipovikorisnika> TipoviKorisnika { get; }
        public UserServiceConnection connection;

        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; NotifyOfPropertyChange(); }
        }

        private bool isChange;

        public bool IsChange
        {
            get { return isChange; }
            set { isChange = value; NotifyOfPropertyChange(); }
        }


        public NewUserViewModel()
        {
            TipoviKorisnika = Enum.GetValues(typeof(Tipovikorisnika)).Cast<Tipovikorisnika>().ToList();
            connection = new UserServiceConnection();
            IsNew = true;
            IsChange = false;
        }

        public NewUserViewModel(int id)
        {
            connection = new UserServiceConnection();
            var userData = connection.userServiceProxy.GetActiveUserData(id);
            Ime = userData.Ime;
            Prezime = userData.Prezime;
            Email = userData.Email;
            IsNew = false;
            IsChange = true;
            this.id = id;
        }

        private Tipovikorisnika tipKorisnika;

        public Tipovikorisnika TipKorisnika 
        {
            get { return tipKorisnika; }
            set { tipKorisnika = value; }
        }

        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string  Email { get; set; }

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; NotifyOfPropertyChange(); }
        }



        public void AddNewUser()
        {
            if(CheckIfValid(Username) && CheckIfValid(Password) && CheckIfValid(Ime) && CheckIfValid(Prezime))
            {
                AbstraktnaFabrika.AbstractUserFactory userFactory;
                Error = string.Empty;
                if(TipKorisnika == Tipovikorisnika.Administrator)
                {
                    userFactory = new AbstraktnaFabrika.AdministratroFactory();
                }
                else
                {
                    userFactory = new AbstraktnaFabrika.ObicanUserFactory();
                }

                if (connection.userServiceProxy.AddNewUser(userFactory.CreateUser(Username, Password, Ime, Prezime, Email)))
                {
                    MessageBox.Show("Korisnik uspesno kreiran!", "Create New User", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.TryCloseAsync();
                }
                else
                {
                    MessageBox.Show("Korisnik sa odabranim korisnickim imenom vec postoji!", "Create New User", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return;
            }

            Error = "Polja moraju biti popunjena!";
        }


        public void ChangeUserData()
        {
            if(CheckIfValid(Ime) && CheckIfValid(Prezime) && CheckIfValid(Email))
            { 
                MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da primenite izmene?", "Izmena podataka", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    connection.userServiceProxy.ChangeUserData(id, Ime, Prezime, Email);
                    this.TryCloseAsync();
                }
            }
        }

        private bool CheckIfValid(string data)
        {
            if(string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                return false;
            }

            return true;
        }
    }
}
