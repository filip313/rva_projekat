using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Common.Prototype;

namespace Common.Models
{
    [DataContract]
    public class ObicanUser : User
    {
        
        public ObicanUser() { }

        public override IPrototype Clone()
        {
            return new ObicanUser() { Ime = this.Ime, Prezime = this.Prezime, Email = this.Email, Username = this.Username, UserId = this.UserId };
        }
    }
}
