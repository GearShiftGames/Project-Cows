// Project Cows -- GearShift Games
// Created during project setup, 2016
// ================
// Project.cs

using System;
using Project_Cows.Source.Application;

namespace Project_Cows {
#if WINDOWS || LINUX
	public static class Program {
		// The main entry point for the game
		// ================

		[STAThread]
		static void Main() {
			using (var app = new Application()) {
				app.Run();
			}
		}
	}
#endif
}
