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
    public class Event : IPrototype 
    {
        private DateTime _datumVremePocetka;

        [DataMember]
        public DateTime DatumVremePocetka
        {
            get { return _datumVremePocetka; }
            set { _datumVremePocetka = value; }
        }

        private DateTime _datumVremeZavrsetka;

        [DataMember]
        public DateTime DatumVremeZavrsetka
        {
            get { return _datumVremeZavrsetka; }
            set { _datumVremeZavrsetka = value; }
        }

        private int _eventId;

        [DataMember]
        public int EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }

        private string _naziv;

        [DataMember]
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        private string _opis;

        [DataMember]
        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }
        [DataMember]
        [ForeignKey("Planner_PlannerId")]
        public int PlannerId { get; set; }
        [IgnoreDataMember]
        public  Planner Planner_PlannerId { get; set; }

        public Event() { }

        public IPrototype Clone()
        {
            return new Event() { Naziv = this.Naziv, DatumVremePocetka = this.DatumVremePocetka, DatumVremeZavrsetka = this.DatumVremeZavrsetka, Opis = this.Opis };
        }
    }
}
