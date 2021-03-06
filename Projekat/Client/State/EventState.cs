using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Client.Models;
using System.Windows;

namespace Client.State
{
    public abstract class EventState
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("EventState");

        public EventModel Model { get; set; }
        public string TekstStanja { get; set; }
        public abstract void CheckState();
        public string BackgroundColor { get; set; }
        public bool IsEditable { get; set; }
        public bool IsRemovable { get; set; }

        public EventState( EventModel model)
        {
            this.Model = model;
        }
    }
}
