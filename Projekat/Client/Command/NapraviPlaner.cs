///////////////////////////////////////////////////////////
//  NapraviPlaner.cs
//  Implementation of the Class NapraviPlaner
//  Generated by Enterprise Architect
//  Created on:      25-Aug-2021 3:05:59 PM
//  Original author: Filip
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Client.Connections;
using Client.Models;



namespace Client.Command {
	public class NapraviPlaner : PlanerCommand {

        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int UserId { get; set; }
        public int PlanerId { get; set; }
        public NapraviPlaner(DateTime datumPocetka, DateTime datumZavrsetka, string naziv, string opis, int userId, PlanerModel planerModel)
        {
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
            this.Naziv = naziv;
            this.Opis = opis;
            this.UserId = userId;
            this.PlanerModel = planerModel;
		}

		~NapraviPlaner(){

		}

		public override bool Redo(){
            var tempConnection = new UserServiceConnection();
            var temp = tempConnection.userServiceProxy.GetActiveUserData(UserId);
            PrethodniPlaner = new Common.Models.Planner(DatumPocetka, DatumZavrsetka, Naziv, Opis, temp);
            PrethodniPlaner.PlannerId = PlanerId;
            int planerId = PlanerModel.connection.planerServiceProxy.SavePlaner(PrethodniPlaner);
            PrethodniPlaner.PlannerId = planerId;
            PlanerModel.Planers.Add(PrethodniPlaner);
            log.Info($"Uspesno izvrsena komanda kreiranja novog planera [ planerId = {planerId} ].");
            Client.ViewModels.LogViewModel.AddLog(DateTime.Now, "INFO", $"Uspesno izvrsena komanda kreiranja novog planera [ planerId = {planerId} ].");

            return true;
        }

		public override bool Undo(){

            var ret  = PlanerModel.connection.planerServiceProxy.RemovePlaner(PrethodniPlaner);
            if (ret)
            {
                PlanerId = PrethodniPlaner.PlannerId;
                PlanerModel.Planers.Remove(PrethodniPlaner);
                log.Info($"Uspesno izvrseno ponistavanja komande kreiranja novog Planer [ planerId = {PlanerId} ].");
                Client.ViewModels.LogViewModel.AddLog(DateTime.Now, "INFO", $"Uspesno izvrseno ponistavanja komande kreiranja novog Planer [ planerId = {PlanerId} ].");

            }
            else
            {
                log.Error($"Doslo je do greske prilikom ponistavanja komande kreiranja novog Planera [ planerId = {PlanerId} ].");
                Client.ViewModels.LogViewModel.AddLog(DateTime.Now, "ERROR", $"Doslo je do greske prilikom ponistavanja komande kreiranja novog Planera [ planerId = {PlanerId} ].");

            }

            return ret;
        }

	}//end NapraviPlaner

}//end namespace EventPlanner