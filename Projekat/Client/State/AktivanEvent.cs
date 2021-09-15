using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Client.Models;


namespace Client.State
{
    public class AktivanEvent :EventState
    {
        public AktivanEvent(Event Event, EventModel model) : base(Event, model)
        {
            BackgroundColor = "#6bd672";
            TekstStanja = "AKTIVAN";
            IsRemovable = false;
            IsEditable = false;
            CheckState();
        }

        public override void CheckState()
        {
            if(Event.DatumVremeZavrsetka < DateTime.Now)
            {
                Model.EventState = new ZavrsenEvent(Event, Model);
            }
        }
    }
}
