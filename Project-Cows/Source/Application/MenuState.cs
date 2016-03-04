// Project: Cow Racing -- GearShift Games
// Written by D. Sinclair, 2016
//            N. Headley, 2016
//            C. Fleming, 2016
// ================
// MenuState.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        // Sprites
        private Sprite m_background;
        private Sprite m_teamLogo;
        private Sprite m_gameLogo;
        // Buttons
        private Button m_playButton;
        private Button m_optionsButton;
        private Button m_exitButton;
        private Button m_backButton;
        private Button m_creditsButton;
        private Button m_1Button;
        private Button m_2Button;
        private Button m_3Button;
        private Button m_4Button;

        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Particle> m_particles = new List<Particle>();

		// Methods
        public MenuState() : base() {
			// MenuState constructor
			// ================

			m_currentState = GameState.MAIN_MENU;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

        public override void Initialise() {
			// Initialise menu state
			// ================

            // Initialise sprites
            m_background = new Sprite(TextureHandler.m_menuBackground, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
            m_teamLogo = new Sprite(TextureHandler.m_teamLogo, new Vector2(Settings.m_screenWidth / 1.2f, Settings.m_screenHeight / 6), 0, Vector2.One);
            //m_gameLogo = new Sprite(TextureHandler.m_gameLogo, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);

            // Initialise buttons
            m_playButton =      new Button(TextureHandler.m_menuPlay,       new Vector2(Settings.m_screenWidth * 0.25f, Settings.m_screenHeight * 0.75f));
            m_optionsButton =   new Button(TextureHandler.m_menuOptions,    new Vector2(Settings.m_screenWidth * 0.50f, Settings.m_screenHeight * 0.75f));
            m_exitButton =      new Button(TextureHandler.m_menuExit,       new Vector2(Settings.m_screenWidth * 0.75f, Settings.m_screenHeight * 0.75f));
            m_backButton =      new Button(TextureHandler.m_menuBack,       new Vector2(Settings.m_screenWidth * 0.75f, Settings.m_screenHeight * 0.75f));
            m_creditsButton =   new Button(TextureHandler.m_menuCredits,    new Vector2(Settings.m_screenWidth * 0.90f, Settings.m_screenHeight * 0.90f));
            m_1Button =         new Button(TextureHandler.m_menu1,          new Vector2(Settings.m_screenWidth * 0.33f, Settings.m_screenHeight * 0.25f));
            m_2Button =         new Button(TextureHandler.m_menu2,          new Vector2(Settings.m_screenWidth * 0.66f, Settings.m_screenHeight * 0.25f));
            m_3Button =         new Button(TextureHandler.m_menu3,          new Vector2(Settings.m_screenWidth * 0.33f, Settings.m_screenHeight * 0.50f));
            m_4Button =         new Button(TextureHandler.m_menu4,          new Vector2(Settings.m_screenWidth * 0.66f, Settings.m_screenHeight * 0.50f));

			// Set menu screen
			m_currentScreen = MenuScreenState.MAIN_MENU;

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

            Debug.AddText("Players: " + Settings.m_numberOfPlayers.ToString(), new Vector2(20, 800));
             
			// Update touch input handler
			touchHandler_.Update();

			foreach(TouchLocation tl in touchHandler_.GetTouches()) {

                // TODO: Implement a check to see if the player has released their finger from the screen
                //       perform action when player releases their finger -Dean
				

				switch(m_currentScreen) {
					case MenuScreenState.MAIN_MENU:
                        // Main Menu screen

                        if (m_playButton.m_touchZone.IsInsideZone(tl.Position) && m_playButton.m_active) {
                            // Go to Player Select
                            m_currentScreen = MenuScreenState.PLAYER_SELECT;
                        }
                        if (m_exitButton.m_touchZone.IsInsideZone(tl.Position) && m_exitButton.m_active) {
                            // Close app
                        }
                        if (m_creditsButton.m_touchZone.IsInsideZone(tl.Position) && m_creditsButton.m_active) {
                            // Go to Credits
                            m_currentScreen = MenuScreenState.CREDITS;
                        }
                        if (m_optionsButton.m_touchZone.IsInsideZone(tl.Position) && m_optionsButton.m_active) {
                            // Go to Options
                            m_currentScreen = MenuScreenState.OPTIONS;
                        }
						break;
					case MenuScreenState.PLAYER_SELECT:
                        // Player Select screen

                        if (m_playButton.m_touchZone.IsInsideZone(tl.Position) && m_playButton.m_active) {
                            // Go to Track Select
                            m_currentScreen = MenuScreenState.TRACK_SELECT;
                        }
                        if (m_backButton.m_touchZone.IsInsideZone(tl.Position) && m_backButton.m_active) {
                            // Go back to Main Menu
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
						break;
					case MenuScreenState.TRACK_SELECT:
                        // Track Select screen

                        if (m_playButton.m_touchZone.IsInsideZone(tl.Position) && m_playButton.m_active) {
                            // Start the game
                            m_currentExecutionState = ExecutionState.CHANGING;
                        }
                        if (m_backButton.m_touchZone.IsInsideZone(tl.Position) && m_backButton.m_active) {
                            // Go back to Player Select
                            m_currentScreen = MenuScreenState.PLAYER_SELECT;
                        }
						break;
					case MenuScreenState.OPTIONS:
                        // Options screen

                        if (m_backButton.m_touchZone.IsInsideZone(tl.Position) && m_backButton.m_active) {
                            // Go back to Main Menu
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
						break;
					case MenuScreenState.CREDITS:
                        // Credits screen

                        if (m_backButton.m_touchZone.IsInsideZone(tl.Position) && m_backButton.m_active) {
                            // Go back to Main Menu
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
                        break;
				}
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
            graphicsDevice_.Clear(Color.Crimson);

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
                    break;
                case MenuScreenState.PLAYER_SELECT:
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_backButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_1Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_2Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_3Button.m_sprite);
                    GraphicsHandler.DrawSprite(m_4Button.m_sprite);
                    break;
                case MenuScreenState.TRACK_SELECT:
                    GraphicsHandler.DrawSprite(m_playButton.m_sprite);
                    GraphicsHandler.DrawSprite(m_backButton.m_sprite);
                    // Insert buttons for playable tracks
                    break;
                case MenuScreenState.OPTIONS:
                    // Insert buttons for options
                    GraphicsHandler.DrawSprite(m_backButton.m_sprite);
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
                    GraphicsHandler.DrawSprite(m_backButton.m_sprite);
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
		TRACK_SELECT,
		OPTIONS,
		CREDITS
	}
}
