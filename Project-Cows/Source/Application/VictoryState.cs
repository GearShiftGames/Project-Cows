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
/// VictoryState.cs

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
	class VictoryState : State {
		// Class to handle the victory state of the game
		// ================

		// Variables
        private TouchState m_touchState;
        private Vector2 m_lastPosition;

        // Sprites
        private Sprite m_background;
        private Sprite m_podium;
        private Sprite m_playerFirst;
        private Sprite m_playerSecond;
        private Sprite m_playerThird;
        private Sprite m_leaderboard;

        // Buttons 
        private Button m_playButton;
        private Button m_menuButton;

        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Particle> m_particles = new List<Particle>();

		// Methods
		public VictoryState() : base() {
			// VictoryState constructor
			// ================

			m_currentState = GameState.VICTORY_SCREEN;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

		public override void Initialise() {
			// Initialise victory state
			// ================
            // Initialise Sprites
            
            m_background = new Sprite(TextureHandler.m_victoryBackground, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
 //           m_playerFirst = new Sprite(/* winner's cow goes here */, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
 //           m_playerSecond = new Sprite(/* second place cow goes here */, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
 //           m_playerThird = new Sprite(/* Third place cow goes here */, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
 //           m_leaderboard = new Sprite(/* leaderboard image goes here */, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
 //           // Initialise Buttons
            m_playButton = new Button(TextureHandler.m_menuPlay,       new Vector2(Settings.m_screenWidth * 0.25f, Settings.m_screenHeight * 0.8f));
            m_menuButton = new Button(TextureHandler.m_menuOptions,       new Vector2(Settings.m_screenWidth * 0.75f, Settings.m_screenHeight * 0.8f));



            m_touchState = TouchState.IDLE;

			// Set initial next state
			m_nextState = GameState.MAIN_MENU;

			// Change execution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

        public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_) {
			// Update victory state
			// ================

			// Update touch input handler
			touchHandler_.Update();

			foreach(TouchLocation tl in touchHandler_.GetTouches()) {

                // TODO: Implement a check to see if the player has released their finger from the screen
                //       perform action when player releases their finger -Dean
			}
            if (touchHandler_.GetTouches().Count > 0) { 
                m_touchState = TouchState.TOUCHING;
                m_lastPosition = touchHandler_.GetTouches()[touchHandler_.GetTouches().Count - 1].Position;
            }
            if (touchHandler_.GetTouches().Count == 0 && m_touchState == TouchState.TOUCHING) { 
                // If play button is pressed, launch back into race
                if (m_playButton.m_touchZone.IsInsideZone(m_lastPosition) && m_playButton.m_active) {
                    m_nextState = GameState.IN_GAME;
                }
                // If Menu button is pressed, go back to the main menu
                if (m_menuButton.m_touchZone.IsInsideZone(m_lastPosition) && m_menuButton.m_active) {
                    m_nextState = GameState.MAIN_MENU;
                }
                // Change to the appropriate screen
                m_currentExecutionState = ExecutionState.CHANGING;

                m_touchState = TouchState.IDLE;
            }

            // Isn't used for the victory screen, i think
            // Update sprites
    //        foreach (AnimatedSprite anim in m_animatedSprites) {
    //          // If currently animating
    //            if (anim.GetCurrentState() == 1) {
    //                // Change the frame
    //                if (gameTime_.TotalGameTime.TotalMilliseconds - anim.GetLastTime() > anim.GetFrameTime()) {
    //                    anim.ChangeFrame(gameTime_.TotalGameTime.TotalMilliseconds);
    //                }
    //            }
    //        }

            // Update particles
    //        m_particles = GraphicsHandler.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);

		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			// ================

			// Clear the screen
            graphicsDevice_.Clear(Color.LawnGreen);

            // Render graphics
            GraphicsHandler.StartDrawing();

            // Draw all sprites to the screen
            GraphicsHandler.DrawSprite(m_background);
         //   GraphicsHandler.DrawSprite(m_podium);
         //   GraphicsHandler.DrawSprite(m_playerFirst);
          //  GraphicsHandler.DrawSprite(m_playerSecond);
          //  GraphicsHandler.DrawSprite(m_playerThird);
          //  GraphicsHandler.DrawSprite(m_leaderboard);
            GraphicsHandler.DrawSprite(m_playButton.m_sprite);
            GraphicsHandler.DrawSprite(m_menuButton.m_sprite);

            foreach (AnimatedSprite anim_ in m_animatedSprites) {
                if (anim_.IsVisible()) {
                    GraphicsHandler.DrawAnimatedSprite(anim_);
                }
            }
            foreach (Particle part_ in m_particles) {
                if (part_.GetLife() > 0) {
                    //graphicsHandler_.DrawParticle(/*texture,*/ part_.GetPosition(), Color.White);
                }
            }
            GraphicsHandler.DrawText("VICTORY STATE", new Vector2(100.0f, 100.0f), Color.Red);

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
}
