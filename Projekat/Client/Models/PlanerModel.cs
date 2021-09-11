using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Common.Models;
using Client.Connections;


namespace Client.Models
{
    public class PlanerModel
    {
        public BindableCollection<Planner> Planers { get; set; }
        public PlanerServiceConnection connection;
        
        public PlanerModel()
        {
            connection = new PlanerServiceConnection();
            Planers = new BindableCollection<Planner>(connection.planerServiceProxy.GetAllPlaners());
        }
    }
}
