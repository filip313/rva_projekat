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
        public UserModel User { get; set; }
        public PlanerModel PlanerModel { get; set; }
        public Common.Models.Planner SelectedPlaner { get; set; }
        LoginServiceConnection connection;
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
            this.TryCloseAsync();
        }

        public PlanerViewModel(UserModel user, PlanerModel planerModel)
        {
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

        public void OnClose(CancelEventArgs args)
        {
            connection.loginProxy.Logout(User.UserId);
            this.TryCloseAsync();
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

            PopuniListu();
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

            PopuniListu();

            PretragaNaziv = string.Empty;
            NotifyOfPropertyChange(() => PretragaNaziv);

            PretragaOpis = string.Empty;
            NotifyOfPropertyChange(() => PretragaOpis);

            PretragaKrajDo = DateTime.MinValue;
            NotifyOfPropertyChange(() => PretragaKrajDo);

            PretragaKrajOd = DateTime.MinValue;
            NotifyOfPropertyChange(() => PretragaKrajOd);

            PretragaPocetakDo = DateTime.MinValue;
            NotifyOfPropertyChange(() => PretragaPocetakDo);

            PretragaPocetakOd = DateTime.MinValue;
            NotifyOfPropertyChange(() => PretragaPocetakOd);

            PlanerModel.Planers.Refresh();
        }

        private void PopuniListu()
        {
            if(temp != null)
            {
                PlanerModel.Planers.Clear();
                foreach (var item in temp)
                {
                    PlanerModel.Planers.Add(item);
                }
            }
        }
    }
}
