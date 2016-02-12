// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Settings.cs

using System;
using System.Collections.Generic;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.System {
	public static class Settings {
		// Settings class, used to keep track of the current game settings.
		// ================

		// Variables
        private static IniFile m_fileSettings = new IniFile("\\settings.ini");

		public static bool m_fullscreen = false;			            // Fullscreen state of the application window
		public static int m_screenWidth = 1920;				            // Resolution width of the window
		public static int m_screenHeight = 1080;			            // Resolution height of the window
        public static GameState m_startState = GameState.MAIN_MENU;     // Starting game state

		public static bool m_debug = true;

		// Methods
		public static bool LoadSettings() {
			// Loads game settings in from a text file
			// ================

            // Game Settings
            m_fullscreen = Convert.ToBoolean(m_fileSettings.ReadValue("Game Settings", "fullscreen"));
            m_screenWidth = Convert.ToInt32(m_fileSettings.ReadValue("Game Settings", "screenWidth").Replace("\0", string.Empty));
            m_screenHeight = Convert.ToInt32(m_fileSettings.ReadValue("Game Settings", "screenHeight").Replace("\0", string.Empty));
            string lol = m_fileSettings.ReadValue("Game Settings", "startState").Replace("\0", string.Empty);
            m_startState = (GameState)Enum.Parse(typeof(GameState), lol);
            

			// TODO: Write code to load game settings from a text file
			return true;
		}

		public static bool SaveSettings() {
			// Writes game settings to a text file
			// ================

            // Game Settings
            m_fileSettings.WriteValue("Game Settings", "fullscreen", m_fullscreen.ToString());
            m_fileSettings.WriteValue("Game Settings", "screenWidth", m_screenWidth.ToString());
            m_fileSettings.WriteValue("Game Settings", "screenHeight", m_screenHeight.ToString());
            m_fileSettings.WriteValue("Game Settings", "startState", m_startState.ToString());


			// TODO: Write code to save game settings to a text file
			return true;
		}
	}
}
