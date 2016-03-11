// Project: Cow Racing -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// TextureHandler.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Cows.Source.System.Graphics {
    public static class TextureHandler {
        // Class to load all the game textures
        // ================

        // Variables
        // Promo
        public static Texture2D m_gameLogo;
        public static Texture2D m_teamLogo;
        // Menu
        public static Texture2D m_menuBackground;
        public static Texture2D m_menuBack;
        public static Texture2D m_menuPlay;
        public static Texture2D m_menuExit;
        public static Texture2D m_menuOptions;
        public static Texture2D m_menuCredits;
        public static Texture2D m_menu1;
        public static Texture2D m_menu2;
        public static Texture2D m_menu3;
        public static Texture2D m_menu4;
        // Vehicle
        public static Texture2D m_vehicleBlue;
        public static Texture2D m_vehicleOrange;
        public static Texture2D m_vehiclePurple;
        public static Texture2D m_vehicleYellow;
        public static Texture2D m_cow1;
        public static Texture2D m_cow2;
        public static Texture2D m_cow3;
        public static Texture2D m_cow4;
        // User Interface
        public static Texture2D m_userInterfaceWheelBlue;
        public static Texture2D m_userInterfaceWheelOrange;
        public static Texture2D m_userInterfaceWheelPurple;
        public static Texture2D m_userInterfaceWheelYellow;
        public static Texture2D m_userInterfaceSlider;
        // In Game
        public static Texture2D m_gameBackground;
        public static Texture2D m_gameBarrier;
        public static Texture2D m_gameFinishLine;
        // Debug
        public static Texture2D m_debugCorner;
        public static Texture2D m_debugCheckpoint;
        public static Texture2D m_debugCollider;
        // Temp
        public static Texture2D m_tempRed;

        // Methods
        public static void LoadContent() {
            // Load all the game content
            // ================

            // Promo
            //LoadTexture(ref m_gameLogo, "Sprites\\Promo\\gameLogo");
            LoadTexture(ref m_teamLogo, "Sprites\\Promo\\teamLogo");

            // Menu
            LoadTexture(ref m_menuBackground, "Sprites\\Menu\\background");
            LoadTexture(ref m_menuBack, "Sprites\\Menu\\backButton");
            LoadTexture(ref m_menuPlay, "Sprites\\Menu\\playButton");
            LoadTexture(ref m_menuExit, "Sprites\\Menu\\exitButton");
            LoadTexture(ref m_menuOptions, "Sprites\\Menu\\optionsButton");
            LoadTexture(ref m_menuCredits, "Sprites\\Menu\\creditsButton");
            LoadTexture(ref m_menu1, "Sprites\\Menu\\1Button");
            LoadTexture(ref m_menu2, "Sprites\\Menu\\2Button");
            LoadTexture(ref m_menu3, "Sprites\\Menu\\3Button");
            LoadTexture(ref m_menu4, "Sprites\\Menu\\4Button");

            // Vehicles
            LoadTexture(ref m_vehicleBlue, "Sprites\\Vehicles\\vehicleBlue");
            LoadTexture(ref m_vehicleOrange, "Sprites\\Vehicles\\vehicleOrange");
            LoadTexture(ref m_vehiclePurple, "Sprites\\Vehicles\\vehiclePurple");
            LoadTexture(ref m_vehicleYellow, "Sprites\\Vehicles\\vehicleYellow");
            LoadTexture(ref m_cow1, "Sprites\\Vehicles\\cow1");
            LoadTexture(ref m_cow2, "Sprites\\Vehicles\\cow2");
            LoadTexture(ref m_cow3, "Sprites\\Vehicles\\cow3");
            LoadTexture(ref m_cow4, "Sprites\\Vehicles\\cow4");

            // User Interface
            LoadTexture(ref m_userInterfaceWheelBlue, "Sprites\\UI\\wheelBlue");
            LoadTexture(ref m_userInterfaceWheelOrange, "Sprites\\UI\\wheelOrange");
            LoadTexture(ref m_userInterfaceWheelPurple, "Sprites\\UI\\wheelPurple");
            LoadTexture(ref m_userInterfaceWheelYellow, "Sprites\\UI\\wheelYellow");
            LoadTexture(ref m_userInterfaceSlider, "Sprites\\UI\\slider");

            // In Game
            LoadTexture(ref m_gameBackground, "Sprites\\Track\\background");
            LoadTexture(ref m_gameBarrier, "Sprites\\Track\\Barriers\\barrier");
            LoadTexture(ref m_gameFinishLine, "Sprites\\Track\\finishLine");
            
            // Debug
            LoadTexture(ref m_debugCorner, "Sprites\\Utility\\corner");
            LoadTexture(ref m_debugCheckpoint, "Sprites\\Utility\\checkpoint");
            LoadTexture(ref m_debugCollider, "Sprites\\Utility\\carCollider");

            // Temp
            LoadTexture(ref m_tempRed, "Sprites\\Temp\\Red");
        }

        private static void LoadTexture(ref Texture2D texture_, string file_) {
            texture_ = GraphicsHandler.m_content.Load<Texture2D>(file_);
        }

        // Getters


        // Setters

    }
}
