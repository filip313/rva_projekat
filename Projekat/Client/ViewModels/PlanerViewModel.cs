using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using System.Windows;
using Client.Connections;

namespace Client.ViewModels
{
    public class PlanerViewModel : Conductor<object>
    {
        public UserModel User { get; set; }
        public PlanerModel PlanerModel { get; set; }
        public Common.Models.Planner SelectedPlaner { get; set; }
        LoginServiceConnection connection;
        public Sync server;
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
            CanPonisti = false;
            PretragaNaziv = string.Empty;
            PretragaOpis = string.Empty;
            this.User = user;
            this.PlanerModel = planerModel;
            connection = new LoginServiceConnection();
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
                User.AddAndExecute(new Client.Command.DuplirajPlaner(SelectedPlaner, PlanerModel));
            }
        }

        public void UndoCommand()
        {
            bool uspeh = User.Undo();
            if (!uspeh)
            {
                MessageBox.Show("Neuspesno ponistavanje komande", "Undo error", MessageBoxButton.OK);
            }
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
        public bool CanPonisti { get; set; }

        public List<Common.Models.Planner> temp { get; set; }

        public void Pretrazi()
        {
            temp = new List<Common.Models.Planner>();
            foreach(var item in PlanerModel.Planers)
            {
                temp.Add(item);
            }
            int planerCnt = PlanerModel.Planers.Count;
            for(int i = 0; i < planerCnt; i++)
            {
                if (!PlanerModel.Planers[i].Naziv.Contains(PretragaNaziv))
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
            CanPonisti = true;
                    continue;
                }
                if (!PlanerModel.Planers[i].Opis.Contains(PretragaOpis))
                {
                    PlanerModel.Planers.RemoveAt(i);
                    i--;
                    planerCnt--;
            CanPonisti = true;
                    continue;
                }
                if(PretragaPocetakOd != DateTime.MinValue)
                {
                    if(PlanerModel.Planers[i].DatumPocetka < PretragaPocetakOd)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
            CanPonisti = true;
                        continue;
                    }
                }
                if(PretragaPocetakDo != DateTime.MinValue)
                {
                    if(PlanerModel.Planers[i].DatumPocetka > PretragaPocetakDo)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
            CanPonisti = true;
                        continue;
                    }
                }
                if (PretragaKrajOd != DateTime.MinValue)
                {
                    if(PlanerModel.Planers[i].DatumZavrsetka < PretragaKrajOd)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
            CanPonisti = true;
                        continue;
                    }
                }
                if (PretragaKrajDo != DateTime.MinValue)
                {
                    if(PlanerModel.Planers[i].DatumZavrsetka > PretragaKrajDo)
                    {
                        PlanerModel.Planers.RemoveAt(i);
                        i--;
                        planerCnt--;
            CanPonisti = true;
                        continue;
                    }
                }
            }
            NotifyOfPropertyChange(() => CanPonisti);
        }

        public void PonistiPretragu()
        {
            CanPonisti = false;
            NotifyOfPropertyChange(() => CanPonisti);
            foreach(var item in temp)
            {
                if(PlanerModel.Planers.Where(x => x.PlannerId == item.PlannerId).FirstOrDefault() == null)
                {
                    PlanerModel.Planers.Add(item);
                }
            }
            PlanerModel.Planers.Refresh();
        }
    }
}
