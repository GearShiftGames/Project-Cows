// Project: Cow Racing -- GearShift Games
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
using Project_Cows.Source.Application.Track;
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
        private TrackHandler h_trackHandler = new TrackHandler();
        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Particle> m_particles = new List<Particle>();
        //private List<Barrier> m_barriers = new List<Barrier>();
        private Timer startTimer = new Timer();

        private Texture2D carTexture, squareTexture, backgroundTexture, cowTexture;
        private Sprite m_background;

        private List<int> m_rankings = new List<int>();

        bool finished;

		// Methods
		public InGameState() : base() {
			// InGameState constructor
			// ================

			m_currentState = GameState.IN_GAME;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

		public override void Initialise() {
			// Initialise in-game state
			// ================

            carTexture = GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\Tractor_Blue");
            squareTexture = GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\square");
            backgroundTexture = GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Backgrounds\\V2_Background_Grass");
            cowTexture = GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\cow");
            //barrierTexture = GraphicsHandler.m_content.Load<Texture2D>("Tyre");

            Vector2 BackgroundScale = new Vector2((float)backgroundTexture.Width / (float)Settings.m_screenWidth);
            m_background = new Sprite(backgroundTexture, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0.0f, BackgroundScale);

            h_trackHandler.Initialise();

			// Initialise players
            m_players = new List<Player>();
            m_players.Clear();

            for (int i = 0; i < Settings.m_numberOfPlayers; ++i) {
                Quadrent quad = Quadrent.BOTTOM_LEFT;
                if(i == 0){
                    quad = Quadrent.BOTTOM_LEFT;
                }else if(i == 1){
                    quad = Quadrent.BOTTOM_RIGHT;
                }else if(i == 2){
                    quad = Quadrent.TOP_LEFT;
                }else if(i == 3){
                    quad = Quadrent.TOP_RIGHT;
                }

                m_players.Add(new Player(cowTexture, carTexture, h_trackHandler.m_vehicles[i], 0, quad, i+1));

                m_players[i].m_controlScheme.SetSteeringSprite(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\controlTemp"), new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));
                m_players[i].m_controlScheme.SetInterfaceSprite(new Sprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\controlTempBG"), new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));
            }

            // Initialise sprites
            m_animatedSprites.Add(new AnimatedSprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\animation"), 
                new Vector2(0.0f, 0.0f), 10, 10, 250, true, 0, 50));

            // Start timer
            startTimer.StartTimer(3000.0f);

            finished = false;

			// Set initial next state
			m_nextState = GameState.VICTORY_SCREEN;

			// Change execution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

        public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_) {
			// Update in game state
			// ================

			// Update touch input handler
			touchHandler_.Update();

            //Settings.SaveSettings();

            //Settings.LoadSettings();

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

            startTimer.Update(gameTime_.ElapsedGameTime.Milliseconds);
            if (startTimer.timerFinished) {
                foreach (Player p in m_players)
                {
                    if (p.m_currentLap == 4)
                    {
                        finished = true;
                    }
                }
                if (!finished)
                {
                    // Update each player
                    for (int index = 0; index < m_players.Count; ++index)
                    {
                        bool left = false;
                        bool right = false;
                        bool brake = false;
                        if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        {
                            left = true;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        {
                            right = true;
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Down))
                        {
                            brake = true;
                        }

                        m_players[index].KeyboardMove(left, right, brake);
                        m_players[index].Update(playerTouches[index]);
                    }
                }
            }
                

			// Update game objects
			
            // Perform collision Checks
            foreach (Player p1 in m_players) {
                // Player vs Player
                /*foreach (Player p2 in m_players) {
                    if (p2.GetID() != p1.GetID()) {
                        if (CollisionHandler.CheckForCollision(p1.GetVehicle().GetCollider(), p2.GetVehicle().GetCollider())) {
                            p1.GetVehicle().m_speed = -p1.GetVehicle().m_speed * 1.5f;

                            // NOTE: Change needs to be made here, as this means that the vehicle would Update() twice in the same frame -Dean
                            p1.GetVehicle().Update();

                            Debug.AddText(new DebugText("Defo COllided ye ken?", new Vector2(10.0f, 150.0f)));
                        }
                    }
                }*/

                // Player vs Barrier
                /*foreach (Barrier b in h_trackHandler.m_barriers) {
                    if (CollisionHandler.CheckForCollision(p1.GetVehicle().GetCollider(), b.GetCollider())) {
                        p1.GetVehicle().m_speed = -p1.GetVehicle().m_speed * 1.5f;

                        // NOTE: Change needs to be made here, as this means that the vehicle would Update() twice in the same frame -Dean
                        p1.GetVehicle().Update();

                        Debug.AddText(new DebugText("Defo COllided ye ken?", new Vector2(10.0f, 150.0f)));
                    }
                }*/
            }

            h_trackHandler.Update(m_players);


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

            foreach (CheckpointContainer cp in h_trackHandler.m_checkpoints) {
                cp.GetEntity().UpdateSprites();
            }
            
			// Update particles
            m_particles = GraphicsHandler.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);
		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			// ================
          
			// Clear the screen
			graphicsDevice_.Clear(Color.Beige);

            // Start rendering graphics
            GraphicsHandler.StartDrawing();

            // Render background
            GraphicsHandler.DrawSprite(m_background);

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

            h_trackHandler.Draw();

            // Render player vehicles
			foreach(Player p in m_players) {
                GraphicsHandler.DrawSprite(p.GetVehicle().GetSprite());
                GraphicsHandler.DrawSprite(p.GetCow());
                GraphicsHandler.DrawSprite(p.m_controlScheme.m_controlInterfaceSprite);
                GraphicsHandler.DrawSprite(p.m_controlScheme.m_steeringIndicatorSprite);
			}

            if (!startTimer.timerFinished) {
                GraphicsHandler.DrawText(((int)(startTimer.timeRemaining / 1000) + 1).ToString(), new Vector2(1000, 50), Color.Red);
            }
            if(finished){
                GraphicsHandler.DrawText("SOMEONE WON", new Vector2(500, 500), Color.Red);
            }
            

            // Stop rendering graphics
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
