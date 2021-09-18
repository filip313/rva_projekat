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
        public AktivanEvent(EventModel model) : base(model)
        {
            BackgroundColor = "#6bd672";
            TekstStanja = "AKTIVAN";
            IsRemovable = false;
            IsEditable = false;
            CheckState();
            log.Info($"Event [ eventId = {Model.Event.EventId} ] je promenio Stanje U Aktivan.");
            ViewModels.LogViewModel.AddLog(DateTime.Now, "INFO", $"Event [ eventId = {Model.Event.EventId} ] je promenio Stanje U Aktivan.");

        }

        public override void CheckState()
        {
            if(Model.Event.DatumVremeZavrsetka < DateTime.Now)
            {
                Model.EventState = new ZavrsenEvent(Model);
            }
        }
    }
}
