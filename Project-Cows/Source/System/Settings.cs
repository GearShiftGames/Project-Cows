// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Settings.cs

using System;
using System.Collections.Generic;

namespace Project_Cows.Source.System {
	public class Settings {
		// Settings class, used to keep track of the current game settings.
		// ================

		// Variables
		public bool m_fullscreen;			// Fullscreen state of the application window
		public int m_screenWidth;			// Resolution width of the window
		public int m_screenHeight;			// Resolution height of the window

		// Methods
		public Settings() {
			// Settings constructor
			// ================

			// TODO:
			// Check if a settings file exists
				// If it exists, load the settings
					// If settings are corrupted, set to default
				// If not, set to default
			// Save settings to file

			m_fullscreen = true;
			m_screenWidth = 1920;
			m_screenHeight = 1080;
		}

		public bool LoadSettings() {
			// Loads game settings in from a text file
			// ================

			// TODO: Write code to load game settings from a text file
			return true;
		}

		public bool SaveSettings() {
			// Writes game settings to a text file
			// ================

			// TODO: Write code to save game settings to a text file
			return true;
		}
	}
}
