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
using Microsoft.Xna.Framework.Input.Touch;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Particles;
using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;
using Project_Cows.Source.Application.Track;

namespace Project_Cows.Source.Application {
	class VictoryState : State {
		// Class to handle the victory state of the game
		// ================

		// Variables
        private TouchState m_touchState;
        private Vector2 m_lastPosition;

        // Sprites
        private Sprite m_background;
        private Sprite m_leaderboard;   
        private Sprite m_playerFirst;
        private Sprite m_playerSecond;
        private Sprite m_playerThird;
        private Sprite m_goldTrophy;
        private Sprite m_silverTrophy;
        private Sprite m_bronzeTrophy;

        // Buttons 
        private Button m_Race_Again_Button;
        private Button m_Main_Menu_Button;

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
            
            m_background        = new Sprite(TextureHandler.m_victoryBackground,   new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0, Vector2.One);
            m_leaderboard       = new Sprite(TextureHandler.m_leaderboard,         new Vector2(Settings.m_screenWidth * 0.25f + 20, Settings.m_screenHeight * 0.25f), 0, new Vector2(1.5f,1.5f));
            m_goldTrophy        = new Sprite(TextureHandler.m_trophyFirst,         new Vector2(Settings.m_screenWidth * 0.75f - 20, Settings.m_screenHeight * 0.05f + 20), 0, new Vector2(0.5f,0.5f));
            m_silverTrophy      = new Sprite(TextureHandler.m_trophySecond,        new Vector2(Settings.m_screenWidth * 0.65f - 25 , Settings.m_screenHeight * 0.25f - 40), 0, new Vector2(0.5f, 0.5f));
            m_bronzeTrophy      = new Sprite(TextureHandler.m_trophyThird,         new Vector2(Settings.m_screenWidth * 0.85f, Settings.m_screenHeight * 0.35f), 0, new Vector2(0.5f, 0.5f));

            // Set player podium textures to default cows
            m_playerFirst       = new Sprite(TextureHandler.m_cow1,                new Vector2(Settings.m_screenWidth * 0.75f - 20, Settings.m_screenHeight * 0.25f - 40), 180, new Vector2(0.75f,0.75f));
           
            if (Settings.m_numberOfPlayers > 1) {
                m_playerSecond = new Sprite(TextureHandler.m_cow1, new Vector2(Settings.m_screenWidth * 0.65f - 25, Settings.m_screenHeight * 0.35f), 180, new Vector2(0.75f,0.75f));
            }
            
            if (Settings.m_numberOfPlayers > 2) {
                m_playerThird = new Sprite(TextureHandler.m_cow1, new Vector2(Settings.m_screenWidth * 0.85f, Settings.m_screenHeight * 0.5f - 20), 180, new Vector2(0.75f,0.75f));
            }
              
 //           // Initialise Buttons
            m_Race_Again_Button = new Button(TextureHandler.m_menuRaceAgain,       new Vector2(Settings.m_screenWidth * 0.25f, Settings.m_screenHeight * 0.8f));
            m_Main_Menu_Button  = new Button(TextureHandler.m_menuMain,            new Vector2(Settings.m_screenWidth * 0.75f, Settings.m_screenHeight * 0.8f));


            m_touchState = TouchState.IDLE;

			// Set initial next state
			m_nextState = GameState.MAIN_MENU;
			// Change execution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

        public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_) {
			// Update victory state
			// ================


            // Set cow textures for victory podium
           m_playerFirst.SetTexture(m_players[m_rankings[0] - 1].GetCow().GetTexture());
            if (Settings.m_numberOfPlayers > 1) {
                        m_playerSecond.SetTexture(m_players[m_rankings[1] - 1].GetCow().GetTexture());
            }
            if (Settings.m_numberOfPlayers > 2) {
                         m_playerThird.SetTexture(m_players[m_rankings[2] - 1].GetCow().GetTexture());
            }
            
            ///////////////////////////////////// NOT WORKING
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
                if (m_Race_Again_Button.Activated(m_lastPosition)) {
                    m_nextState = GameState.IN_GAME;
                }
                // If Menu button is pressed, go back to the main menu
                if (m_Main_Menu_Button.Activated(m_lastPosition))
                {
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
            GraphicsHandler.DrawSprite(m_leaderboard);
            GraphicsHandler.DrawSprite(m_goldTrophy);
            GraphicsHandler.DrawSprite(m_playerFirst);
            GraphicsHandler.DrawText("1st", new Vector2(150, 200), Color.Black);
            if (m_rankings.Count != 0)
            {
                GraphicsHandler.DrawText("Player " + m_rankings[0].ToString(), new Vector2(475, 200), Color.Black);
                
            }
            int sec = m_players[m_rankings[0] - 1].GetRaceTime() / 1000;
            int mins = sec / 60;
            int msec = m_players[m_rankings[0] - 1].GetRaceTime();
            GraphicsHandler.DrawText(mins + ":" + sec, new Vector2(825, 200), Color.Black);
            if (Settings.m_numberOfPlayers > 1)
            {
                sec = m_players[m_rankings[1] - 1].GetRaceTime() / 1000;
                mins = sec / 60;
                GraphicsHandler.DrawSprite(m_silverTrophy);
                GraphicsHandler.DrawSprite(m_playerSecond);
                GraphicsHandler.DrawText("2nd", new Vector2(150, 275), Color.Black);
                GraphicsHandler.DrawText("Player " + m_rankings[1].ToString(), new Vector2(475, 275), Color.Black);
                GraphicsHandler.DrawText(mins + ":" + sec + ":" + msec, new Vector2(825, 275), Color.Black);
            }
            if (Settings.m_numberOfPlayers > 2)
            {
                sec = m_players[m_rankings[2] - 1].GetRaceTime() / 1000;
                mins = sec / 60;
                GraphicsHandler.DrawSprite(m_bronzeTrophy);
                GraphicsHandler.DrawSprite(m_playerThird);
                GraphicsHandler.DrawText("3rd", new Vector2(150, 375), Color.Black);
                GraphicsHandler.DrawText("Player " + m_rankings[2].ToString(), new Vector2(475, 375), Color.Black);
                GraphicsHandler.DrawText(mins + ":" + sec + ":" + msec, new Vector2(825, 375), Color.Black);
            }
            if (Settings.m_numberOfPlayers > 3)
            {
                sec = m_players[m_rankings[3] - 1].GetRaceTime() / 1000;
                mins = sec / 60;
                GraphicsHandler.DrawText("4th", new Vector2(150, 450), Color.Black);
                GraphicsHandler.DrawText("Player " + m_rankings[3].ToString(), new Vector2(475, 450), Color.Black);
                GraphicsHandler.DrawText(mins + ":" + sec + ":" + msec, new Vector2(825, 450), Color.Black);
            }
            GraphicsHandler.DrawSprite(m_Race_Again_Button.m_sprite);
            GraphicsHandler.DrawSprite(m_Main_Menu_Button.m_sprite);

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
            GraphicsHandler.DrawText("POSITION", new Vector2(125.0f, 75.0f), Color.Black);
            GraphicsHandler.DrawText("PLAYER", new Vector2(450.0f, 75.0f), Color.Black);
            GraphicsHandler.DrawText("TIME", new Vector2(800.0f, 75.0f), Color.Black);

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
