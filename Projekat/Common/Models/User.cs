using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Prototype;

namespace Common.Models
{ 
    [KnownType(typeof(ObicanUser))]
    [KnownType(typeof(Administrator))]
    [DataContract]
    public abstract class User : IPrototype
    {

        private int _userId;
        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _username;

        [DataMember]
        [Required]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        [DataMember]
        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _ime;
        [DataMember]
        [Required]
        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }

        private string _prezime;
        [DataMember]
        [Required]
        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }

        private string _email;
        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _fullName;
        [IgnoreDataMember]
        public string FullName
        {
            get { return $"{Ime} {Prezime}"; }
            set { _fullName = value; }
        }


        public User() { }

        public abstract IPrototype Clone();
    }
}
