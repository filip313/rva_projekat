using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Client.Models;

namespace Client.State
{
    public class ZakazanEvent : EventState
    {
        public ZakazanEvent(Event Event, EventModel model) : base(Event, model)
        {
            BackgroundColor = "Orange";
            TekstStanja = "ZAKAZAN";
            IsEditable = true;
            IsRemovable = true;
            CheckState();
        }
        public override void CheckState()
        {
            if(Event.DatumVremePocetka < DateTime.Now && Event.DatumVremeZavrsetka > DateTime.Now)
            {
                Model.EventState = new AktivanEvent(Event, Model);
            }
            else if(Event.DatumVremeZavrsetka < DateTime.Now)
            {
                Model.EventState = new ZavrsenEvent(Event, Model);
            } 
        }
    }
}
