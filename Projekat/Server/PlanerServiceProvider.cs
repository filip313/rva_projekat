using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using DataAccess;

namespace Server
{
    public class PlanerServiceProvider : IPlanerService
    {
        public static SyncConnection sync = new SyncConnection();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("PlanerServiceProvider");
        public int SavePlaner(Planner planer)
        {
            using (var context = new DataContext())
            {
                var tempUser = context.Users.First(x => x.UserId == planer.PlanerCreator.UserId);
                planer.PlanerCreator = tempUser;
                int id;
                try
                {
                    id = context.Planers.Max(x => x.PlannerId);
                    id++;
                }
                catch
                {
                    id = 0;
                }
                planer.PlannerId = id;
                var temp = context.Planers.Add(planer);
                context.SaveChanges();

                Task.Run(() => Ping());

                log.Info($"Novi Planer [ planerId = {temp.PlannerId} ] uspesno dodat u bazu podataka.");

                return temp.PlannerId;
            }
        }

        public IEnumerable<Planner> GetAllPlaners()
        {
            using (var context = new DataContext())
            {
                var ret = context.Planers.Include("PlanerCreator").Include("Events").ToList();

                log.Info("Uspesno dobavljeni Planeri iz baze podataka.");
                
                return ret;
            }
        }

        public bool RemovePlaner(Planner planer)
        {
            using (var context = new DataContext())
            {
                var toRemove = context.Planers.Where(x => x.PlannerId == planer.PlannerId).FirstOrDefault();
                if (toRemove != null)
                {
                    context.Planers.Remove(toRemove);
                    context.SaveChanges();

                    Task.Run(() => Ping());

                    log.Info($"Uspesno izbrisan Planer [ planerId = {toRemove.PlannerId} ] iz baze podataka.");

                    return true;
                }
            }

            log.Error($"Doslo je do greske prilikom pokusaja brisanje Planera [ planerId = {planer.PlannerId} ] iz baze podataka.");
            return false;
        }

        public bool SaveChanges(Planner planer)
        {
            using (var context = new DataContext())
            {
                var toChange = context.Planers.Where(x => x.PlannerId == planer.PlannerId).FirstOrDefault();
                if (toChange != null)
                {
                    toChange.DatumPocetka = planer.DatumPocetka;
                    toChange.DatumZavrsetka = planer.DatumZavrsetka;
                    toChange.Naziv = planer.Naziv;
                    toChange.Opis = planer.Opis;
                    context.SaveChanges();

                    Task.Run(() => Ping());

                    log.Info($"Uspesno izmenjen Planer [ planerId = {toChange.PlannerId} ].");
                    return true;
                }
            }

            log.Error($"Doslo je do greske prilikom pokusaja izmene Planera [ planerId = {planer.PlannerId} ].");

            return false;
        }

        public bool Exists(int planerId)
        {
            using (var context = new DataContext())
            {
                var temp = context.Planers.Where(x => x.PlannerId == planerId).FirstOrDefault();
                if(temp == null)
                {
                    log.Info($"Uspesno nadjen Planer [ planerId = {planerId} ].");
                    return false;
                }

                log.Info($"Trazeni Planer [ planerId = {planerId} ] nije pronadjen.");
                return true;
            }
        }

        private void Ping()
        {
            Thread.Sleep(500);
            lock(new Object())
            {
                foreach(var user in Program.ActiveUsers)
                {
                    sync.Connect(user.UserId);
                    try
                    {
                        sync.proxy.Ping();
                        log.Info($"Uspesno pingovan Korisnik [ userid = {user.UserId} ] za osvezavanje planera.");
                    }
                    catch(Exception e)
                    {
                        log.Error($"Doslo je do greske prilikom pokusaja pingovanja Korisnika [ userId = {user.UserId} ] za osvezavanje planera.", e);
                    }
                }
            }
        }
    }
}
