using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using System.Windows;
using Client.Connections;
using System.Threading;
using System.ComponentModel;

namespace Client.ViewModels
{
    public class PlanerViewModel : Conductor<object>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PlanerViewModel");
        public ShellViewModel Shell { get; set; }


        public UserModel User { get; set; }
        public PlanerModel PlanerModel { get; set; }
        public Common.Models.Planner SelectedPlaner { get; set; }
        public LoginServiceConnection connection;
        public Sync server;
        IWindowManager manager;

        private bool _isAdmin;

        private static bool _canUndo;

        public static bool CanUndo
        {
            get { return _canUndo; }
            set { _canUndo = value; }
        }


        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; NotifyOfPropertyChange(); }
        }

        public void Logout()
        {
            connection.loginProxy.Logout(User.UserId);
            manager.ShowWindowAsync(new LoginViewModel());
            log.Info("Korisnik se uspesno odjavio sa sistema.");
            Shell.TryCloseAsync();
        }

        public PlanerViewModel(UserModel user, PlanerModel planerModel, LoginServiceConnection connection, ShellViewModel shell)
        {
            this.Shell = shell;
            Pretraga = new Pretraga();
            this.User = user;
            this.PlanerModel = planerModel;
            this.connection = connection;
            server = new Sync(user.UserId);
            manager = new WindowManager();
            string tmp = connection.loginProxy.GetUserType(user.UserId);
            if (tmp == "Common.Models.Administrator")
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }
        }

        public void AddNewUser()
        {
            manager.ShowWindowAsync(new NewUserViewModel());
        }

        public void ChangeUserData()
        {
            manager.ShowWindowAsync(new NewUserViewModel(User.UserId));
        }

        public void CreatePlan()
        {
            manager.ShowWindowAsync(new NewPlanerViewModel(User, PlanerModel));
        }

        public void EditPlaner()
        {
            manager.ShowWindowAsync(new NewPlanerViewModel(SelectedPlaner, User, PlanerModel));
        }

        public void DeletePlaner()
        {
            var result = MessageBox.Show("Da li ste sigurni da zelite da obrisete " + SelectedPlaner.Naziv + " planer?", "Obrisi Planer", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                bool uspeh = User.AddAndExecute(new Client.Command.ObrisiPlaner(SelectedPlaner, PlanerModel));
                if (!uspeh)
                {
                    User.RemoveFailedCommand();

                    MessageBox.Show("Brisanje planera NIJE uspelo (planer je vec obrisan)!", "Brisanje planera", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void DuplicatePlaner()
        {
            var result = MessageBox.Show("Da li ste sigurni da zelite da duplirate " + SelectedPlaner.Naziv + " planer?", "Dupliraj Planer", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                bool uspeh = User.AddAndExecute(new Client.Command.DuplirajPlaner(SelectedPlaner, PlanerModel));
                if (!uspeh)
                {
                    User.RemoveFailedCommand();
                    MessageBox.Show("Nije moguce dupliratri planer (trazeni planer NE postoji u bazi podataka)!", "Dupliraj planer error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void UndoCommand()
        {
            bool uspeh = User.Undo();
            
        }

        public void RedoCommand()
        {
            bool uspeh = User.Redo();
            
        }

        public void Details()
        {
            ActivateItemAsync(new EventViewModel(SelectedPlaner.Events, SelectedPlaner.PlannerId, SelectedPlaner.DatumZavrsetka, SelectedPlaner.DatumPocetka));
        }

        public Pretraga Pretraga { get; set; }
        public bool CanPonisti { get; set; }


        public void Pretrazi()
        {

            CanPonisti = Pretraga.Pretrazi(PlanerModel);
            NotifyOfPropertyChange(() => CanPonisti);
        }

        public void PonistiPretragu()
        {
            CanPonisti = Pretraga.PonistiPretragu(PlanerModel);
            NotifyOfPropertyChange(() => CanPonisti);

            NotifyOfPropertyChange(() => Pretraga.PretragaNaziv);

            NotifyOfPropertyChange(() => Pretraga.PretragaOpis);

            NotifyOfPropertyChange(() => Pretraga.PretragaKrajDo);

            NotifyOfPropertyChange(() => Pretraga.PretragaKrajOd);

            NotifyOfPropertyChange(() => Pretraga.PretragaPocetakDo);

            NotifyOfPropertyChange(() => Pretraga.PretragaPocetakOd);

            PlanerModel.Planers.Refresh();
        }
    }
}
