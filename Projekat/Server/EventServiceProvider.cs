using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using DataAccess;

namespace Server
{
    public class EventServiceProvider : IEventService
    {
        public Event AddNewEvent(string naziv, string opis, DateTime pocetak, DateTime kraj, int planerId)
        {
            using (var context = new DataContext())
            {
                var newEvent = new Event() { Opis = opis, Naziv = naziv, DatumVremePocetka = pocetak, DatumVremeZavrsetka = kraj, PlannerId = planerId};

                var ret = context.Events.Add(newEvent);
                context.SaveChanges();

                return ret;
            }
        }

        public bool RemoveEvent(Event toRemove)
        {
            using (var context = new DataContext())
            {
                var temp = context.Events.Where(x => x.EventId == toRemove.EventId).FirstOrDefault();
                if(temp != null)
                {
                    context.Events.Remove(temp);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool EditEvent(string naziv, string opis, DateTime pocetak, DateTime kraj, int eventId)
        {
            using (var context = new DataContext())
            {
                var toEdit = context.Events.Where(x => x.EventId == eventId).FirstOrDefault();
                if(toEdit != null)
                {
                    toEdit.Naziv = naziv;
                    toEdit.Opis = opis;
                    toEdit.DatumVremePocetka = pocetak;
                    toEdit.DatumVremeZavrsetka = kraj;
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}
