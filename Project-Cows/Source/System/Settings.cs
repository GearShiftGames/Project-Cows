// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Settings.cs

using System;
using System.Collections.Generic;

namespace Project_Cows.Source.System {
	public static class Settings {
		// Settings class, used to keep track of the current game settings.
		// ================

		// Variables
		public static bool m_fullscreen = false;			// Fullscreen state of the application window
		public static int m_screenWidth = 1920;				// Resolution width of the window
		public static int m_screenHeight = 1080;			// Resolution height of the window

		public static bool m_debug = false;

		// Methods
		public static bool LoadSettings() {
			// Loads game settings in from a text file
			// ================

			// TODO: Write code to load game settings from a text file
			return true;
		}

		public static bool SaveSettings() {
			// Writes game settings to a text file
			// ================

			// TODO: Write code to save game settings to a text file
			return true;
		}
	}
}
