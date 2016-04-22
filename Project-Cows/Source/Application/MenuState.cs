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
/// MenuState.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Particles;
using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.Application {
	class MenuState : State {
		// Class to handle the menu state of the game
		// ================

		// Variables
		private MenuScreenState m_currentScreen;
        private TouchState m_touchState;
        private Vector2 m_lastPosition;

        // Sprites
        private Sprite m_background;
        private Sprite m_teamLogo;
        private Sprite m_gameLogo;
        private Sprite m_player_1_cow;
        private Sprite m_player_1_vehicle;
        private Sprite m_player_2_cow;
        private Sprite m_player_2_vehicle;
        private Sprite m_player_3_cow;
        private Sprite m_player_3_vehicle;
        private Sprite m_player_4_cow;
        private Sprite m_player_4_vehicle;
        private Sprite m_control_scheme;
        
        // Buttons
        private Button m_playButton;
        private Button m_optionsButton;
        private Button m_exitButton;
        private Button m_MenuButton;
        private Button m_creditsButton;
        private Button m_controlsButton;
        private Button m_1Button;
        private Button m_2Button;
        private Button m_3Button;
        private Button m_4Button;
        private Button m_Cow1Button;
        private Button m_Cow2Button;
        private Button m_Cow3Button;
        private Button m_Cow4Button;
        private Button m_TankButton;
        private Button m_CarButton;
        private Button m_TractorButton;

        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Particle> m_particles = new List<Particle>();

		// Methods
        public MenuState() : base() {
			// MenuState constructor
			// ================

			m_currentState = GameState.MAIN_MENU;

			m_currentExecutionState = ExecutionState.INITIALISING;

            // Initialise number of players to 0
            // So number must be chosen before continuing
            Settings.m_numberOfPlayers = 0;
		}

        public override void Initialise() {
			// Initialise menu state
			// ================

            // Initialise sprites
            m_background =      new Sprite(TextureHandler.m_menuBackground, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
            m_teamLogo =        new Sprite(TextureHandler.m_teamLogo,       new Vector2(Settings.m_screenWidth - 150, Settings.m_screenHeight / 11), 0, new  Vector2(0.5f,0.5f));
            m_control_scheme =  new Sprite(TextureHandler.m_controlInfo,    new Vector2(Settings.m_screenWidth * 0.5f, Settings.m_screenHeight * 0.5f), 0, Vector2.One);
            //m_gameLogo = new Sprite(TextureHandler.m_gameLogo, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
            // Not sure about this part. Maybe Move to update function
            m_player_1_cow =    new Sprite(TextureHandler.m_cow1,           new Vector2(Settings.m_screenWidth * 0.50f - 10.0f, Settings.m_screenHeight * 0.75f ), 0, new Vector2(0.1f, 0.1f));
            m_player_1_vehicle =new Sprite(TextureHandler.m_vehicleBlue,    new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.75f), 0, Vector2.One);
            m_player_2_cow =    new Sprite(TextureHandler.m_cow1,           new Vector2(Settings.m_screenWidth * 0.50f - 10.0f, Settings.m_screenHeight * 0.75f), 0, new Vector2(0.1f, 0.1f));
            m_player_2_vehicle =new Sprite(TextureHandler.m_vehicleOrange,  new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.75f), 0, Vector2.One);
            m_player_3_cow =    new Sprite(TextureHandler.m_cow1,           new Vector2(Settings.m_screenWidth * 0.50f - 10.0f, Settings.m_screenHeight * 0.75f), 0, new Vector2(0.1f, 0.1f));
            m_player_3_vehicle =new Sprite(TextureHandler.m_vehiclePurple,  new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.75f), 0, Vector2.One);
            m_player_4_cow =    new Sprite(TextureHandler.m_cow1,           new Vector2(Settings.m_screenWidth * 0.50f - 10.0f, Settings.m_screenHeight * 0.75f), 0, new Vector2(0.1f, 0.1f));
            m_player_4_vehicle =new Sprite(TextureHandler.m_vehicleYellow,  new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.75f), 0, Vector2.One);
            // Initialise buttons
            m_playButton =      new Button(TextureHandler.m_menuPlay,       new Vector2(Settings.m_screenWidth * 0.25f, Settings.m_screenHeight * 0.75f));
            m_optionsButton =   new Button(TextureHandler.m_menuOptions,    new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.75f));
            m_controlsButton =  new Button(TextureHandler.m_menuControls,   new Vector2(Settings.m_screenWidth * 0.75f, Settings.m_screenHeight * 0.75f));
            m_MenuButton =      new Button(TextureHandler.m_menuMain,       new Vector2(Settings.m_screenWidth * 0.75f, Settings.m_screenHeight * 0.75f));
            m_creditsButton =   new Button(TextureHandler.m_menuCredits,    new Vector2(Settings.m_screenWidth * 0.90f, Settings.m_screenHeight * 0.90f));
            m_exitButton =      new Button(TextureHandler.m_menuExit,       new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.90f));
            m_1Button =         new Button(TextureHandler.m_menu1,          new Vector2(Settings.m_screenWidth * 0.33f, Settings.m_screenHeight * 0.50f));
            m_2Button =         new Button(TextureHandler.m_menu2,          new Vector2(Settings.m_screenWidth * 0.66f, Settings.m_screenHeight * 0.50f));
            m_3Button =         new Button(TextureHandler.m_menu3,          new Vector2(Settings.m_screenWidth * 0.33f, Settings.m_screenHeight * 0.625f));
            m_4Button =         new Button(TextureHandler.m_menu4,          new Vector2(Settings.m_screenWidth * 0.66f, Settings.m_screenHeight * 0.625f));
            m_Cow1Button =      new Button(TextureHandler.m_cow1,           new Vector2(Settings.m_screenWidth * 0.33f, Settings.m_screenHeight * 0.75f));
            m_Cow2Button =      new Button(TextureHandler.m_cow21,          new Vector2(Settings.m_screenWidth * 0.66f, Settings.m_screenHeight * 0.75f));
            m_TankButton =      new Button(TextureHandler.m_tankGreen,      new Vector2(Settings.m_screenWidth * 0.53f - 20.0f, Settings.m_screenHeight * 0.5f + 50.0f));
            m_CarButton =       new Button(TextureHandler.m_vehicleBlue,    new Vector2(Settings.m_screenWidth * 0.56f - 20.0f, Settings.m_screenHeight * 0.5f + 50.0f));
            m_TractorButton =   new Button(TextureHandler.m_tractorBlue,    new Vector2(Settings.m_screenWidth * 0.59f - 20.0f, Settings.m_screenHeight * 0.5f + 50.0f));
            m_Cow1Button.m_sprite.SetScale(0.5f);
            m_Cow2Button.m_sprite.SetScale(0.5f);
			// Set menu screen
			m_currentScreen = MenuScreenState.MAIN_MENU;

            m_touchState = TouchState.IDLE;

			// Set initial next state
			m_nextState = GameState.IN_GAME;

			// Change exectution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

		public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_) {
			// Update menu state
			// ================

            // NOTE: Debug Purposes
            
            if (Keyboard.GetState().IsKeyDown(Keys.Q)) {
                m_currentScreen = MenuScreenState.MAIN_MENU;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                m_currentScreen = MenuScreenState.PLAYER_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E)) {
                m_currentScreen = MenuScreenState.TRACK_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R)) {
                m_currentScreen = MenuScreenState.OPTIONS;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.T)) {
                m_currentScreen = MenuScreenState.CREDITS;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Y)) {
                m_currentExecutionState = ExecutionState.CHANGING;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.U))
            {
                m_currentScreen = MenuScreenState.PLAYER_1_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                m_currentScreen = MenuScreenState.PLAYER_2_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                m_currentScreen = MenuScreenState.PLAYER_3_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                m_currentScreen = MenuScreenState.PLAYER_4_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                m_currentScreen = MenuScreenState.CONTROLS;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                m_nextState = GameState.VICTORY_SCREEN;
                m_currentExecutionState = ExecutionState.CHANGING;
            }
              
            // Change player count with keys - TEMP
            if (Keyboard.GetState().IsKeyDown(Keys.D1)) {
                Settings.m_numberOfPlayers = 1;
            } else if (Keyboard.GetState().IsKeyDown(Keys.D2)) {
                Settings.m_numberOfPlayers = 2;
            } else if (Keyboard.GetState().IsKeyDown(Keys.D3)) {
                Settings.m_numberOfPlayers = 3;
            } else if (Keyboard.GetState().IsKeyDown(Keys.D4)) {
                Settings.m_numberOfPlayers = 4;
            }

            //Debug for cow selection
            if (Keyboard.GetState().IsKeyDown(Keys.D7)){
                TextureHandler.m_player_1_cow = TextureHandler.m_cow1;
                m_player_1_cow.SetTexture(TextureHandler.m_player_1_cow);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D8))
            {
                TextureHandler.m_player_1_cow = TextureHandler.m_cow21;
                m_player_1_cow.SetTexture(TextureHandler.m_player_1_cow);
            }
            
            //Debug for vehicle selection
            if (Keyboard.GetState().IsKeyDown(Keys.V))
            {
                TextureHandler.m_player_1_vehicle = TextureHandler.m_tankGreen;
                m_player_1_vehicle.SetTexture(TextureHandler.m_player_1_vehicle);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                TextureHandler.m_player_1_vehicle = TextureHandler.m_tractorBlue;
                m_player_1_vehicle.SetTexture(TextureHandler.m_player_1_vehicle);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                TextureHandler.m_player_1_vehicle = TextureHandler.m_vehicleBlue;
                m_player_1_vehicle.SetTexture(TextureHandler.m_player_1_vehicle);
            }
            

            Debug.AddText("7 for white cow, 8 for highland", new Vector2(20, 850));
            Debug.AddText("C for car, B for tractor, V for tank", new Vector2(20, 900));
             
			// Update touch input handler
			touchHandler_.Update();

            foreach (TouchLocation tl in touchHandler_.GetTouches()) {

                // TODO: Implement a check to see if the player has released their finger from the screen
                //       perform action when player releases their finger -Dean

                
                
            }
            if (touchHandler_.GetTouches().Count > 0) {
                m_touchState = TouchState.TOUCHING;
                m_lastPosition = touchHandler_.GetTouches()[touchHandler_.GetTouches().Count - 1].Position;
            }

            if (touchHandler_.GetTouches().Count == 0 && m_touchState == TouchState.TOUCHING) {
                switch (m_currentScreen) {
                    case MenuScreenState.MAIN_MENU:
                        // Main Menu screen

                        if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active) {
                            // Go to Player Select
                            m_currentScreen = MenuScreenState.PLAYER_SELECT;
                        }
                        if (m_exitButton.m_touchZone.IsInsideZone(m_lastPosition) && m_exitButton.m_active) {
                            // Close app
                        }
                        if (m_creditsButton.m_touchZone.IsInsideZone(m_lastPosition) && m_creditsButton.m_active) {
                            // Go to Credits
                            m_currentScreen = MenuScreenState.CREDITS;
                        }
                        if (m_optionsButton.m_touchZone.IsInsideZone(m_lastPosition) && m_optionsButton.m_active) {
                            // Go to Options
                            m_currentScreen = MenuScreenState.OPTIONS;
                        }
                        if (m_controlsButton.m_touchZone.IsInsideZone(m_lastPosition) && m_controlsButton.m_active)
                        {
                            // Go to control scheme screen
                            m_currentScreen = MenuScreenState.CONTROLS;
                        }
                        break;
                    case MenuScreenState.PLAYER_SELECT:
                        // Player Select screen
                        if (m_1Button.m_touchZone.IsInsideZone(m_lastPosition) && m_1Button.m_active) {
                            // Set number of players to 1
                            Settings.m_numberOfPlayers = 1;
                        }
                        if (m_2Button.m_touchZone.IsInsideZone(m_lastPosition) && m_2Button.m_active)
                        {
                            // Set number of players to 2
                            Settings.m_numberOfPlayers = 2;
                        }
                        if (m_3Button.m_touchZone.IsInsideZone(m_lastPosition) && m_3Button.m_active)
                        {
                            // Set number of players to 3
                            Settings.m_numberOfPlayers = 3;
                        }
                        if (m_4Button.m_touchZone.IsInsideZone(m_lastPosition) && m_4Button.m_active)
                        {
                            // Set number of players to 4
                            Settings.m_numberOfPlayers = 4;
                        }
                        
                        if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active && Settings.m_numberOfPlayers != 0) {
                            // Go to player 1 character selection
                            m_currentScreen = MenuScreenState.PLAYER_1_SELECT;
                        
                        }
                        if (m_MenuButton.m_touchZone.IsInsideZone(m_lastPosition) && m_MenuButton.m_active) {
                            // Go back to Main Menu
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
                        break;
                    case MenuScreenState.PLAYER_1_SELECT:
                        if (m_Cow1Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow1Button.m_active) {
                            // Set character to first cow
                            TextureHandler.m_player_1_cow = TextureHandler.m_cow1;
                            m_player_1_cow.SetTexture(TextureHandler.m_player_1_cow);
                        }
                        if (m_Cow2Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow2Button.m_active)
                        {
                            // Set character to first cow
                            TextureHandler.m_player_1_cow = TextureHandler.m_cow21;
                            m_player_1_cow.SetTexture(TextureHandler.m_player_1_cow);
                        }
                        
                        if (m_TankButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TankButton.m_active)
                        {
                            //Set player  1's vehicle to the tank
                            TextureHandler.m_player_1_vehicle = TextureHandler.m_tankGreen;
                            m_player_1_vehicle.SetTexture(TextureHandler.m_player_1_vehicle);
                        }
                        if (m_CarButton.m_touchZone.IsInsideZone(m_lastPosition) && m_CarButton.m_active)
                        {
                            //Set player 1's vehicle to the car
                            TextureHandler.m_player_1_vehicle = TextureHandler.m_vehicleBlue;
                            m_player_1_vehicle.SetTexture(TextureHandler.m_player_1_vehicle);
                        }
                        if (m_TractorButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TractorButton.m_active)
                        {
                            //Set player 1's vehicle to the tractor
                            TextureHandler.m_player_1_vehicle = TextureHandler.m_tractorBlue;
                            m_player_1_vehicle.SetTexture(TextureHandler.m_player_1_vehicle);
                        }
                        
                        // If player 1 has selected a character and vehicle
                        if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active
                            && TextureHandler.m_player_1_cow != null && TextureHandler.m_player_1_vehicle != null)
                        {
                            // If there is more than one player continue to other player selection
                            if(Settings.m_numberOfPlayers > 1)
                            {
                                m_currentScreen = MenuScreenState.PLAYER_2_SELECT;
                            }
                            // else go to track selection
                            else
                            {
                                m_currentScreen = MenuScreenState.TRACK_SELECT;
                            }
                        }
                         
                        break;
                    case MenuScreenState.PLAYER_2_SELECT:
                       if (m_Cow1Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow1Button.m_active) {
                            // Set character to first cow
                            TextureHandler.m_player_2_cow = TextureHandler.m_cow1;
                            m_player_2_cow.SetTexture(TextureHandler.m_player_2_cow);
                        }
                       if (m_Cow2Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow2Button.m_active)
                       {
                           // Set character to first cow
                           TextureHandler.m_player_2_cow = TextureHandler.m_cow21;
                           m_player_2_cow.SetTexture(TextureHandler.m_player_2_cow);
                       }
                       
                        // Set player 2's vehicle
                        if (m_TankButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TankButton.m_active)
                        {
                            //Set player  2's vehicle to the tank
                            TextureHandler.m_player_2_vehicle = TextureHandler.m_tankGreen;
                            m_player_2_vehicle.SetTexture(TextureHandler.m_player_2_vehicle);
                        }
                        if (m_CarButton.m_touchZone.IsInsideZone(m_lastPosition) && m_CarButton.m_active)
                        {
                            //Set player 2's vehicle to the car
                            TextureHandler.m_player_2_vehicle = TextureHandler.m_vehicleOrange;
                            m_player_2_vehicle.SetTexture(TextureHandler.m_player_2_vehicle);
                        }
                        if (m_TractorButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TractorButton.m_active)
                        {
                            //Set player 2's vehicle to the tractor
                            TextureHandler.m_player_2_vehicle = TextureHandler.m_tractorBlue;
                            m_player_2_vehicle.SetTexture(TextureHandler.m_player_2_vehicle);
                        }
                        
                        // If player 2 has selected a character and vehicle
                        if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active
                            && TextureHandler.m_player_2_cow != null && TextureHandler.m_player_2_vehicle != null)
                        {
                            // If there is more than two players continue to other player selection
                            if(Settings.m_numberOfPlayers > 2)
                            {
                                m_currentScreen = MenuScreenState.PLAYER_3_SELECT;
                            }
                            // else go to track selection
                            else
                            {
                                m_currentScreen = MenuScreenState.TRACK_SELECT;
                            }
                        }
                        break;
                    case MenuScreenState.PLAYER_3_SELECT:
                        if (m_Cow1Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow1Button.m_active) {
                            // Set character to first cow
                            TextureHandler.m_player_3_cow = TextureHandler.m_cow1;
                            m_player_3_cow.SetTexture(TextureHandler.m_player_3_cow);
                        }
                        if (m_Cow2Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow2Button.m_active)
                        {
                            // Set character to first cow
                            TextureHandler.m_player_3_cow = TextureHandler.m_cow21;
                            m_player_3_cow.SetTexture(TextureHandler.m_player_3_cow);
                        }
                        
                        // Set player 3's vehicle
                        if (m_TankButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TankButton.m_active)
                        {
                            //Set player  3's vehicle to the tank
                            TextureHandler.m_player_3_vehicle = TextureHandler.m_tankGreen;
                            m_player_3_vehicle.SetTexture(TextureHandler.m_player_3_vehicle);
                        }
                        if (m_CarButton.m_touchZone.IsInsideZone(m_lastPosition) && m_CarButton.m_active)
                        {
                            //Set player 3's vehicle to the car
                            TextureHandler.m_player_3_vehicle = TextureHandler.m_vehiclePurple;
                            m_player_3_vehicle.SetTexture(TextureHandler.m_player_3_vehicle);
                        }
                        if (m_TractorButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TractorButton.m_active)
                        {
                            //Set player 3's vehicle to the tractor
                            TextureHandler.m_player_3_vehicle = TextureHandler.m_tractorBlue;
                            m_player_3_vehicle.SetTexture(TextureHandler.m_player_3_vehicle);
                        }
                        
                        // If player 3 has selected a character and vehicle
                        if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active
                            && TextureHandler.m_player_3_cow != null && TextureHandler.m_player_3_vehicle != null)
                        {
                            // If there is more than three players continue to other player selection
                            if(Settings.m_numberOfPlayers > 3)
                            {
                                m_currentScreen = MenuScreenState.PLAYER_4_SELECT;
                            }
                            // else go to track selection
                            else
                            {
                                m_currentScreen = MenuScreenState.TRACK_SELECT;
                            }
                        }
                        break;
                    case MenuScreenState.PLAYER_4_SELECT:
                        if (m_Cow1Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow1Button.m_active) {
                            // Set character to first cow
                            TextureHandler.m_player_4_cow = TextureHandler.m_cow1;
                            m_player_4_cow.SetTexture(TextureHandler.m_player_4_cow);
                        }
                        if (m_Cow2Button.m_touchZone.IsInsideZone(m_lastPosition) && m_Cow2Button.m_active)
                        {
                            // Set character to first cow
                            TextureHandler.m_player_4_cow = TextureHandler.m_cow21;
                            m_player_4_cow.SetTexture(TextureHandler.m_player_4_cow);
                        }
                       
                        // Set player 4's vehicle
                        if (m_TankButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TankButton.m_active)
                        {
                            //Set player  4's vehicle to the tank
                            TextureHandler.m_player_4_vehicle = TextureHandler.m_tankGreen;
                            m_player_4_vehicle.SetTexture(TextureHandler.m_player_4_vehicle);
                        }
                        if (m_CarButton.m_touchZone.IsInsideZone(m_lastPosition) && m_CarButton.m_active)
                        {
                            //Set player 4's vehicle to the car
                            TextureHandler.m_player_4_vehicle = TextureHandler.m_vehicleYellow;
                            m_player_4_vehicle.SetTexture(TextureHandler.m_player_4_vehicle);
                        }
                        if (m_TractorButton.m_touchZone.IsInsideZone(m_lastPosition) && m_TractorButton.m_active)
                        {
                            //Set player 4's vehicle to the tractor
                            TextureHandler.m_player_4_vehicle = TextureHandler.m_tractorBlue;
                            m_player_4_vehicle.SetTexture(TextureHandler.m_player_4_vehicle);
                        }
                        
                        // If player 4 has selected a character and vehicle
                        if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active
                            && TextureHandler.m_player_4_cow != null && TextureHandler.m_player_4_vehicle != null)
                        {
                            // Go to track selection
                                m_currentScreen = MenuScreenState.TRACK_SELECT;
                            
                        }
                        break;
                    case MenuScreenState.TRACK_SELECT:
                        // Track Select screen

                        if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active) {
                            // Start the game
                            m_currentExecutionState = ExecutionState.CHANGING;
                        }
                        if (m_MenuButton.m_touchZone.IsInsideZone(m_lastPosition) && m_MenuButton.m_active) {
                            // Go back to Player Select
                            m_currentScreen = MenuScreenState.PLAYER_SELECT;
                        }
                        break;
                    case MenuScreenState.OPTIONS:
                        // Options screen

                        if (m_MenuButton.m_touchZone.IsInsideZone(m_lastPosition) && m_MenuButton.m_active) {
                            // Go back to Main Menu
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
                        break;
                    case MenuScreenState.CONTROLS:
                        // Controls Screen
                        if (m_MenuButton.m_touchZone.IsInsideZone(m_lastPosition) && m_MenuButton.m_active)
                        {
                            // Go back to the main Menu
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
                        break;
                    case MenuScreenState.CREDITS:
                        // Credits screen

                        if (m_MenuButton.m_touchZone.IsInsideZone(m_lastPosition) && m_MenuButton.m_active) {
                            // Go back to Main Menu
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
                        break;
                }

                m_touchState = TouchState.IDLE;
            }
            // Update sprites
            /*foreach (AnimatedSprite anim in m_animatedSprites) {
                // If currently animating
                if (anim.GetCurrentState() == 1) {
                    // Change the frame
                    if (gameTime_.TotalGameTime.TotalMilliseconds - anim.GetLastTime() > anim.GetFrameTime()) {
                        anim.ChangeFrame(gameTime_.TotalGameTime.TotalMilliseconds);
                    }
                }
            }*/

            // Update particles
            //m_particles = GraphicsHandler.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);
		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			// ================
			
			// Clear the screen
            graphicsDevice_.Clear(Color.LawnGreen);

            // Render graphics
            GraphicsHandler.StartDrawing();

            // Draw sprites
            GraphicsHandler.DrawSprite(m_background);
            GraphicsHandler.DrawSprite(m_teamLogo);
            //GraphicsHandler.DrawSprite(m_gameLogo);

            // Draw buttons
            switch (m_currentScreen) {
                case MenuScreenState.MAIN_MENU:
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_optionsButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_exitButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_creditsButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_controlsButton.m_sprite);
                    break;
                case MenuScreenState.PLAYER_SELECT:
                    GraphicsHandler.DrawText("Player Selection", new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.50f), Color.Black);
                    GraphicsHandler.DrawText("Number of Players: " + Settings.m_numberOfPlayers.ToString(), new Vector2(Settings.m_screenWidth * 0.475f, Settings.m_screenHeight * 0.5625f), Color.Black);
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_MenuButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_1Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_2Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_3Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_4Button.m_sprite);
                    break;
                case MenuScreenState.PLAYER_1_SELECT:
                    GraphicsHandler.DrawText("Player 1 select", new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), Color.Black);
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow1Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow2Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_TankButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_CarButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_TractorButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_player_1_vehicle);
                    GraphicsHandler.DrawSprite(m_player_1_cow);
                    GraphicsHandler.DrawText("PLAYER 1", new Vector2(Settings.m_screenWidth * 0.50f - 30.0f, Settings.m_screenHeight * 0.80f), Color.DarkBlue);
                    
                    
                    break;
                case MenuScreenState.PLAYER_2_SELECT:
                    GraphicsHandler.DrawText("Player 2 select", new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), Color.Black);
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow1Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow2Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_TankButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_CarButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_TractorButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_player_2_vehicle);
                    GraphicsHandler.DrawSprite(m_player_2_cow);
                    GraphicsHandler.DrawText("PLAYER 2", new Vector2(Settings.m_screenWidth * 0.50f - 30.0f, Settings.m_screenHeight * 0.80f), Color.DarkBlue);
                    break;
                case MenuScreenState.PLAYER_3_SELECT:
                    GraphicsHandler.DrawText("Player 3 select", new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), Color.Black);
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow1Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow2Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_TankButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_CarButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_TractorButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_player_3_vehicle);
                    GraphicsHandler.DrawSprite(m_player_3_cow);
                    GraphicsHandler.DrawText("PLAYER 3", new Vector2(Settings.m_screenWidth * 0.50f - 30.0f, Settings.m_screenHeight * 0.80f), Color.DarkBlue);
                    break;
                case MenuScreenState.PLAYER_4_SELECT:
                    GraphicsHandler.DrawText("Player 4 select", new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), Color.Black);
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow1Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_Cow2Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_TankButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_CarButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_TractorButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_player_4_vehicle);
                    GraphicsHandler.DrawSprite(m_player_4_cow);
                    GraphicsHandler.DrawText("PLAYER 4", new Vector2(Settings.m_screenWidth * 0.50f - 30.0f, Settings.m_screenHeight * 0.80f), Color.DarkBlue);
                    break;
                case MenuScreenState.TRACK_SELECT:
                    GraphicsHandler.DrawText("Track Selection", new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), Color.Black);
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_MenuButton.m_sprite);
                    // Insert buttons for playable tracks
                    break;
                case MenuScreenState.OPTIONS:
                    // Insert buttons for options
                    GraphicsHandler.DrawText("Options", new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), Color.Black);
                    GraphicsHandler.DrawSprite(m_MenuButton.m_sprite);
                    break;
                case MenuScreenState.CONTROLS:
                    // Insert control scheme layout
                    GraphicsHandler.DrawText("Controls", new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), Color.Black);
                    GraphicsHandler.DrawSprite(m_control_scheme);
                    GraphicsHandler.DrawSprite(m_MenuButton.m_sprite);
                    break;
                case MenuScreenState.CREDITS:
                    // Insert text for credits
                    GraphicsHandler.DrawText("Team Leader: Dean Sinclair", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f), Color.Black);
                    GraphicsHandler.DrawText("Producer: Dwyer McNally", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 25), Color.Black);
                    GraphicsHandler.DrawText("Programmers:", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 50), Color.Black);
                    GraphicsHandler.DrawText("            Daniel Divers", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 70), Color.Black);
                    GraphicsHandler.DrawText("            Cameron Fleming:", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 90), Color.Black);
                    GraphicsHandler.DrawText("            Nathan Headley", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 110), Color.Black);
                    GraphicsHandler.DrawText("            Dean Sinclair", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 130), Color.Black);
                    GraphicsHandler.DrawText("            Cemre Tekpinar", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 150), Color.Black);
                    GraphicsHandler.DrawText("Game Design: Dwyer McNally", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 175), Color.Black);
                    GraphicsHandler.DrawText("Art: Gillian Annandale", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 200), Color.Black);
                    GraphicsHandler.DrawText("Audio: Russell Ferguson", new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight * 0.4f + 225), Color.Black);
                    GraphicsHandler.DrawSprite(m_MenuButton.m_sprite);
                    break;
            }
            

            // Draw animated sprites
            foreach (AnimatedSprite anim_ in m_animatedSprites) {
                if (anim_.IsVisible()) {
                    GraphicsHandler.DrawAnimatedSprite(anim_);
                }
            }

            // Draw particles
            foreach (Particle part_ in m_particles) {
                if (part_.GetLife() > 0) {
                    //GraphicsHandler.DrawParticle(/*texture,*/ part_.GetPosition(), Color.White);
                }
            }

            // Stop rendering
            GraphicsHandler.StopDrawing();
		}

		protected override void CleanUp() {
			// Clean up any objects
			// ================

			throw new NotImplementedException();
		}

		// Getters
		public override GameState GetState() { return m_currentState; }

		public override GameState GetNextState() { return m_nextState; }

		public override ExecutionState GetExecutionState() { return m_currentExecutionState; }

		// Setters

	}

	enum MenuScreenState {
		// Enum for each type of menu screen
		// ================
		MAIN_MENU,
		PLAYER_SELECT,
        PLAYER_1_SELECT,
        PLAYER_2_SELECT,
        PLAYER_3_SELECT,
        PLAYER_4_SELECT,
		TRACK_SELECT,
		OPTIONS,
        CONTROLS,
		CREDITS
	}

    enum TouchState {
        // Enum for each touch state
        // ================
        IDLE,
        TOUCHING,
        RELEASED
    }
}
