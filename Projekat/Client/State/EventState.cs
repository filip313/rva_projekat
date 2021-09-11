using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Client.Models;
using System.Windows;

namespace Client.State
{
    public abstract class EventState
    {
        public Event Event { get; set; }
        public EventModel Model { get; set; }
        public string TekstStanja { get; set; }
        public abstract void CheckState();
        public string BackgroundColor { get; set; }
        public bool IsEditable { get; set; }
        public bool IsRemovable { get; set; }

        public EventState(Event Event, EventModel model)
        {
            this.Event = Event;
            this.Model = model;
        }
    }
}
