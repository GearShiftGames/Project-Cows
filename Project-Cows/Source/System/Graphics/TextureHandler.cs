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
        public static Texture2D teamLogo;
        public static Texture2D gameLogo;

        // Main Menu
        public static Texture2D menuMainBackground;
        public static Texture2D menuPlayButton;
        public static Texture2D menuControlsButton;
        public static Texture2D menuExitButton;
        public static Texture2D menuCreditsButton;

        // Player Select
        public static Texture2D playerSelectBackground;

        // Buttons
        public static Texture2D joinButton;
        public static Texture2D backButton;
        public static Texture2D startButton;
        public static Texture2D readySelectedButton;
        public static Texture2D readyUnselectedButton;

        // Controls Screen
        public static Texture2D controlsBackground;
        public static Texture2D controlsInformation;

        // Credits Screen
        public static Texture2D creditsBackground;
        public static Texture2D creditsImage;

        // Vehicles Large
        public static Texture2D vehicleLargeCarBlue;
        public static Texture2D vehicleLargeCarOrange;
        public static Texture2D vehicleLargeCarPurple;
        public static Texture2D vehicleLargeCarWhite;
        public static Texture2D vehicleLargeCarYellow;

        public static Texture2D vehicleLargeTankBlue;
        public static Texture2D vehicleLargeTankOrange;
        public static Texture2D vehicleLargeTankPurple;
        public static Texture2D vehicleLargeTankWhite;
        public static Texture2D vehicleLargeTankGreen;

        public static Texture2D vehicleLargeTractorBlue;
        public static Texture2D vehicleLargeTractorOrange;
        public static Texture2D vehicleLargeTractorPurple;
        public static Texture2D vehicleLargeTractorWhite;
        public static Texture2D vehicleLargeTractorGreen;

        public static Texture2D vehicleLargeBuggyBlue;
        public static Texture2D vehicleLargeBuggyOrange;
        public static Texture2D vehicleLargeBuggyPurple;
        public static Texture2D vehicleLargeBuggyWhite;
        public static Texture2D vehicleLargeBuggyYellow;

        // Vehicles Small
        public static Texture2D vehicleSmallCarBlue;
        public static Texture2D vehicleSmallCarOrange;
        public static Texture2D vehicleSmallCarPurple;
        public static Texture2D vehicleSmallCarWhite;
        public static Texture2D vehicleSmallCarYellow;

        public static Texture2D vehicleSmallTankBlue;
        public static Texture2D vehicleSmallTankOrange;
        public static Texture2D vehicleSmallTankPurple;
        public static Texture2D vehicleSmallTankWhite;
        public static Texture2D vehicleSmallTankGreen;

        public static Texture2D vehicleSmallTractorBlue;
        public static Texture2D vehicleSmallTractorOrange;
        public static Texture2D vehicleSmallTractorPurple;
        public static Texture2D vehicleSmallTractorWhite;
        public static Texture2D vehicleSmallTractorGreen;

        public static Texture2D vehicleSmallBuggyBlue;
        public static Texture2D vehicleSmallBuggyOrange;
        public static Texture2D vehicleSmallBuggyPurple;
        public static Texture2D vehicleSmallBuggyWhite;
        public static Texture2D vehicleSmallBuggyYellow;





        // Menu
        //public static Texture2D m_menuBackground;
        //public static Texture2D m_menuBack;
        //public static Texture2D m_menuPlay;
        //public static Texture2D m_menuExit;
        //public static Texture2D m_menuControls;
        //public static Texture2D m_menuOptions;
        //public static Texture2D m_menuCredits;
            // Player Select
        //public static Texture2D m_actionJoin;
        //public static Texture2D m_actionReady;
        //public static Texture2D m_choice1;
        //public static Texture2D m_choice2;
        //public static Texture2D m_choice3;
        public static Texture2D m_choice4;
        public static Texture2D m_vehicleChoice;
        public static Texture2D m_menuMain;  
        public static Texture2D m_menu1;
        public static Texture2D m_menu2;
        public static Texture2D m_menu3;
        public static Texture2D m_menu4;
        //public static Texture2D m_controlInfo;

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

        /*public static Texture2D m_vehicleBlue;
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
        */
        #endregion

        #region DisplayVehicles
        /*
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
        */
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
            LoadTexture(ref teamLogo, "Sprites/Promo/teamLogo");
            LoadTexture(ref gameLogo, "Sprites/Promo/gameLogo");

            // Menu
            LoadTexture(ref menuMainBackground, "Sprites/Menu/Main/background");
            LoadTexture(ref menuPlayButton, "Sprites/Menu/Main/playButton");
            LoadTexture(ref menuControlsButton, "Sprites/Menu/Main/controlsButton");
            LoadTexture(ref menuExitButton, "Sprites/Menu/Main/exitButton");
            LoadTexture(ref menuCreditsButton, "Sprites/Menu/Main/creditsButton");

            // Player Select
            LoadTexture(ref playerSelectBackground, "Sprites/Menu/PlayerSelect/background");

            // Buttons
            LoadTexture(ref joinButton, "Sprites/Menu/Buttons/joinButton");
            LoadTexture(ref backButton, "Sprites/Menu/Buttons/backButton");
            LoadTexture(ref startButton, "Sprites/Menu/Buttons/startButton");
            LoadTexture(ref readySelectedButton, "Sprites/Menu/Buttons/readySelectedButton");
            LoadTexture(ref readyUnselectedButton, "Sprites/Menu/Buttons/readyUnselectedButton");

            // Controls
            LoadTexture(ref controlsBackground, "Sprites/Menu/Controls/background");
            LoadTexture(ref controlsInformation, "Sprites/Menu/Controls/controls");

            // Credits
            LoadTexture(ref creditsBackground, "Sprites/Menu/Credits/background");
            LoadTexture(ref creditsImage, "Sprites/Menu/Credits/credits");

            // Vehicles Large
            LoadTexture(ref vehicleLargeCarBlue, "Sprites/Vehicles/Large/carBlue");
            LoadTexture(ref vehicleLargeCarOrange, "Sprites/Vehicles/Large/carOrange");
            LoadTexture(ref vehicleLargeCarPurple, "Sprites/Vehicles/Large/carPurple");
            LoadTexture(ref vehicleLargeCarWhite, "Sprites/Vehicles/Large/carWhite");
            LoadTexture(ref vehicleLargeCarYellow, "Sprites/Vehicles/Large/carYellow");

            LoadTexture(ref vehicleLargeTankBlue, "Sprites/Vehicles/Large/tankBlue");
            LoadTexture(ref vehicleLargeTankOrange, "Sprites/Vehicles/Large/tankOrange");
            LoadTexture(ref vehicleLargeTankPurple, "Sprites/Vehicles/Large/tankPurple");
            LoadTexture(ref vehicleLargeTankWhite, "Sprites/Vehicles/Large/tankWhite");
            LoadTexture(ref vehicleLargeTankGreen, "Sprites/Vehicles/Large/tankGreen");

            LoadTexture(ref vehicleLargeTractorBlue, "Sprites/Vehicles/Large/tractorBlue");
            LoadTexture(ref vehicleLargeTractorOrange, "Sprites/Vehicles/Large/tractorOrange");
            LoadTexture(ref vehicleLargeTractorPurple, "Sprites/Vehicles/Large/tractorPurple");
            LoadTexture(ref vehicleLargeTractorWhite, "Sprites/Vehicles/Large/tractorWhite");
            LoadTexture(ref vehicleLargeTractorGreen, "Sprites/Vehicles/Large/tractorGreen");

            LoadTexture(ref vehicleLargeBuggyBlue, "Sprites/Vehicles/Large/buggyBlue");
            LoadTexture(ref vehicleLargeBuggyOrange, "Sprites/Vehicles/Large/buggyOrange");
            LoadTexture(ref vehicleLargeBuggyPurple, "Sprites/Vehicles/Large/buggyPurple");
            LoadTexture(ref vehicleLargeBuggyWhite, "Sprites/Vehicles/Large/buggyWhite");
            LoadTexture(ref vehicleLargeBuggyYellow, "Sprites/Vehicles/Large/buggyYellow");

            // Vehicles Small
            LoadTexture(ref vehicleSmallCarBlue, "Sprites/Vehicles/Small/carBlue");
            LoadTexture(ref vehicleSmallCarOrange, "Sprites/Vehicles/Small/carOrange");
            LoadTexture(ref vehicleSmallCarPurple, "Sprites/Vehicles/Small/carPurple");
            LoadTexture(ref vehicleSmallCarWhite, "Sprites/Vehicles/Small/carWhite");
            LoadTexture(ref vehicleSmallCarYellow, "Sprites/Vehicles/Small/carYellow");

            LoadTexture(ref vehicleSmallTankBlue, "Sprites/Vehicles/Small/tankBlue");
            LoadTexture(ref vehicleSmallTankOrange, "Sprites/Vehicles/Small/tankOrange");
            LoadTexture(ref vehicleSmallTankPurple, "Sprites/Vehicles/Small/tankPurple");
            LoadTexture(ref vehicleSmallTankWhite, "Sprites/Vehicles/Small/tankWhite");
            LoadTexture(ref vehicleSmallTankGreen, "Sprites/Vehicles/Small/tankGreen");

            LoadTexture(ref vehicleSmallTractorBlue, "Sprites/Vehicles/Small/tractorBlue");
            LoadTexture(ref vehicleSmallTractorOrange, "Sprites/Vehicles/Small/tractorOrange");
            LoadTexture(ref vehicleSmallTractorPurple, "Sprites/Vehicles/Small/tractorPurple");
            LoadTexture(ref vehicleSmallTractorWhite, "Sprites/Vehicles/Small/tractorWhite");
            LoadTexture(ref vehicleSmallTractorGreen, "Sprites/Vehicles/Small/tractorGreen");

            LoadTexture(ref vehicleSmallBuggyBlue, "Sprites/Vehicles/Small/buggyBlue");
            LoadTexture(ref vehicleSmallBuggyOrange, "Sprites/Vehicles/Small/buggyOrange");
            LoadTexture(ref vehicleSmallBuggyPurple, "Sprites/Vehicles/Small/buggyPurple");
            LoadTexture(ref vehicleSmallBuggyWhite, "Sprites/Vehicles/Small/buggyWhite");
            LoadTexture(ref vehicleSmallBuggyYellow, "Sprites/Vehicles/Small/buggyYellow");








            //LoadTexture(ref m_menuBack, "Sprites\\Menu\\backButton");
            
            // Player Select
            //LoadTexture(ref m_actionJoin, "Sprites\\Menu\\PlayerSelect\\actionJoin");
            //LoadTexture(ref m_actionReady, "Sprites\\Menu\\PlayerSelect\\actionReady");
            //LoadTexture(ref m_choice1, "Sprites\\Menu\\PlayerSelect\\choice1");
            //LoadTexture(ref m_choice2, "Sprites\\Menu\\PlayerSelect\\choice2");
            //LoadTexture(ref m_choice3, "Sprites\\Menu\\PlayerSelect\\choice3");
            LoadTexture(ref m_choice4, "Sprites\\Menu\\PlayerSelect\\choice4");
            LoadTexture(ref m_vehicleChoice, "Sprites\\Menu\\PlayerSelect\\vehicleChoice");
            LoadTexture(ref m_menuMain, "Sprites\\Menu\\Button_Menu_Normal");

            //LoadTexture(ref m_menu1, "Sprites\\Menu\\PlayerSelect\\1Button");
            //LoadTexture(ref m_menu2, "Sprites\\Menu\\PlayerSelect\\2Button");
            //LoadTexture(ref m_menu3, "Sprites\\Menu\\PlayerSelect\\3Button");
            //LoadTexture(ref m_menu4, "Sprites\\Menu\\PlayerSelect\\4Button");
            //LoadTexture(ref m_controlInfo, "Sprites\\Menu\\controls");

            // Victory Screen
            LoadTexture(ref m_victoryBackground, "Sprites\\Menu\\Victory\\Victory_Screen");
            LoadTexture(ref m_menuRaceAgain, "Sprites\\Menu\\Victory\\Button_Race_Again");
            LoadTexture(ref m_trophyFirst, "Sprites\\Menu\\Victory\\Trophy");
            LoadTexture(ref m_trophySecond, "Sprites\\Menu\\Victory\\Trophy_Silver");
            LoadTexture(ref m_trophyThird, "Sprites\\Menu\\Victory\\Trophy_Bronze");
            LoadTexture(ref m_leaderboard, "Sprites\\Menu\\Victory\\Leaderboard_NoText");
            
            #region PlayableVehicles
            //Cars
            /*LoadTexture(ref m_vehicleBlue, "Sprites\\Vehicles\\SmallImages\\Cow_Car_Blue");
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
            LoadTexture(ref m_tankWhite, "Sprites\\Vehicles\\SmallImages\\Cow_Tank_White");*/

            #endregion

            #region DisplayVehicles
            //Cars
            /*LoadTexture(ref m_Display_vehicleBlue, "Sprites\\Vehicles\\LargeImages\\Cow_Car_Blue");
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
            LoadTexture(ref m_Display_tankWhite, "Sprites\\Vehicles\\LargeImages\\Cow_Tank_White");*/

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
            m_player_1_vehicle = vehicleSmallCarBlue;
            m_player_2_vehicle = vehicleSmallCarOrange;
            m_player_3_vehicle = vehicleSmallCarYellow;
            m_player_4_vehicle = vehicleSmallCarPurple;
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
