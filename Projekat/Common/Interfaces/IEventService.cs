using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common.Models;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IEventService
    {
        [OperationContract]
        Event AddNewEvent(string naziv, string opis, DateTime pocetak, DateTime kraj, int planerId);
        [OperationContract]
        bool RemoveEvent(Event toRemove);
        [OperationContract]
        bool EditEvent(string naziv, string opis, DateTime pocetak, DateTime kraj, int eventId);
    }
}
