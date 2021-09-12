using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using System.Windows;

namespace Client.ViewModels
{
    public class PlanerViewModel : Conductor<object>
    {
        public UserModel User { get; set; }
        public PlanerModel PlanerModel { get; set; }
        public Common.Models.Planner SelectedPlaner { get; set; }
        LoginServiceConnection connection;
        IWindowManager manager;

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; NotifyOfPropertyChange(); }
        }

        private bool _canRedo;

        public bool CanRedo
        {
            get { return _canRedo; }
            set { _canRedo = value; NotifyOfPropertyChange(); }
        }
        private bool _canUndo;

        public bool CanUndo
        {
            get { return _canUndo; }
            set { _canUndo = value; NotifyOfPropertyChange(); }
        }

        public void Logout()
        {
            connection.loginProxy.Logout(User.UserId);
            manager.ShowWindowAsync(new LoginViewModel());
            this.TryCloseAsync();
        }

        public PlanerViewModel(UserModel user, PlanerModel planerModel)
        {
            CanUndo = false;
            CanRedo = false;

            PretragaNaziv = string.Empty;
            PretragaOpis = string.Empty;
            this.User = user;
            this.PlanerModel = planerModel;
            connection = new LoginServiceConnection();
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
            var result = MessageBox.Show("Da li ste sigurni da zelite da obrisete " + SelectedPlaner.Naziv + " planer?", "Obrisi Planer", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                CanUndo = User.AddAndExecute(new Client.Command.ObrisiPlaner(SelectedPlaner, PlanerModel));
            }
        }

        public void DuplicatePlaner()
        {
            var result = MessageBox.Show("Da li ste sigurni da zelite da duplirate " + SelectedPlaner.Naziv + " planer?", "Dupliraj Planer", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                CanUndo = User.AddAndExecute(new Client.Command.DuplirajPlaner(SelectedPlaner, PlanerModel));
            }
        }

        public void UndoCommand()
        {
            CanRedo = User.Undo();
        }

        public void RedoCommand()
        {
            CanUndo = User.Redo();
        }

        public void Details()
        {
            ActivateItemAsync(new EventsViewModel(SelectedPlaner.Events, SelectedPlaner.PlannerId, SelectedPlaner.DatumZavrsetka, SelectedPlaner.DatumPocetka));
        }

        public string PretragaOpis { get; set; }
        public string PretragaNaziv { get; set; }
        public DateTime PretragaPocetakOd { get; set; }
        public DateTime PretragaPocetakDo { get; set; }
        public DateTime PretragaKrajOd { get; set; }
        public DateTime PretragaKrajDo { get; set; }

        public BindableCollection<Common.Models.Planner> temp { get; set; }

        public void Pretrazi()
        {
            temp = new BindableCollection<Common.Models.Planner>(PlanerModel.Planers);
            int planerCnt = PlanerModel.Planers.Count;
            for(int i = 0; i < planerCnt; i++)
            {
                if (!PlanerModel.Planers[i].Naziv.Contains(PretragaNaziv))
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
                    continue;
                }
                if (!PlanerModel.Planers[i].Opis.Contains(PretragaOpis))
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
                    continue;
                }
                if(PlanerModel.Planers[i].DatumPocetka < PretragaPocetakOd || PlanerModel.Planers[i].DatumPocetka > PretragaPocetakDo)
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
                    continue;
                }
                if(PlanerModel.Planers[i].DatumZavrsetka < PretragaKrajOd || PlanerModel.Planers[i].DatumZavrsetka > PretragaPocetakDo)
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
                    continue;
                }
            }
        }

        public void PonistiPretragu()
        {
            PlanerModel.Planers = new BindableCollection<Common.Models.Planner>(temp);
        }
    }
}
