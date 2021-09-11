﻿using Caliburn.Micro;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Client.Command;

namespace Client.ViewModels
{
    public class NewPlanerViewModel : Screen
    {
        public UserModel User { get; set; }
        public PlanerModel PlanerModel { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int PlanerId { get; set; }

        public bool IsNew { get; set; }
        public bool IsChange { get; set; }


        public NewPlanerViewModel(UserModel user, PlanerModel planerModel)
        {
            this.User = user;
            this.PlanerModel = planerModel;
            DatumPocetka = DateTime.Now;
            DatumZavrsetka = DateTime.Now;
            this.IsNew = true;
            this.IsChange = false;
        }

        public NewPlanerViewModel(Common.Models.Planner planer, UserModel user, PlanerModel planerModel)
        {
            this.User = user;
            this.PlanerModel = planerModel;
            this.Naziv = planer.Naziv;
            this.Opis = planer.Opis;
            this.DatumPocetka = planer.DatumPocetka;
            this.DatumZavrsetka = planer.DatumZavrsetka;
            this.PlanerId = planer.PlannerId;
            this.IsNew = false;
            this.IsChange = true;
        }

        public void CreateNewPlaner()
        {
            User.AddAndExecute(new NapraviPlaner(DatumPocetka, DatumZavrsetka, Naziv, Opis, User.UserId, PlanerModel));
            
            this.TryCloseAsync();
        }

        public void EditPlaner()
        {
            User.AddAndExecute(new IzmeniPlaner(PlanerId, DatumPocetka, DatumZavrsetka, Naziv, Opis, PlanerModel));

            this.TryCloseAsync();
        }
    }
}