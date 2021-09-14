using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.Prototype;

namespace Common.Models
{
    [DataContract]
    
    public class Planner : IPrototype
    {

        public Planner()
        {
        }

        private int _plannerId;
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlannerId
        {
            get { return _plannerId; }
            set { _plannerId = value; }
        }

        private string _opis;
        [DataMember]
        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }

        private string _naziv;
        [DataMember]
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        private DateTime _datumPocetka;
        [DataMember]
        public DateTime DatumPocetka
        {
            get { return _datumPocetka; }
            set { _datumPocetka = value; }
        }

        private DateTime _datumZavrestka;
        [DataMember]
        public DateTime DatumZavrsetka
        {
            get { return _datumZavrestka; }
            set { _datumZavrestka = value; }
        }

        private User _planerCreator;
        [DataMember]
        public User PlanerCreator
        {
            get { return _planerCreator; }
            set { _planerCreator = value; }
        }

        [DataMember]
        public List<Event> Events { get; set; }

        public Planner(DateTime datumPocetka, DateTime datumZavrsetka, string naziv, string opis, User user)
        {
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
            this.Naziv = naziv;
            this.Opis = opis;
            this.PlanerCreator = user;
            this.Events = new List<Event>();
        }

        public IPrototype Clone()
        {
            var clonedEvents = new List<Event>();
            foreach(var ev in this.Events)
            {
                clonedEvents.Add(ev.Clone() as Event);
            }
            return new Planner() { Naziv = this.Naziv, Opis = this.Opis, DatumPocetka = this.DatumPocetka, DatumZavrsetka = this.DatumZavrsetka, PlanerCreator = this.PlanerCreator.Clone() as User, Events = clonedEvents };
        }
    }
}
