///////////////////////////////////////////////////////////
//  PlanerCommand.cs
//  Implementation of the Class PlanerCommand
//  Generated by Enterprise Architect
//  Created on:      25-Aug-2021 2:54:39 PM
//  Original author: Filip
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Common.Models;
using Client.Models;
using Client.Connections;



namespace Client.Command {
    public abstract class PlanerCommand : Command {

        public Planner PrethodniPlaner { get; set; }

        public PlanerModel PlanerModel { get; set; }


		public PlanerCommand(){
		}

		~PlanerCommand(){

		}

	}//end PlanerCommand

}//end namespace EventPlanner