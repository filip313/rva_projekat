using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Common.Models;
using Client.Connections;
using Common.Interfaces;
using System.ServiceModel;

namespace Client.Models
{
    public class PlanerModel
    {
        public static BindableCollection<Planner> _planers;

        public BindableCollection<Planner> Planers
        {
            get { return _planers; }
            set { _planers = value; }
        }

        //public  BindableCollection<Planner> Planers { get; set; }
        public PlanerServiceConnection connection;

        public PlanerModel(int id)
        {
            connection = new PlanerServiceConnection();
            Planers = new BindableCollection<Planner>(connection.planerServiceProxy.GetAllPlaners());
        }
    }
}
