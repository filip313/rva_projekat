using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Connections;
using Client.Models;

namespace Client.ViewModels
{
    class NewEventViewModel : Screen
    {
        public int PlannerId { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime MinDate { get; set; }
        public EventServiceConnection Connection { get; set; }
        public BindableCollection<EventModel> Events { get; set; }
        public bool IsChange { get; set; }
        public bool IsNew { get; set; }
        public int EventId { get; set; }

        public NewEventViewModel(BindableCollection<EventModel> Events, int plannerId, DateTime min, DateTime max, EventServiceConnection connection)
        {
            this.Events = Events;
            this.PlannerId = plannerId;
            this.Pocetak = DateTime.Now;
            this.Kraj = DateTime.Now;
            this.MaxDate = max;
            this.MinDate = min;
            this.Error = string.Empty;
            this.Connection = connection;
            this.IsChange = false;
            this.IsNew = true;
        }

        public NewEventViewModel(BindableCollection<EventModel>Events, int plannerId, EventServiceConnection connection, EventModel model, DateTime min, DateTime max)
        {
            this.Events = Events;
            this.PlannerId = plannerId;
            this.Connection = connection;
            this.Naziv = model.Event.Naziv;
            this.Opis = model.Event.Opis;
            this.Pocetak = model.Event.DatumVremePocetka;
            this.Kraj = model.Event.DatumVremeZavrsetka;
            this.EventId = model.Event.EventId;
            this.MaxDate = max;
            this.MinDate = min;
            this.IsChange = true;
            this.IsNew = false;
        }

        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public string Error { get; set; }

        public void AddNewEvent()
        {
            if (CheckIfValid())
            {
                var ubacenEvent = Connection.eventServiceProxy.AddNewEvent(Naziv, Opis, Pocetak, Kraj, PlannerId);
                Events.Add(new EventModel(ubacenEvent));
                MessageBox.Show("Uspesno kreiran Event", "Kreiraj novi Event", MessageBoxButton.OK, MessageBoxImage.Information);
                this.TryCloseAsync();
            }

        }


        public void EditEvent()
        {
            if (CheckIfValid())
            {
                if (Connection.eventServiceProxy.EditEvent(Naziv, Opis, Pocetak, Kraj, EventId))
                {
                    var toEdit = Events.Where(x => x.Event.EventId == EventId).FirstOrDefault();
                    toEdit.Event.Naziv = Naziv;
                    toEdit.Event.Opis = Opis;
                    toEdit.Event.DatumVremePocetka = Pocetak;
                    toEdit.Event.DatumVremeZavrsetka = Kraj;
                    toEdit.EventState.CheckState();
                    Events.Refresh();
                }
            }

            this.TryCloseAsync();
        }

        private bool CheckIfValid()
        {
            if (string.IsNullOrEmpty(Naziv) || string.IsNullOrWhiteSpace(Naziv))
            {
                this.Error = "Polje naziv mora biti popunjeno!";
                NotifyOfPropertyChange(() => Error);
                return false;
            }
            if (string.IsNullOrEmpty(Opis) || string.IsNullOrWhiteSpace(Opis))
            {
                this.Error = "Polje opis mora biti popunjeno!";
                NotifyOfPropertyChange(() => Error);
                return false;
            }
            if (Pocetak < MinDate || Pocetak > MaxDate)
            {
                this.Error = "Proverite ispravnost datuma!";
                NotifyOfPropertyChange(() => Error);
                return false;
            }
            if (Kraj < MinDate || Pocetak > MaxDate)
            {
                this.Error = "Proverite ispravnost datuma!";
                NotifyOfPropertyChange(() => Error);
                return false;
            }
            if (Pocetak > Kraj)
            {
                this.Error = "Proverite ispravnost datuma!";
                NotifyOfPropertyChange(() => Error);
                return false;
            }
            this.Error = string.Empty;
            NotifyOfPropertyChange(() => Error);
            return true;
        }
    }
}
