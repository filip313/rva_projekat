///////////////////////////////////////////////////////////
//  IzmeniPlaner.cs
//  Implementation of the Class IzmeniPlaner
//  Generated by Enterprise Architect
//  Created on:      25-Aug-2021 3:06:00 PM
//  Original author: Filip
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Common.Models;
using Client.Models;



namespace Client.Command
{
	public class IzmeniPlaner : PlanerCommand {

        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public int PlanerId { get; set; }

        public IzmeniPlaner(int planerId, DateTime datumPocetka, DateTime datumZavrsetka, string naziv, string opis, PlanerModel planerModel){

            this.Naziv = naziv;
            this.Opis = opis;
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
            this.PlanerModel = planerModel;
            this.PlanerId = planerId;
		}

		~IzmeniPlaner(){

		}

		public override bool Redo(){

            foreach (var planer in PlanerModel.Planers)
            {
                if (planer.PlannerId == PlanerId)
                {
                    PrethodniPlaner = new Planner() { PlannerId = planer.PlannerId, DatumPocetka = planer.DatumPocetka, DatumZavrsetka = planer.DatumZavrsetka, Naziv = planer.Naziv, Opis = planer.Opis };
                    planer.Naziv = Naziv;
                    planer.Opis = Opis;
                    planer.DatumPocetka = DatumPocetka;
                    planer.DatumZavrsetka = DatumZavrsetka;
                    PlanerModel.Planers.Refresh();
                    connection.planerServiceProxy.SaveChanges(planer);
                    break;
                }
            }

            return true;
        }

		public override bool Undo(){

            foreach (var planer in PlanerModel.Planers)
            {
                if (planer.PlannerId == PlanerId)
                {
                    planer.Naziv = PrethodniPlaner.Naziv;
                    planer.Opis = PrethodniPlaner.Opis;
                    planer.DatumPocetka = PrethodniPlaner.DatumPocetka;
                    planer.DatumZavrsetka = PrethodniPlaner.DatumZavrsetka;
                    PlanerModel.Planers.Refresh();
                    connection.planerServiceProxy.SaveChanges(PrethodniPlaner);
                    break;
                }
            }
            return true;
        }

	}//end IzmeniPlaner

}//end namespace EventPlanner