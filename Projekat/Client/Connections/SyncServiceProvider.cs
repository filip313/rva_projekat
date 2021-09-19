using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Common.Interfaces;
using Client.Models;
namespace Client.Connections
{
    public class SyncServiceProvider : ISync
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("SyncServiceProvider");

        public void Ping()
        {
            var connection = new PlanerServiceConnection();
            var temp = connection.planerServiceProxy.GetAllPlaners().ToList();
            int planerCnt = PlanerModel._planers.Count();
            int ii = 0;
            for(int i = 0; i < temp.Count(); i++)
            {
                for(ii = 0; ii < planerCnt; ii++)
                {
                    if(temp[i].PlannerId == PlanerModel._planers[ii].PlannerId)
                    {
                        PlanerModel._planers[ii].Naziv= temp[i].Naziv;
                        PlanerModel._planers[ii].Opis= temp[i].Opis;
                        PlanerModel._planers[ii].DatumPocetka= temp[i].DatumPocetka;
                        PlanerModel._planers[ii].DatumZavrsetka= temp[i].DatumZavrsetka;
                        break;
                    }
                }
                if(ii == planerCnt)
                {
                   PlanerModel._planers.Add(temp[i]);
                }
            }

            planerCnt = PlanerModel._planers.Count();
            for(int i = 0; i < planerCnt; i++)
            {
                var tmp = temp.Where(x => x.PlannerId == PlanerModel._planers[i].PlannerId).FirstOrDefault();
                if(tmp == null)
                {
                    PlanerModel._planers.RemoveAt(i);
                    i--;
                    planerCnt--;
                }
            }

            PlanerModel._planers.Refresh();

            log.Info("Osvezena lista planera");
            ViewModels.LogViewModel.AddLog(DateTime.Now, "INFO", "Osvezena lista planera");

        }

        public void PingEvent(int planerId)
        {
            var connection = new EventServiceConnection();
            var temp = connection.eventServiceProxy.GetEvents(planerId).ToList();
            var planer = PlanerModel._planers.Where(x => x.PlannerId == planerId).FirstOrDefault();
            if(planer != null)
            {
                int eventCnt = planer.Events.Count;
                int ii = 0;
                for(int i = 0; i < temp.Count; i++)
                {
                    for(ii = 0; ii < eventCnt; ii++)
                    {
                        if(temp[i].EventId == planer.Events[ii].EventId)
                        {
                            planer.Events[ii].Naziv = temp[i].Naziv;
                            planer.Events[ii].Opis = temp[i].Opis;
                            planer.Events[ii].DatumVremePocetka = temp[i].DatumVremePocetka;
                            planer.Events[ii].DatumVremeZavrsetka = temp[i].DatumVremeZavrsetka;
                            break;
                        }
                    }
                    if(ii == eventCnt)
                    {
                        planer.Events.Add(temp[i]);
                    }
                }

                eventCnt = planer.Events.Count;
                for(int i = 0; i < eventCnt; i++)
                {
                    var tmp = temp.Where(x => x.EventId == planer.Events[i].EventId).FirstOrDefault();
                    if(tmp == null)
                    {
                        planer.Events.RemoveAt(i);
                        i--;
                        eventCnt--;
                    }
                }

                if(PlanerModel._planers != null)
                {
                    PlanerModel._planers.Refresh();
                }
                if(ViewModels.EventViewModel._events != null)
                {
                    ViewModels.EventViewModel._events.Refresh();
                }

                log.Info("Osvezeni planeri");
                ViewModels.LogViewModel.AddLog(DateTime.Now, "INFO", "Osvezeni Eventovi");

            }
        }
    }
}
