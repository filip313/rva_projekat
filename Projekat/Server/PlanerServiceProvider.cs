﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;
using DataAccess;

namespace Server
{
    public class PlanerServiceProvider : IPlanerService
    {
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

                return temp.PlannerId;
            }
        }

        public IEnumerable<Planner> GetAllPlaners()
        {
            using (var context = new DataContext())
            {
                var ret = context.Planers.Include("PlanerCreator").Include("Events").ToList();
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
                    return true;
                }
            }

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
                    return true;
                }
            }

            return false;
        }
    }
}