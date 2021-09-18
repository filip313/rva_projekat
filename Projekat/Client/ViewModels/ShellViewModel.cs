using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Connections;
using System.Windows;

namespace Client.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        public PlanerViewModel PlanerView { get; set; }
        public EventViewModel EventView { get; set; }

        public ShellViewModel(PlanerViewModel planer, EventViewModel Event)
        {
            ActivateItemAsync(planer);
        }

        public void LoadEvents()
        {
            ActivateItemAsync(EventView);
        }
        public void LoadPlaners()
        {
            ActivateItemAsync(PlanerView);
        }
    }
}
