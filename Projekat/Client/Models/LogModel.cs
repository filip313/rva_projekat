using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class LogModel
    {
        public DateTime TimeStamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string BackgroundColor { get; set; }

    }
}
