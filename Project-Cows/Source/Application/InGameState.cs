// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
//            N. Headley, 2016
// ================
// InGameState.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Project_Cows.Source.Application.Entity;
using Project_Cows.Source.Application.Physics;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Particles;
using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;
using Project_Cows.Source.System;

namespace Project_Cows.Source.Application {
	class InGameState : State {
		// Class to handle the in game state of the game
		// ================

		// Variables
        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Particle> m_particles = new List<Particle>();

        private List<Checkpoint> m_checkpoints = new List<Checkpoint>();
        private Texture2D carTexture, squareTexture, checkpointTexture, backgroundTexture;
        private Sprite m_background;

        private List<int> m_rankings = new List<int>();

		// Methods
		public InGameState() : base() {
			// InGameState constructor
			// ================

			m_currentState = GameState.IN_GAME;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

		public override void Initialise(ContentManager content_) {
			// Initialise in-game state
			// ================
			
			carTexture = content_.Load<Texture2D>("car");
            squareTexture = content_.Load<Texture2D>("square");
            backgroundTexture = content_.Load<Texture2D>("V2_Background_Grass");
            checkpointTexture = content_.Load<Texture2D>("checkpoint");

            Vector2 BackgroundScale = new Vector2((float)backgroundTexture.Width / (float)Settings.m_screenWidth);
            m_background = new Sprite(backgroundTexture, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0.0f, BackgroundScale);

			// Initialise players
            m_players = new List<Player>();
            m_players.Clear();
			m_players.Add(new Player(content_, carTexture, new Vector2(100, 300), 0, 0, Quadrent.BOTTOM_RIGHT, 1));
			//m_players.Add(new Player(content_, carTexture, new Vector2(100, 600), 270, 0, Quadrent.BOTTOM_LEFT, 2));

			m_players[0].m_controlScheme.SetSteeringSprite(new Sprite(content_.Load<Texture2D>("controlTemp"), new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));
			m_players[0].m_controlScheme.SetInterfaceSprite(new Sprite(content_.Load<Texture2D>("controlTempBG"), new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));
			//m_players[1].m_controlScheme.SetSteeringSprite(new Sprite(content_.Load<Texture2D>("controlTemp"), new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));
			//m_players[1].m_controlScheme.SetInterfaceSprite(new Sprite(content_.Load<Texture2D>("controlTempBG"), new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));

            #region Checkpoint Setup
            // Checkpoints...
            m_checkpoints.Add(new Checkpoint(0, content_, checkpointTexture, new Vector2(500f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(1, content_, checkpointTexture, new Vector2(600f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(2, content_, checkpointTexture, new Vector2(700f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(3, content_, checkpointTexture, new Vector2(800f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(4, content_, checkpointTexture, new Vector2(900f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(5, content_, checkpointTexture, new Vector2(1000f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(6, content_, checkpointTexture, new Vector2(1100f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(7, content_, checkpointTexture, new Vector2(1200f, 300f), 0.0f));
            m_checkpoints.Add(new Checkpoint(8, content_, checkpointTexture, new Vector2(1300f, 500f), 0.0f));
            m_checkpoints.Add(new Checkpoint(9, content_, checkpointTexture, new Vector2(1200f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(10, content_, checkpointTexture, new Vector2(1100f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(11, content_, checkpointTexture, new Vector2(1000f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(12, content_, checkpointTexture, new Vector2(900f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(13, content_, checkpointTexture, new Vector2(800f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(14, content_, checkpointTexture, new Vector2(700f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(15, content_, checkpointTexture, new Vector2(600f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(16, content_, checkpointTexture, new Vector2(500f, 700f), 0.0f));
            m_checkpoints.Add(new Checkpoint(17, content_, checkpointTexture, new Vector2(400f, 500f), 0.0f));
            #endregion

            // Initialise sprites
            m_animatedSprites.Add(new AnimatedSprite(content_.Load<Texture2D>("animation"), 
                new Vector2(0.0f, 0.0f), 10, 10, 250, true, 0, 50));

			// Set initial next state
			m_nextState = GameState.VICTORY_SCREEN;

			// Change execution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

        public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_, ref GraphicsHandler graphicsHandler_) {
			// Update in game state
			// ================

			// Update touch input handler
			touchHandler_.Update();

			// Create lists to contain touches for each player
			List<List<TouchLocation>> playerTouches = new List<List<TouchLocation>>();
			for(int p = 0; p < m_players.Count; ++p) {
				playerTouches.Add(new List<TouchLocation>());
			}
			
			// Iterate through each player and sort out which touches are for which player
			foreach(TouchLocation tl in touchHandler_.GetTouches()) {
				for(int index = 0; index < playerTouches.Count; ++index) {
					if(m_players[index].m_controlScheme.GetTouchZone().IsInsideZone(tl.Position)) {
						playerTouches[index].Add(tl);
					}
				}

				// TODO:
				// Check if touch zone has had three simultaneous touches
				// Penalise player
				// NOTE: This should probably be done in the respective players' ControlScheme object -Dean
			}

			// Update each player
			for(int index = 0; index < m_players.Count; ++index) {
                bool left = false;
                bool right = false;
                bool brake = false;
                if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
                    left = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
                    right = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Down)) {
                    brake = true;
                }

                m_players[index].KeyboardMove(left, right, brake); 
				m_players[index].Update(playerTouches[index]);
			}

			// Update game objects
			// TODO: perform collision checks, etc.
            foreach(Player p in m_players){
                foreach(Checkpoint cp in m_checkpoints){
                    if (CollisionHandler.CheckForCollision(p.GetVehicle().GetCollider(), cp.GetCollider())) {
                        if (cp.GetID() - p.m_currentCheckpoint == 1){
                            p.m_currentCheckpoint = cp.GetID();
                        } else if (cp.GetID() == 0 && p.m_currentCheckpoint == m_checkpoints.Count - 1) {
                            p.m_currentCheckpoint = cp.GetID();
                            ++p.m_currentLap;
                        }
                    }
                }

                Debug.AddText(new DebugText("Player " + p.GetID(), new Vector2(20.0f + 150 * p.GetID(), 70.0f)));
                Debug.AddText(new DebugText("Lap: " + p.m_currentLap.ToString(), new Vector2(20.0f + 150 * p.GetID(), 90.0f)));
                Debug.AddText(new DebugText("Checkpoint: " + p.m_currentCheckpoint.ToString(), new Vector2(20.0f + 150 * p.GetID(), 110.0f)));
            }

            // Get rankings
            m_rankings.Clear();
            while (m_rankings.Count != m_players.Count) {
                int highestID = 0;
                int highestScore = 0;

                // Check for highest score (i.e. front-most non-ranked player)
                foreach(Player p in m_players) {
                    int checkpointScore = p.m_currentLap * (m_checkpoints.Count - 1) + p.m_currentCheckpoint;
                    if (checkpointScore > highestScore) {
                        bool ranked = false;
                        foreach (int i in m_rankings) {
                            if (p.GetID() == i) {
                                ranked = true;
                            }
                        }

                        if (!ranked) {
                            highestScore = checkpointScore;
                            highestID = p.GetID();
                        }
                    }
                }

                // Add front-most player to rankings
                m_rankings.Add(highestID);
            }

            Debug.AddText(new DebugText("1st - Player " + m_rankings[0].ToString(), new Vector2(1500f, 50f)));
            //Debug.AddText(new DebugText("2nd - Player " + m_rankings[1].ToString(), new Vector2(1500f, 70f)));
            //Debug.AddText(new DebugText("1st - " + m_rankings[2].ToString(), new Vector2(1500f, 90f)));
            //Debug.AddText(new DebugText("1st - " + m_rankings[3].ToString(), new Vector2(1500f, 110f)));
            

			// Update sprites
            foreach(AnimatedSprite anim in m_animatedSprites) {
                // If currently animating
                if (anim.GetCurrentState() == 1) {
                    // Change the frame
                    if (gameTime_.TotalGameTime.TotalMilliseconds - anim.GetLastTime() > anim.GetFrameTime()) {
                        anim.ChangeFrame(gameTime_.TotalGameTime.TotalMilliseconds);
                    }
                }
            }
			
			foreach(Player p in m_players) {
				p.UpdateSprites();
			}

            foreach (Checkpoint cp in m_checkpoints) {
                cp.UpdateSprites();
            }
            
			// Update particles
            m_particles = graphicsHandler_.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);

		}

		public override void Draw(GraphicsDevice graphicsDevice_, ref GraphicsHandler graphicsHandler_) {
			// Render objects to the screen
			// ================
          
			// Clear the screen
			graphicsDevice_.Clear(Color.Beige);

            // Start rendering graphics
            graphicsHandler_.StartDrawing();

            // Render background
            graphicsHandler_.DrawSprite(m_background);

            // Render animated sprites      TEMP
            foreach (AnimatedSprite anim_ in m_animatedSprites) {
                if (anim_.IsVisible()) {
                    //graphicsHandler_.DrawAnimatedSprite(anim_);
                }
            }

            // Render particles             TEMP
            foreach (Particle part_ in m_particles) {
                if (part_.GetLife() > 0) {
                    //graphicsHandler_.DrawParticle(/*texture,*/ part_.GetPosition(), Color.White);
                }
            }


            // Render checkpoints
            // NOTE: Eventually make these only appear in debug mode
            foreach (Checkpoint cp in m_checkpoints) {
                graphicsHandler_.DrawSprite(cp.GetSprite());
            }

            // Render player vehicles
			foreach(Player p in m_players) {
				graphicsHandler_.DrawSprite(p.GetVehicle().GetSprite());
				graphicsHandler_.DrawSprite(p.m_controlScheme.m_controlInterfaceSprite);
				graphicsHandler_.DrawSprite(p.m_controlScheme.m_steeringIndicatorSprite);
			}

            // Stop rendering graphics
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
}
