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
        private int _trenutnaCmd;
        private int _userId;


        public UserModel()
        {
            Commands = new List<Command.Command>();
            _trenutnaCmd = -1;
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public bool AddAndExecute(Command.Command komanda)
        {
            _trenutnaCmd++;
            if(_trenutnaCmd == Commands.Count)
            {
                Commands.Add(komanda);
            }
            else
            {
                Commands[_trenutnaCmd] = komanda;
                Commands.RemoveRange(_trenutnaCmd + 1, Commands.Count - _trenutnaCmd - 1);
            }
            _trenutnaCmd--;

            return Redo();

        }

        public bool Redo()
        {
            if (_trenutnaCmd + 1 >= Commands.Count || (_trenutnaCmd < 0 && Commands.Count == 0))
            {
                return false;
            }
            _trenutnaCmd++;
            ViewModels.PlanerViewModel.CanUndo = true;

            return Commands[_trenutnaCmd].Redo();
        }

        public bool Undo()
        {
            if (_trenutnaCmd < 0)
            {
                return false;
            }
            var ret = Commands[_trenutnaCmd].Undo();
            _trenutnaCmd--;
            
            return ret;
        }

        public void RemoveFailedCommand()
        {
            Commands.RemoveAt(_trenutnaCmd);
            _trenutnaCmd--;
        }
    }
}
