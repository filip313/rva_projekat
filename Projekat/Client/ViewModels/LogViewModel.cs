using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Client.Models;

namespace Client.ViewModels
{
    public class LogViewModel : Screen
    {
        private static BindableCollection<LogModel> logs;

        public BindableCollection<LogModel> Logs
        {
            get { return logs; }
            set { logs = value; }
        }

        public LogViewModel()
        {
            Logs = new BindableCollection<LogModel>();
        }

        public static void AddLog(DateTime timeStamp, string level, string message)
        {
            string color = "";
            if (level == "FATAL")
            {
                color = "#d34a4a";
            } else if(level == "ERROR")
            {
                color = "#fcad46";
            }
            else if(level == "INFO")
            {
                color = "#6bd672";
            }
            logs.Insert(0, new LogModel() { TimeStamp = timeStamp, Level = level, Message = message, BackgroundColor = color });
        }
    }
}
