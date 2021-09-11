///////////////////////////////////////////////////////////
//  Command.cs
//  Implementation of the Class Command
//  Generated by Enterprise Architect
//  Created on:      25-Aug-2021 3:05:57 PM
//  Original author: Filip
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Client.Command {
	public abstract class Command {

		public Command(){

		}

		~Command(){

		}

        public abstract void Redo();

        public abstract void Undo();

	}//end Command

}//end namespace EventPlanner