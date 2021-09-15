using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Client.Models
{
    
    public class UserModel 
    {
        public List<Command.Command> Commands;
        private int trenutnaCmd;
        private int _userId;


        public UserModel()
        {
            Commands = new List<Command.Command>();
            trenutnaCmd = -1;
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public bool AddAndExecute(Command.Command komanda)
        {
            trenutnaCmd++;
            if(trenutnaCmd == Commands.Count)
            {
                Commands.Add(komanda);
            }
            else
            {
                Commands[trenutnaCmd] = komanda;
                Commands.RemoveRange(trenutnaCmd + 1, Commands.Count - trenutnaCmd - 1);
            }
            trenutnaCmd--;

            return Redo();

        }

        public bool Redo()
        {
            if (trenutnaCmd + 1 >= Commands.Count || (trenutnaCmd < 0 && Commands.Count == 0))
            {
                return false;
            }
            trenutnaCmd++;
            ViewModels.PlanerViewModel.CanUndo = true;

            return Commands[trenutnaCmd].Redo();
        }

        public bool Undo()
        {
            if (trenutnaCmd < 0)
            {
                return false;
            }
            var ret = Commands[trenutnaCmd].Undo();
            trenutnaCmd--;
            
            return ret;
        }

        public void RemoveFailedCommand()
        {
            Commands.RemoveAt(trenutnaCmd);
            trenutnaCmd--;
        }
    }
}
