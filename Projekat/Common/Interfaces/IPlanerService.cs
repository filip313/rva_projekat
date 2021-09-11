using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using System.ServiceModel;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IPlanerService
    {
        [OperationContract]
        int SavePlaner(Planner planer);

        [OperationContract]
        IEnumerable<Planner> GetAllPlaners();

        [OperationContract]
        bool RemovePlaner(Planner planer);

        [OperationContract]
        bool SaveChanges(Planner planer);


    }
}
