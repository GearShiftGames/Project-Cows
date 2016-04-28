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
		public static Texture2D menuPlayAgainButton;
		public static Texture2D menuMainMenuButton;

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

		// Controller
		public static Texture2D controlWheelBlue;
		public static Texture2D controlWheelOrange;
		public static Texture2D controlWheelPurple;
		public static Texture2D controlWheelYellow;
		public static Texture2D controlSliderBackground;

		// In Game
		public static Texture2D gameBackground;
		public static Texture2D gameTrack;
		public static Texture2D gameBarrier;

		// Victory Screen
		public static Texture2D victoryBackground;
		public static Texture2D victoryTrophyFirst;
		public static Texture2D victoryTrophySecond;
		public static Texture2D victoryTrophyThird;
		public static Texture2D victoryLeaderboard;

		// Cows
		public static Texture2D cow1;
		public static Texture2D cow2;
		public static Texture2D cow3;
		public static Texture2D cow4;

		// GFX
		public static Texture2D particleBrown;

		// Debug
		public static Texture2D debugCheckpoint;
		public static Texture2D vehicleTyre;

        // Defaults (for player vehicle selection)
		public static Texture2D player1Cow;
		public static Texture2D player2Cow;
		public static Texture2D player3Cow;
		public static Texture2D player4Cow;
        public static Texture2D player1Vehicle;
		public static Texture2D player2Vehicle;
		public static Texture2D player3Vehicle;
		public static Texture2D player4Vehicle;

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
			LoadTexture(ref menuPlayAgainButton, "Sprites/Menu/Main/playAgainButton");
			LoadTexture(ref menuMainMenuButton, "Sprites/Menu/Main/mainMenuButton");

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

			// Controller
			LoadTexture(ref controlWheelBlue, "Sprites/Game/Controllers/controlWheelBlue");
			LoadTexture(ref controlWheelOrange, "Sprites/Game/Controllers/controlWheelOrange");
			LoadTexture(ref controlWheelPurple, "Sprites/Game/Controllers/controlWheelPurple");
			LoadTexture(ref controlWheelYellow, "Sprites/Game/Controllers/controlWheelYellow");
			LoadTexture(ref controlSliderBackground, "Sprites/Game/Controllers/controlWheelSlider");

			// In Game
			LoadTexture(ref gameBackground, "Sprites/Game/Track/gameBackground");
			LoadTexture(ref gameTrack, "Sprites/Game/Track/gameTrack");
			LoadTexture(ref gameBarrier, "Sprites/Game/Track/barrier");

			// Victory Screen
			LoadTexture(ref victoryBackground, "Sprites/Menu/Victory/background");
			LoadTexture(ref victoryTrophyFirst, "Sprites/Menu/Victory/trophyFirst");
			LoadTexture(ref victoryTrophySecond, "Sprites/Menu/Victory/trophySecond");
			LoadTexture(ref victoryTrophyThird, "Sprites/Menu/Victory/trophyThird");
			LoadTexture(ref victoryLeaderboard, "Sprites/Menu/Victory/leaderboard");

			// Cows
			LoadTexture(ref cow1, "Sprites/Vehicles/Cows/cow1");
			LoadTexture(ref cow2, "Sprites/Vehicles/Cows/cow2");
			LoadTexture(ref cow3, "Sprites/Vehicles/Cows/cow3");
			LoadTexture(ref cow4, "Sprites/Vehicles/Cows/cow4");

			// GFX
			LoadTexture(ref particleBrown, "Sprites/GFX/particleBrown");

            // Debug
            LoadTexture(ref debugCheckpoint, "Sprites/Game/Track/checkpoint");
			LoadTexture(ref vehicleTyre, "Sprites/Game/Track/vehicleTyre");


            // Defaults
            player1Vehicle = vehicleSmallCarBlue;
			player2Vehicle = vehicleSmallCarOrange;
			player3Vehicle = vehicleSmallCarYellow;
			player4Vehicle = vehicleSmallCarPurple;
            player1Cow = cow1;
			player2Cow = cow2;
			player3Cow = cow3;
			player4Cow = cow4;
        }

        private static void LoadTexture(ref Texture2D texture_, string file_) {
            texture_ = GraphicsHandler.m_content.Load<Texture2D>(file_);
        }

        // Getters


        // Setters

    }
}
