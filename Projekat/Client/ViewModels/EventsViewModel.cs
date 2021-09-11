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
    public class EventsViewModel : Screen
    {
        public BindableCollection<EventModel> Events { get; set; }
        public EventModel SelectedEvent { get; set; }
        public int PlanerId { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime MinDate { get; set; }
        public EventServiceConnection Connection { get; set; }

        public EventsViewModel(ICollection<Common.Models.Event> Events, int planerId, DateTime max, DateTime min)
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
                //NotifyOfPropertyChange("tempModel.EventState.IsEditable");
                //NotifyOfPropertyChange(() => tempModel.EventState.IsRemovable);
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
            var result = MessageBox.Show("Da li sigurno zelite da obrisete '" + SelectedEvent.Event.Naziv + "' event?", "Izbrisi Event", MessageBoxButton.YesNoCancel);
            if(result == MessageBoxResult.Yes)
            {
                if (Connection.eventServiceProxy.RemoveEvent(SelectedEvent.Event))
                {
                    Events.Remove(SelectedEvent);
                }
            }
        }
    }
}
