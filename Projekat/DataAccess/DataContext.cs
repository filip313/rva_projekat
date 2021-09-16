using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;


namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Planner> Planers { get; set; }

        public void InitDatabase()
        {
            Database.CreateIfNotExists();

            var admin = new Administrator() { Username = "admin", Password = "admin", Ime = "Nikola", Prezime = "Markovic", Email = "admin@google.com" };
            var planer = new Planner() { Naziv = "test", Opis = "test", DatumPocetka = DateTime.Parse("9/19/2021"), DatumZavrsetka = DateTime.Parse("9/30/2021"), PlanerCreator = admin, PlannerId = 1 };
            var Event = new Event() { Naziv = "test", Opis = "test", DatumVremePocetka = DateTime.Parse("9/20/2021 5:00:00PM"), DatumVremeZavrsetka = DateTime.Parse("9/28/2021 6:00:00PM"), PlannerId = 1 };
            if (Users.Count<User>() == 0)
            {
                Users.Add(admin);
            }
            
            if(Events.Count<Event>()  == 0)
            {
                Events.Add(Event);
            }
            if(Planers.Count<Planner>() == 0)
            {
                Planers.Add(planer);
            }
        }
    }
}
