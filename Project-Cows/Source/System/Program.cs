/// Project: Cow Racing
/// Developed by GearShift Games, 2015-2016
///     D. Sinclair
///     N. Headley
///     D. Divers
///     C. Fleming
///     C. Tekpinar
///     D. McNally
///     G. Annandale
///     R. Ferguson
/// ================
/// Project.cs

using System;
using Project_Cows.Source.Application;

namespace Project_Cows {
#if WINDOWS || LINUX
	public static class Program {
		// The main entry point for the game
		// ================

		[STAThread]
		static void Main() {
			// Main function
			// ================
			using (var app = new Application()) {
				app.Run();
			}
		}
	}
#endif
}
