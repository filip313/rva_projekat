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
        public ZakazanEvent(EventModel model) : base( model)
        {
            BackgroundColor = "#fcad46";
            TekstStanja = "ZAKAZAN";
            IsEditable = true;
            IsRemovable = true;
            CheckState();
            log.Info($"Event [ eventId = {Model.Event.EventId} ] je promenio Stanje u Zakazan.");

        }
        public override void CheckState()
        {
            if(Model.Event.DatumVremePocetka < DateTime.Now && Model.Event.DatumVremeZavrsetka > DateTime.Now)
            {
                Model.EventState = new AktivanEvent(Model);
            }
            else if(Model.Event.DatumVremeZavrsetka < DateTime.Now)
            {
                Model.EventState = new ZavrsenEvent(Model);
            } 
        }
    }
}
