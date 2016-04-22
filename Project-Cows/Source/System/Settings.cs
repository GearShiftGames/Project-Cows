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
/// Settings.cs

using System;
using System.Collections.Generic;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.System {
	public static class Settings {
		// Settings class, used to keep track of the current game settings.
		// ================

		// Variables
        private static IniFile m_fileSettings = new IniFile("\\Data\\settings.ini");

        // App Settings
		public static bool m_fullscreen = false;			            // Fullscreen state of the application window
		public static int m_screenWidth = 1920;				            // Resolution width of the window
		public static int m_screenHeight = 1080;			            // Resolution height of the window
        public static GameState m_startState = GameState.MAIN_MENU;     // Starting game state
		public static bool m_debug = false;                             // Debug screen state

        // Game Settings
        public static int m_numberOfPlayers = 2;                        // Number of players
        //public static int m_track

		// Methods
		public static void LoadSettings() {
			// Loads game settings in from a text file
			// ================

            // App Settings
            m_fullscreen = Convert.ToBoolean(m_fileSettings.ReadValue("App Settings", "fullscreen"));
            m_screenWidth = Convert.ToInt32(m_fileSettings.ReadValue("App Settings", "screenWidth").Replace("\0", string.Empty));
            m_screenHeight = Convert.ToInt32(m_fileSettings.ReadValue("App Settings", "screenHeight").Replace("\0", string.Empty));
            m_startState = (GameState)Enum.Parse(typeof(GameState), m_fileSettings.ReadValue("App Settings", "startState").Replace("\0", string.Empty));
            
            // Game Settings
            m_numberOfPlayers = Convert.ToInt32(m_fileSettings.ReadValue("Game Settings", "numberOfPlayers").Replace("\0", string.Empty));

		}

		public static void SaveSettings() {
			// Writes game settings to a text file
			// ================

            // App Settings
            m_fileSettings.WriteValue("App Settings", "fullscreen", m_fullscreen.ToString());
            m_fileSettings.WriteValue("App Settings", "screenWidth", m_screenWidth.ToString());
            m_fileSettings.WriteValue("App Settings", "screenHeight", m_screenHeight.ToString());
            m_fileSettings.WriteValue("App Settings", "startState", m_startState.ToString());

            // Game Settings
            m_fileSettings.WriteValue("Game Settings", "numberOfPlayers", m_numberOfPlayers.ToString());
		}
	}
}
