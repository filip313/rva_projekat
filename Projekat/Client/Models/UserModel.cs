using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Commands[trenutnaCmd].Redo();
            return CheckUndo();
        }

        public bool Undo()
        {
            if (trenutnaCmd < 0)
            {
                return false;
            }
            Commands[trenutnaCmd].Undo();
            trenutnaCmd--;
            return CheckRedo();
        }

        private bool CheckRedo()
        {
            if (trenutnaCmd + 1 >= Commands.Count || (trenutnaCmd < 0 && Commands.Count == 0))
            {
                return false;
            }
            return true;
        }

        private bool CheckUndo()
        {
            if (trenutnaCmd < 0)
            {
                return false;
            }

            return true;
        }
    }
}
