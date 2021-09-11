using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Prototype;

namespace Common.Models
{
    public class Administrator : User
    {
        public Administrator() { }
        public override IPrototype Clone()
        {
            return new Administrator() { Ime = this.Ime, Prezime = this.Prezime, Username = this.Prezime, Email = this.Email, UserId = this.UserId };
        }
    }
}
