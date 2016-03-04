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
        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Sprite> m_sprites = new List<Sprite>();
        private List<Particle> m_particles = new List<Particle>();

        // Touch zones for button locations
        private TouchZone Play, Option, Exit, Back, Credit;
        private TouchZone one, two, three, four;

        private Texture2D playerSelectIcon;

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

            // Initialise Player List
            // Initialise players
           // m_players = new List<Player>();
           // m_players.Clear();


            playerSelectIcon = GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\controlTemp");
            //Initialise sprites
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Backgrounds\\Menu"), new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, new Vector2(0.5f, 0.5f)));
            // m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Title"), new Vector2(Settings.m_screenWidth / 2, 200.0f), 0, new Vector2(1.0f, 1.0f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\Play"), new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, new Vector2(1.5f, 1.5f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\Options"), new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2 + 110), 0, new Vector2(1.5f, 1.5f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\Exit"), new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2 + 330), 0, new Vector2(1.5f, 1.5f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Promo\\Logo"), new Vector2(Settings.m_screenWidth - 150.0f, 75.0f), 0, new Vector2(0.5f, 0.5f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\Back"), new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2 + 330), 0, new Vector2(1.5f, 1.5f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\Credits"), new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2 + 220), 0, new Vector2(1.5f, 1.5f)));

            //Initialise Player selection sprites
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Vehicles\\V2_Cow_Highland_Brown"), new Vector2(800.0f, 500.0f), 0, new Vector2(0.25f, 0.25f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Vehicles\\V2_Cow_Plain"), new Vector2(1200.0f, 500.0f), 0, new Vector2(0.5f, 0.5f)));

            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\1"), new Vector2(Settings.m_screenWidth / 2 - 50, Settings.m_screenHeight / 2 + 115), 0, new Vector2(1.0f, 1.0f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\2"), new Vector2(Settings.m_screenWidth / 2 + 50, Settings.m_screenHeight / 2 + 115), 0, new Vector2(1.0f, 1.0f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\3"), new Vector2(Settings.m_screenWidth / 2 - 50, Settings.m_screenHeight / 2 + 215), 0, new Vector2(1.0f, 1.0f)));
            m_sprites.Add(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Menu\\4"), new Vector2(Settings.m_screenWidth / 2 + 50, Settings.m_screenHeight / 2 + 215), 0, new Vector2(1.0f, 1.0f)));

           // m_sprites.Add(new Sprite(playerSelectIcon, new Vector2(m_players[0].m_controlScheme.GetTouchZone().GetMax().X / 2, m_players[0].m_controlScheme.GetTouchZone().GetMax().Y / 2), 0, new Vector2(1.0f, 1.0f)));
            
            // Initialise button touch zones
            
            
            
            
            
            // Initialise player touch zones
            one = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").GetPosition(),
                new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").GetHeight()));
            two = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").GetPosition(),
                new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").GetHeight()));
            three = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").GetPosition(),
                new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").GetHeight()));
            four = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").GetPosition(),
                new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").GetHeight()));

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

            // Debug Purposes
            
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                m_currentScreen = MenuScreenState.MAIN_MENU;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                m_currentScreen = MenuScreenState.PLAYER_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                m_currentScreen = MenuScreenState.TRACK_SELECT;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                m_currentScreen = MenuScreenState.OPTIONS;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                m_currentScreen = MenuScreenState.CREDITS;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
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
						// TODO:
                        // If play button is pressed and play button is visible go to player select screen
                        if (Play.IsInsideZone(tl.Position) 
                            && m_sprites.Find(x => x.GetTexture().Name == "Play").IsVisible() == true)
                        {
                            m_currentScreen = MenuScreenState.PLAYER_SELECT;
                        }
                        // If Exit button is pressed and exit button is visible exit the application
                        if (Exit.IsInsideZone(tl.Position)
                            && m_sprites.Find(x => x.GetTexture().Name == "Exit").IsVisible() == true)
                        {
                            // Close the application
                            
                        }
                        // If the credits button is pressed and credits button is visible go to the credits screen
                        if (Credit.IsInsideZone(tl.Position)
                            && m_sprites.Find(x => x.GetTexture().Name == "Play").IsVisible() == true)
                        {
                            m_currentScreen = MenuScreenState.CREDITS;
                        }
                        if (Option.IsInsideZone(tl.Position)
                            && m_sprites.Find(x => x.GetTexture().Name == "Options").IsVisible() == true)
                        {
                            m_currentScreen = MenuScreenState.OPTIONS;
                        }
						break;
					case MenuScreenState.PLAYER_SELECT:
                        /*
                        if (one.IsInsideZone(tl.Position))
                        {
                            numPlayers = 1;
                        }
                        if (two.IsInsideZone(tl.Position))
                        {
                            numPlayers = 2;
                        }
                        if (three.IsInsideZone(tl.Position))
                        {
                            numPlayers = 3;
                        }
                        if (four.IsInsideZone(tl.Position))
                        {
                            numPlayers = 4;
                        }*/
						if (Play.IsInsideZone(tl.Position) 
                            && m_sprites.Find(x => x.GetTexture().Name == "Play").IsVisible() == true /*&& numPlayers != 0*/)
                        {
                            m_currentScreen = MenuScreenState.TRACK_SELECT;
                        }
                       
                        // If the Back button is pressed and Back button is visible go to the credits screen
                        if (Back.IsInsideZone(tl.Position)
                            && m_sprites.Find(x => x.GetTexture().Name == "Back").IsVisible() == true)
                        {
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
						break;
					case MenuScreenState.TRACK_SELECT:
						if (Play.IsInsideZone(tl.Position) 
                            && m_sprites.Find(x => x.GetTexture().Name == "Play").IsVisible() == true)
                        {
                            m_currentExecutionState = ExecutionState.CHANGING;
                        }
                        
                        // If the Back button is pressed and Back button is visible go to the credits screen
                        if (Back.IsInsideZone(tl.Position)
                            && m_sprites.Find(x => x.GetTexture().Name == "Back").IsVisible() == true)
                        {
                            m_currentScreen = MenuScreenState.PLAYER_SELECT;
                        }
						break;
					case MenuScreenState.OPTIONS:
                        // If the Back button is pressed and Back button is visible go to the credits screen
                        if (Back.IsInsideZone(tl.Position)
                            && m_sprites.Find(x => x.GetTexture().Name == "Back").IsVisible() == true)
                        {
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
						break;
					case MenuScreenState.CREDITS:
                        // If the Back button is pressed and Back button is visible go to the credits screen
                        if (Back.IsInsideZone(tl.Position)
                            && m_sprites.Find(x => x.GetTexture().Name == "Back").IsVisible() == true)
                        {
                            m_currentScreen = MenuScreenState.MAIN_MENU;
                        }
						break;
				}
			}
            // Possibly not needed?
			// Update screen (change options, animations, etc.)
			switch(m_currentScreen) {
				case MenuScreenState.MAIN_MENU:

                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetPosition(new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2));

                    Play = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetHeight()));
                    Option = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").GetHeight()));
                    Credit = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").GetHeight()));
                    Exit = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").GetHeight()));
					// Reposition sprites to draw main menu
                    /*
                    m_sprites.Find(x => x.GetTexture().Name == "Menu").SetPosition(new Vector2(1000.0f, 500.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Title").SetPosition(new Vector2(1000.0f, 200.0f));
                    
                    m_sprites.Find(x => x.GetTexture().Name == "Options").SetPosition(new Vector2(1000.0f, 460.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Exit").SetPosition(new Vector2(1000.0f, 520.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Logo").SetPosition(new Vector2(1000.0f, 950.0f));
                    */
					break;
				case MenuScreenState.PLAYER_SELECT:

                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetPosition(new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2 + 100));

                    Play = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetHeight()));
                    Back = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetHeight()));
					// Reposition sprites to draw player select screen
                    /*
                    m_sprites.Find(x => x.GetTexture().Name == "Menu").SetPosition(new Vector2(1000.0f, 500.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Play").SetPosition(new Vector2(1000.0f, 400.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Back").SetPosition(new Vector2(1000.0f, 800.0f));
                     * */
					break;
				case MenuScreenState.TRACK_SELECT:

                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetPosition(new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2 + 200));

                    Play = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").GetHeight()));
                    Back = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetHeight()));
					// Reposition sprites to draw track select screen
                    /*
                    m_sprites.Find(x => x.GetTexture().Name == "Menu").SetPosition(new Vector2(1000.0f, 500.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Play").SetPosition(new Vector2(1000.0f, 400.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Back").SetPosition(new Vector2(1000.0f, 800.0f));
                     * */
					break;
				case MenuScreenState.OPTIONS:
                    Back = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetHeight()));
					// Reposition sprites to draw options screen
                    /*
                    m_sprites.Find(x => x.GetTexture().Name == "Menu").SetPosition(new Vector2(1000.0f, 500.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Back").SetPosition(new Vector2(1000.0f, 800.0f));
                     * */
					break;
				case MenuScreenState.CREDITS:
                    Back = new TouchZone(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition(),
               new Vector2(m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().X + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetWidth(),
                           m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetPosition().Y + m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").GetHeight()));
					// Reposition sprites to draw credits screen
                    /*
                    m_sprites.Find(x => x.GetTexture().Name == "Menu").SetPosition(new Vector2(1000.0f, 500.0f));
                    m_sprites.Find(x => x.GetTexture().Name == "Back").SetPosition(new Vector2(1000.0f, 800.0f));
                     * */
					break;
			}

            // Update sprites
            foreach (AnimatedSprite anim in m_animatedSprites) {
                // If currently animating
                if (anim.GetCurrentState() == 1) {
                    // Change the frame
                    if (gameTime_.TotalGameTime.TotalMilliseconds - anim.GetLastTime() > anim.GetFrameTime()) {
                        anim.ChangeFrame(gameTime_.TotalGameTime.TotalMilliseconds);
                    }
                }
            }

            // Update particles
            m_particles = GraphicsHandler.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);


		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			// ================
			
			// Clear the screen
			graphicsDevice_.Clear(Color.Crimson);

			switch(m_currentScreen) {
				case MenuScreenState.MAIN_MENU:
					// TODO: Render screen
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Promo\\Logo").SetVisible(true);
                   // m_sprites.Find(x => x.GetTexture().Name == "Title").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Highland_Brown").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Plain").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").SetVisible(false);
					break;
				case MenuScreenState.PLAYER_SELECT:
					// TODO: Render screen
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Promo\\Logo").SetVisible(false);
                  //  m_sprites.Find(x => x.GetTexture().Name == "Title").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Highland_Brown").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Plain").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").SetVisible(false);
					break;
				case MenuScreenState.TRACK_SELECT:
					// TODO: Render screen
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Promo\\Logo").SetVisible(false);
                  //  m_sprites.Find(x => x.GetTexture().Name == "Title").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Highland_Brown").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Plain").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").SetVisible(false);
					break;
				case MenuScreenState.OPTIONS:
					// TODO: Render screen
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Promo\\Logo").SetVisible(false);
                  //  m_sprites.Find(x => x.GetTexture().Name == "Title").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Highland_Brown").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Plain").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").SetVisible(false);
					break;
				case MenuScreenState.CREDITS:
					// TODO: Render screen
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Back").SetVisible(true);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Promo\\Logo").SetVisible(false);
                 //   m_sprites.Find(x => x.GetTexture().Name == "Title").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Play").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Options").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Credits").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\Exit").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Highland_Brown").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Vehicles\\V2_Cow_Plain").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\1").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\2").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\3").SetVisible(false);
                    m_sprites.Find(x => x.GetTexture().Name == "Sprites\\Menu\\4").SetVisible(false);
					break;
			}

            // Render graphics
            GraphicsHandler.StartDrawing();

            foreach (AnimatedSprite anim_ in m_animatedSprites) {
                if (anim_.IsVisible()) {
                    GraphicsHandler.DrawAnimatedSprite(anim_);
                }
            }
            foreach (Sprite sprite_ in m_sprites) {
                if (sprite_.IsVisible()) {
                    GraphicsHandler.DrawSprite(sprite_);
                }
            }
            foreach (Particle part_ in m_particles) {
                if (part_.GetLife() > 0) {
                    //GraphicsHandler.DrawParticle(/*texture,*/ part_.GetPosition(), Color.White);
                }
            }

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
