using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Client.State;

namespace Client.Models
{
    public class EventModel
    {
        public Event Event { get; set; }
        public EventState EventState { get; set; }

        public EventModel(Event Event)
        {
            this.Event = Event;
            EventState = new ZakazanEvent(this);
        }
    }
}
