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
/// TextureHandler.cs

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
        public static Texture2D m_menuControls;
        public static Texture2D m_menuOptions;
        public static Texture2D m_menuCredits;
        // Player Select
        public static Texture2D m_actionJoin;
        public static Texture2D m_actionReady;
        public static Texture2D m_choice1;
        public static Texture2D m_choice2;
        public static Texture2D m_choice3;
        public static Texture2D m_choice4;
        public static Texture2D m_vehicleChoice;
        public static Texture2D m_menuMain;
        public static Texture2D m_menu1;
        public static Texture2D m_menu2;
        public static Texture2D m_menu3;
        public static Texture2D m_menu4;
        public static Texture2D m_controlInfo;

        // Victory Screen
        public static Texture2D m_victoryBackground;
        public static Texture2D m_menuRaceAgain;
        public static Texture2D m_trophyFirst;
        public static Texture2D m_trophySecond;
        public static Texture2D m_trophyThird;
        public static Texture2D m_leaderboard;

        // Used for character selection & vehicle selection
        public static Texture2D m_player_1_cow;
        public static Texture2D m_player_2_cow;
        public static Texture2D m_player_3_cow;
        public static Texture2D m_player_4_cow;
        public static Texture2D m_player_1_vehicle;
        public static Texture2D m_player_2_vehicle;
        public static Texture2D m_player_3_vehicle;
        public static Texture2D m_player_4_vehicle;
        // Vehicle
        #region playableVehicles

        public static Texture2D m_vehicleBlue;
        public static Texture2D m_vehicleOrange;
        public static Texture2D m_vehiclePurple;
        public static Texture2D m_vehicleWhite;
        public static Texture2D m_vehicleYellow;

        public static Texture2D m_tractorBlue;
        public static Texture2D m_tractorOrange;
        public static Texture2D m_tractorPurple;
        public static Texture2D m_tractorWhite;
        public static Texture2D m_tractorGreen;

        public static Texture2D m_tankBlue;
        public static Texture2D m_tankOrange;
        public static Texture2D m_tankPurple;
        public static Texture2D m_tankWhite;
        public static Texture2D m_tankGreen;

        #endregion

        #region DisplayVehicles

        public static Texture2D m_Display_vehicleBlue;
        public static Texture2D m_Display_vehicleOrange;
        public static Texture2D m_Display_vehiclePurple;
        public static Texture2D m_Display_vehicleWhite;
        public static Texture2D m_Display_vehicleYellow;

        public static Texture2D m_Display_tractorBlue;
        public static Texture2D m_Display_tractorOrange;
        public static Texture2D m_Display_tractorPurple;
        public static Texture2D m_Display_tractorWhite;
        public static Texture2D m_Display_tractorGreen;

        public static Texture2D m_Display_tankBlue;
        public static Texture2D m_Display_tankOrange;
        public static Texture2D m_Display_tankPurple;
        public static Texture2D m_Display_tankWhite;
        public static Texture2D m_Display_tankGreen;

        #endregion

        public static Texture2D m_cow1;
        public static Texture2D m_cow2;
        public static Texture2D m_cow21;
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
        public static Texture2D m_grassBackground;
        // Debug
        public static Texture2D m_debugCorner;
        public static Texture2D m_debugCheckpoint;
        public static Texture2D m_debugCollider;
        // Temp
        public static Texture2D m_tempRed;
        public static Texture2D m_vehicleTyre;

        // GFX
        public static Texture2D m_particleTexture;

        public static Texture2D m_THELORDANDSAVIOUR;

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
            LoadTexture(ref m_menuExit, "Sprites\\Menu\\exitButton");
            LoadTexture(ref m_menuPlay, "Sprites\\Menu\\Button_Play_Normal");
            LoadTexture(ref m_menuControls, "Sprites\\Menu\\Button_Controls_Normal");
            LoadTexture(ref m_menuOptions, "Sprites\\Menu\\Button_Options_Normal");
            LoadTexture(ref m_menuCredits, "Sprites\\Menu\\creditsButton");

            // Player Select
            LoadTexture(ref m_actionJoin, "Sprites\\Menu\\PlayerSelect\\actionJoin");
            LoadTexture(ref m_actionReady, "Sprites\\Menu\\PlayerSelect\\actionReady");
            LoadTexture(ref m_choice1, "Sprites\\Menu\\PlayerSelect\\choice1");
            LoadTexture(ref m_choice2, "Sprites\\Menu\\PlayerSelect\\choice2");
            LoadTexture(ref m_choice3, "Sprites\\Menu\\PlayerSelect\\choice3");
            LoadTexture(ref m_choice4, "Sprites\\Menu\\PlayerSelect\\choice4");
            LoadTexture(ref m_vehicleChoice, "Sprites\\Menu\\PlayerSelect\\vehicleChoice");
            LoadTexture(ref m_menuMain, "Sprites\\Menu\\Button_Menu_Normal");

            LoadTexture(ref m_menu1, "Sprites\\Menu\\PlayerSelect\\1Button");
            LoadTexture(ref m_menu2, "Sprites\\Menu\\PlayerSelect\\2Button");
            LoadTexture(ref m_menu3, "Sprites\\Menu\\PlayerSelect\\3Button");
            LoadTexture(ref m_menu4, "Sprites\\Menu\\PlayerSelect\\4Button");
            LoadTexture(ref m_controlInfo, "Sprites\\Menu\\controls");

            // Victory Screen
            LoadTexture(ref m_victoryBackground, "Sprites\\Menu\\Victory\\Victory_Screen");
            LoadTexture(ref m_menuRaceAgain, "Sprites\\Menu\\Victory\\Button_Race_Again");
            LoadTexture(ref m_trophyFirst, "Sprites\\Menu\\Victory\\Trophy");
            LoadTexture(ref m_trophySecond, "Sprites\\Menu\\Victory\\Trophy_Silver");
            LoadTexture(ref m_trophyThird, "Sprites\\Menu\\Victory\\Trophy_Bronze");
            LoadTexture(ref m_leaderboard, "Sprites\\Menu\\Victory\\Leaderboard_NoText");

            #region PlayableVehicles
            //Cars
            LoadTexture(ref m_vehicleBlue, "Sprites\\Vehicles\\SmallImages\\Cow_Car_Blue");
            LoadTexture(ref m_vehicleOrange, "Sprites\\Vehicles\\SmallImages\\Cow_Car_Orange");
            LoadTexture(ref m_vehiclePurple, "Sprites\\Vehicles\\SmallImages\\Cow_Car_Purple");
            LoadTexture(ref m_vehicleYellow, "Sprites\\Vehicles\\SmallImages\\Cow_Car_Yellow");
            LoadTexture(ref m_vehicleWhite, "Sprites\\Vehicles\\SmallImages\\Cow_Car_White");

            //Tractors
            LoadTexture(ref m_tractorBlue, "Sprites\\Vehicles\\SmallImages\\Cow_Tractor_Blue");
            LoadTexture(ref m_tractorOrange, "Sprites\\Vehicles\\SmallImages\\Cow_Tractor_Orange");
            LoadTexture(ref m_tractorPurple, "Sprites\\Vehicles\\SmallImages\\Cow_Tractor_Purple");
            LoadTexture(ref m_tractorGreen, "Sprites\\Vehicles\\SmallImages\\Cow_Tractor_Green");
            LoadTexture(ref m_tractorWhite, "Sprites\\Vehicles\\SmallImages\\Cow_Tractor_White");

            //Tanks
            LoadTexture(ref m_tankBlue, "Sprites\\Vehicles\\SmallImages\\Cow_Tank_Blue");
            LoadTexture(ref m_tankOrange, "Sprites\\Vehicles\\SmallImages\\Cow_Tank_Orange");
            LoadTexture(ref m_tankPurple, "Sprites\\Vehicles\\SmallImages\\Cow_Tank_Purple");
            LoadTexture(ref m_tankGreen, "Sprites\\Vehicles\\SmallImages\\Cow_Tank_Green");
            LoadTexture(ref m_tankWhite, "Sprites\\Vehicles\\SmallImages\\Cow_Tank_White");

            #endregion

            #region DisplayVehicles
            //Cars
            LoadTexture(ref m_Display_vehicleBlue, "Sprites\\Vehicles\\LargeImages\\Cow_Car_Blue");
            LoadTexture(ref m_Display_vehicleOrange, "Sprites\\Vehicles\\LargeImages\\Cow_Car_Orange");
            LoadTexture(ref m_Display_vehiclePurple, "Sprites\\Vehicles\\LargeImages\\Cow_Car_Purple");
            LoadTexture(ref m_Display_vehicleYellow, "Sprites\\Vehicles\\LargeImages\\Cow_Car_Yellow");
            LoadTexture(ref m_Display_vehicleWhite, "Sprites\\Vehicles\\LargeImages\\Cow_Car_White");

            //Tractors
            LoadTexture(ref m_Display_tractorBlue, "Sprites\\Vehicles\\LargeImages\\Cow_Tractor_Blue");
            LoadTexture(ref m_Display_tractorOrange, "Sprites\\Vehicles\\LargeImages\\Cow_Tractor_Orange");
            LoadTexture(ref m_Display_tractorPurple, "Sprites\\Vehicles\\LargeImages\\Cow_Tractor_Purple");
            LoadTexture(ref m_Display_tractorGreen, "Sprites\\Vehicles\\LargeImages\\Cow_Tractor_Green");
            LoadTexture(ref m_Display_tractorWhite, "Sprites\\Vehicles\\LargeImages\\Cow_Tractor_White");

            //Tractors
            LoadTexture(ref m_Display_tankBlue, "Sprites\\Vehicles\\LargeImages\\Cow_Tank_Blue");
            LoadTexture(ref m_Display_tankOrange, "Sprites\\Vehicles\\LargeImages\\Cow_Tank_Orange");
            LoadTexture(ref m_Display_tankPurple, "Sprites\\Vehicles\\LargeImages\\Cow_Tank_Purple");
            LoadTexture(ref m_Display_tankGreen, "Sprites\\Vehicles\\LargeImages\\Cow_Tank_Green");
            LoadTexture(ref m_Display_tankWhite, "Sprites\\Vehicles\\LargeImages\\Cow_Tank_White");

            #endregion




            //LoadTexture(ref m_tankGreen, "Sprites\\Vehicles\\Cow_Tank_Green");
            /*
             *LoadTexture(ref m_tankBlue, "Sprites\\Vehicles\\Cow_Tank_Blue"); 
             *LoadTexture(ref m_tankOrange, "Sprites\\Vehicles\\Cow_Tank_Orange"); 
             *LoadTexture(ref m_tankPurple, "Sprites\\Vehicles\\Cow_Tank_Purple");
             *LoadTexture(ref m_tankYellow, "Sprites\\Vehicles\\Cow_Tank_Yellow");
             *LoadTexture(ref m_tractorOrange, "Sprites\\Vehicles\\Cow_Tractor_Orange");
             *LoadTexture(ref m_tractorPurple, "Sprites\\Vehicles\\Cow_Tractor_Purple");
             *LoadTexture(ref m_tractorYellow, "Sprites\\Vehicles\\Cow_Tractor_Yellow");
             */

            LoadTexture(ref m_cow21, "Sprites\\Vehicles\\cow2.1");
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
            LoadTexture(ref m_grassBackground, "Sprites\\Track\\Grass");

            // Debug
            LoadTexture(ref m_debugCorner, "Sprites\\Utility\\corner");
            LoadTexture(ref m_debugCheckpoint, "Sprites\\Utility\\checkpoint");
            LoadTexture(ref m_debugCollider, "Sprites\\Utility\\carCollider");

            // Temp
            LoadTexture(ref m_tempRed, "Sprites\\Temp\\Red");
            LoadTexture(ref m_vehicleTyre, "Sprites\\Temp\\vehicleTyre");
            LoadTexture(ref m_THELORDANDSAVIOUR, "Sprites\\Temp\\THELORD");

            // GFX
            LoadTexture(ref m_particleTexture, "Sprites\\Utility\\brown_particle");
            LoadTexture(ref m_THELORDANDSAVIOUR, "Sprites\\Temp\\THELORD");

            // Defaults
            m_player_1_vehicle = m_vehicleBlue;
            m_player_2_vehicle = m_vehicleOrange;
            m_player_3_vehicle = m_vehicleYellow;
            m_player_4_vehicle = m_vehiclePurple;
            m_player_1_cow = m_cow1;
            m_player_2_cow = m_cow2;
            m_player_3_cow = m_cow3;
            m_player_4_cow = m_cow4;
        }

        private static void LoadTexture(ref Texture2D texture_, string file_) {
            texture_ = GraphicsHandler.m_content.Load<Texture2D>(file_);
        }

        // Getters


        // Setters

    }
}
