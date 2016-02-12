// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
//            N. Headley, 2016
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

        

		// Methods
        public MenuState() : base() {
			// MenuState constructor
			// ================

			m_currentState = GameState.MAIN_MENU;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

        public override void Initialise(ContentManager content_)
        {
			// Initialise menu state
			// ================

            //Initialise sprites

			// Set menu screen
			m_currentScreen = MenuScreenState.MAIN_MENU;

			// Set initial next state
			m_nextState = GameState.IN_GAME;

			// Change exectution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

		public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_, ref GraphicsHandler graphicsHandler_) {
			// Update menu state
			// ================

			// Update touch input handler
			touchHandler_.Update();

			// NOTE: Possibly expand this state with subclasses/states for each screen, depending on
			//       how cluttered this class becomes -Dean
			foreach(TouchLocation tl in touchHandler_.GetTouches()) {

				

				switch(m_currentScreen) {
					case MenuScreenState.MAIN_MENU:
						// TODO:
						// Check for each button/touchable area if position is within it
							// If within area check if button/area has been touched already this frame
								// If not touched
									// Run specific code for button/area
						break;
					case MenuScreenState.PLAYER_SELECT:
						// TODO:
						// Check for each button/touchable area if position is within it
							// If within area check if button/area has been touched already this frame
								// If not touched
									// Run specific code for button/area
						break;
					case MenuScreenState.TRACK_SELECT:
						// TODO:
						// Check for each button/touchable area if position is within it
							// If within area check if button/area has been touched already this frame
								// If not touched
									// Run specific code for button/area
						break;
					case MenuScreenState.OPTIONS:
						// TODO:
						// Check for each button/touchable area if position is within it
							// If within area check if button/area has been touched already this frame
								// If not touched
									// Run specific code for button/area
						break;
					case MenuScreenState.CREDITS:
						// TODO:
						// Check for each button/touchable area if position is within it
							// If within area check if button/area has been touched already this frame
								// If not touched
									// Run specific code for button/area
						break;
				}
			}

			// Update screen (change options, animations, etc.)
			switch(m_currentScreen) {
				case MenuScreenState.MAIN_MENU:
					// TODO: Run code specific to this screen
					break;
				case MenuScreenState.PLAYER_SELECT:
					// TODO: Run code specific to this screen
					break;
				case MenuScreenState.TRACK_SELECT:
					// TODO: Run code specific to this screen
					break;
				case MenuScreenState.OPTIONS:
					// TODO: Run code specific to this screen
					break;
				case MenuScreenState.CREDITS:
					// TODO: Run code specific to this screen
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
            m_particles = graphicsHandler_.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);


		}

		public override void Draw(GraphicsDevice graphicsDevice_, ref GraphicsHandler graphicsHandler_) {
			// Render objects to the screen
			// ================
			
			// Clear the screen
			graphicsDevice_.Clear(Color.Crimson);

			switch(m_currentScreen) {
				case MenuScreenState.MAIN_MENU:
					// TODO: Render screen
					break;
				case MenuScreenState.PLAYER_SELECT:
					// TODO: Render screen
					break;
				case MenuScreenState.TRACK_SELECT:
					// TODO: Render screen
					break;
				case MenuScreenState.OPTIONS:
					// TODO: Render screen
					break;
				case MenuScreenState.CREDITS:
					// TODO: Render screen
					break;
			}

            // Render graphics
            graphicsHandler_.StartDrawing();

            foreach (AnimatedSprite anim_ in m_animatedSprites) {
                if (anim_.IsVisible()) {
                    graphicsHandler_.DrawAnimatedSprite(anim_);
                }
            }
            foreach (Sprite sprite_ in m_sprites) {
                if (sprite_.IsVisible()) {
                    graphicsHandler_.DrawSprite(sprite_);
                }
            }
            foreach (Particle part_ in m_particles) {
                if (part_.GetLife() > 0) {
                    //graphicsHandler_.DrawParticle(/*texture,*/ part_.GetPosition(), Color.White);
                }
            }
            graphicsHandler_.DrawText("MENU STATE", new Vector2(100.0f, 100.0f), Color.Red);

            graphicsHandler_.StopDrawing();
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
