using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Common.Models;

namespace Client.State
{
    public class ZavrsenEvent : EventState
    {
        public ZavrsenEvent(EventModel model) : base(model)
        {
            BackgroundColor = "#d34a4a";
            TekstStanja = "ZAVRSEN";
            IsEditable = false;
            IsRemovable = false;
        }

        public override void CheckState() { }
    }
}
