using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.State;
using System.Windows;
using Client.Connections;

namespace Client.ViewModels
{
    public class EventViewModel : Screen
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("EventViewModel");

        public static BindableCollection<EventModel> _events;
        public BindableCollection<EventModel> Events
        {
            get { return _events; }
            set { _events = value; }
        }
        public EventModel SelectedEvent { get; set; }
        public int PlanerId { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime MinDate { get; set; }
        public EventServiceConnection Connection { get; set; }

        public EventViewModel(ICollection<Common.Models.Event> Events, int planerId, DateTime max, DateTime min)
        {
            LoadData(Events);
            this.PlanerId = planerId;
            this.MaxDate = max;
            this.MinDate = min;
            this.Connection = new EventServiceConnection();
        }

        public void AddNewEvent()
        {
            WindowManager manager = new WindowManager();
            manager.ShowWindowAsync(new NewEventViewModel(Events, PlanerId, MinDate, MaxDate, Connection));
        }

        private void LoadData(ICollection<Common.Models.Event> Events)
        {
            var temp = new List<EventModel>();
            foreach(var item in Events)
            {
                var tempModel = new EventModel(item);
                tempModel.EventState.CheckState();
                temp.Add(tempModel);
            }

            this.Events = new BindableCollection<EventModel>(temp);
        }

        public void EditEvent()
        {
            new WindowManager().ShowWindowAsync(new NewEventViewModel(Events, PlanerId, Connection, SelectedEvent, MinDate, MaxDate));
        }

        public void RemoveEvent()
        {
            var result = MessageBox.Show("Da li sigurno zelite  odabrisete '" + SelectedEvent.Event.Naziv + "' event?", "Izbrisi Event", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                if (Connection.eventServiceProxy.RemoveEvent(SelectedEvent.Event))
                {
                    Events.Remove(SelectedEvent);
                    log.Info($"Event [ eventId = {SelectedEvent.Event.EventId} ] uspesno obrisan.");
                }
                else
                {
                    log.Error($"Doslo je do greske prilikom pokusaja brisanja Eventa [ eventId = {SelectedEvent.Event.EventId} ].");
                    MessageBox.Show("NIJE moguce obrisati event (event je obrisan)!", "Izbrisi Event Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
