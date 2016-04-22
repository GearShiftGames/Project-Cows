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
/// InGameState.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using FarseerPhysics.Dynamics;

using Project_Cows.Source.Application.Entity.Vehicle;
using Project_Cows.Source.Application.Entity;
using Project_Cows.Source.Application.Track;
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

        // <Farseer>
        World fs_world;
        // </Farseer>

        private TrackHandler h_trackHandler = new TrackHandler();
        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Particle> m_particles = new List<Particle>();
        private Timer startTimer = new Timer();

        private Sprite m_background;
        private List<Sprite> m_rankingSprites = new List<Sprite>();

        //for use of showing which player is in which position
        private List<int> m_rankings = new List<int>();

        int m_winner = 0;

        bool finished;

        //will be used to determine if all players have readied up
        bool PlayersReady;
        int NoPlayersReady;

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

            fs_world = new FarseerPhysics.Dynamics.World(Vector2.Zero);

            m_background = new Sprite(TextureHandler.m_gameBackground, new Vector2(Settings.m_screenWidth / 2, Settings.m_screenHeight / 2), 0.0f, Vector2.One);

            h_trackHandler.Initialise(fs_world);

            //Ready Up Stuff
            PlayersReady = true;
            NoPlayersReady = 0;

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

                // Link whichever cow & vehicle texture to what was selected in menu
                if (i == 0) {
                    m_players.Add(new Player(fs_world, TextureHandler.m_player_1_cow, TextureHandler.m_player_1_vehicle, TextureHandler.m_THELORDANDSAVIOUR, new Vector2(100, Settings.m_screenHeight - 100), h_trackHandler.m_vehicles[i], 0, quad, i + 1));
                    m_players[i].m_controlScheme.SetSteeringSprite(new Sprite(TextureHandler.m_userInterfaceWheelBlue, new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));
                    m_players[i].m_controlScheme.SetInterfaceSprite(new Sprite(TextureHandler.m_userInterfaceSlider, new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));

                    m_rankingSprites.Add(new Sprite(TextureHandler.m_player_1_vehicle, new Vector2(Settings.m_screenWidth / 2 - 400, Settings.m_screenHeight / 2 - 30), 0, new Vector2(1.0f, 1.0f), true));

                } else if (i == 1) {
                    m_players.Add(new Player(fs_world, TextureHandler.m_player_2_cow, TextureHandler.m_player_2_vehicle, TextureHandler.m_THELORDANDSAVIOUR, new Vector2(Settings.m_screenWidth - 100, Settings.m_screenHeight - 100), h_trackHandler.m_vehicles[i], 0, quad, i + 1));
                    m_players[i].m_controlScheme.SetSteeringSprite(new Sprite(TextureHandler.m_userInterfaceWheelOrange, new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));
                    m_players[i].m_controlScheme.SetInterfaceSprite(new Sprite(TextureHandler.m_userInterfaceSlider, new Vector2(100.0f, 100.0f), 0, new Vector2(1.0f, 1.0f), true));

                    m_rankingSprites.Add(new Sprite(TextureHandler.m_player_2_vehicle, new Vector2(Settings.m_screenWidth / 2 - 300, Settings.m_screenHeight / 2 - 30), 0, new Vector2(1.0f, 1.0f), true));

                } else if (i == 2) {
                    m_players.Add(new Player(fs_world, TextureHandler.m_player_3_cow, TextureHandler.m_player_3_vehicle, TextureHandler.m_THELORDANDSAVIOUR, new Vector2(100, 100), h_trackHandler.m_vehicles[i], 0, quad, i + 1));
                    m_players[i].m_controlScheme.SetSteeringSprite(new Sprite(TextureHandler.m_userInterfaceWheelPurple, new Vector2(100.0f, 100.0f), 180, new Vector2(1.0f, 1.0f), true));
                    m_players[i].m_controlScheme.SetInterfaceSprite(new Sprite(TextureHandler.m_userInterfaceSlider, new Vector2(100.0f, 100.0f), 180, new Vector2(1.0f, 1.0f), true));

                    m_rankingSprites.Add(new Sprite(TextureHandler.m_player_3_vehicle, new Vector2(Settings.m_screenWidth / 2 - 200, Settings.m_screenHeight / 2 - 30), 0, new Vector2(1.0f, 1.0f), true));

                } else if (i == 3) {
                    m_players.Add(new Player(fs_world, TextureHandler.m_player_4_cow, TextureHandler.m_player_4_vehicle, TextureHandler.m_THELORDANDSAVIOUR, new Vector2(Settings.m_screenWidth - 100, 100), h_trackHandler.m_vehicles[i], 0, quad, i + 1));
                    m_players[i].m_controlScheme.SetSteeringSprite(new Sprite(TextureHandler.m_userInterfaceWheelYellow, new Vector2(100.0f, 100.0f), 180, new Vector2(1.0f, 1.0f), true));
                    m_players[i].m_controlScheme.SetInterfaceSprite(new Sprite(TextureHandler.m_userInterfaceSlider, new Vector2(100.0f, 100.0f), 180, new Vector2(1.0f, 1.0f), true));

                    m_rankingSprites.Add(new Sprite(TextureHandler.m_player_4_vehicle, new Vector2(Settings.m_screenWidth / 2 - 100, Settings.m_screenHeight / 2 - 30), 0, new Vector2(1.0f, 1.0f), true));
                }
            }

            // Initialise sprites
            m_animatedSprites.Add(new AnimatedSprite(GraphicsHandler.m_content.Load<Texture2D>("Sprites\\Temp\\animation"), 
                new Vector2(0.0f, 0.0f), 10, 10, 250, true, 0, 50));

            // Start timer
            startTimer.StartTimer(3000.0f);

            finished = true;// false;

			// Set initial next state
			m_nextState = GameState.VICTORY_SCREEN;

			// Change execution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

        public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_)
        {
            // Update in game state
            // ================

            // Update touch input handler
            touchHandler_.Update();

            // Create lists to contain touches for each player
            List<List<TouchLocation>> playerTouches = new List<List<TouchLocation>>();
            for (int p = 0; p < m_players.Count; ++p)
            {
                playerTouches.Add(new List<TouchLocation>());
            }

            // Iterate through each player and sort out which touches are for which player
            foreach (TouchLocation tl in touchHandler_.GetTouches())
            {
                for (int index = 0; index < playerTouches.Count; ++index)
                {
                    if (m_players[index].m_controlScheme.GetTouchZone().IsInsideZone(tl.Position))
                    {
                        playerTouches[index].Add(tl);
                    }
                }

                // TODO:
                // Check if touch zone has had three simultaneous touches
                // Penalise player
                // NOTE: This should probably be done in the respective players' ControlScheme object -Dean
            }

            //only want to do this when the main game isnt running
            if (!PlayersReady)
            {
                //check if a players ready up button has been pressed
                foreach (TouchLocation tl in touchHandler_.GetTouches())
                {
                    for (int index = 0; index < m_players.Count; ++index)
                    {
                        if (m_players[index].m_ReadyButton.Activated(tl.Position))
                        {
                            m_players[index].m_ReadyUp = true;
                            m_players[index].m_ReadyButton.m_sprite.SetTexture(TextureHandler.m_gameLogo);//changes texture so we know who has readied up
                        }
                    }
                }

                //Set to 0 every run, so that it doesnt count multiple touches from same person
                NoPlayersReady = 0;

                foreach (Player p in m_players)
                {
                    if (p.m_ReadyUp == true)
                    {
                        NoPlayersReady += 1;
                    }
                }

                //When all players have readied up, start main game
                if (NoPlayersReady == m_players.Count)
                {
                    PlayersReady = true;
                }
                h_trackHandler.Update(m_players, ref m_rankings);
            }
            else if (PlayersReady)
            {
                startTimer.Update(gameTime_.ElapsedGameTime.Milliseconds);
                if (startTimer.timerFinished)
                {
                    for (int i = 0; i < m_players.Count; ++i)
                    {
                        if (m_players[i].m_currentLap == Settings.m_number_laps)
                        {
                            m_players[i].SetFinished(true);
                            m_players[i].AddFinishTime(gameTime_.ElapsedGameTime.Milliseconds);
                            if (m_winner == 0) {
                                m_winner = m_players[i].GetID();
                            }
                        }
                        if (!m_players[i].GetFinished() || (m_players[i].GetFinished() && m_players[i].GetFinishTime() < 500))
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

                            m_players[i].KeyboardMove(left, right, brake);
                            m_players[i].Update(playerTouches[i], m_rankings[i]);
                            m_players[i].AddRaceTime(gameTime_.ElapsedGameTime.Milliseconds);
                        }
                    }
                }
                // Victory state

                finished = true;
                foreach (Player p in m_players)
                {
                    if (!p.GetFinished())
                    {
                        finished = false;
                        break;
                    }
                }
                if (finished)
                {
                    m_currentExecutionState = ExecutionState.CHANGING;
                }

                // Update game objects

                float turn = 0;
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    turn--;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    turn++;
                }
                bool braked = Keyboard.GetState().IsKeyDown(Keys.Down);


                h_trackHandler.Update(m_players, ref m_rankings);

                // Update sprites
                foreach (AnimatedSprite anim in m_animatedSprites)
                {
                    // If currently animating
                    if (anim.GetCurrentState() == 1)
                    {
                        // Change the frame
                        if (gameTime_.TotalGameTime.TotalMilliseconds - anim.GetLastTime() > anim.GetFrameTime())
                        {
                            anim.ChangeFrame(gameTime_.TotalGameTime.TotalMilliseconds);
                        }
                    }
                }

                foreach (Player p in m_players)
                {
                    // FIXME: Should this be commented out? 
                    //p.UpdateSprites();
                }

                foreach (CheckpointContainer cp in h_trackHandler.m_checkpoints)
                {
                    cp.GetEntity().UpdateSprites();
                }

                //this set the sprite for the rankings, to the players to the corresponding rank
                for (int i = 0; i < m_rankings.Count; i++)
                {
                    m_rankingSprites[i].SetTexture(m_players[m_rankings[i] - 1].GetVehicle().m_vehicleBody.GetSprite().GetTexture());
                }
              
                // Update particles
                m_particles = GraphicsHandler.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);

                fs_world.Step((float)gameTime_.ElapsedGameTime.TotalMilliseconds * .001f);
            }
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
                    GraphicsHandler.DrawParticle(part_.GetPosition(), part_.GetColour(), part_.GetLife());
                }
            }

            h_trackHandler.Draw();

            // Render player vehicles
			foreach(Player p in m_players) {
                GraphicsHandler.DrawSprite(p.GetVehicle().m_vehicleBody.GetSprite());
                //GraphicsHandler.DrawSprite(p.GetCow());
                GraphicsHandler.DrawSprite(p.m_controlScheme.m_controlInterfaceSprite);
                GraphicsHandler.DrawSprite(p.m_controlScheme.m_steeringIndicatorSprite);

                if(!PlayersReady)
                {
                    GraphicsHandler.DrawSprite(p.m_ReadyButton.m_sprite);
                }
			}

            for (int i = 0; i < Settings.m_numberOfPlayers; i ++)
            {
                GraphicsHandler.DrawSprite(m_rankingSprites[i]);
            }

                // RENDER UI

                // Render ranking text
                if (m_rankings.Count != 0)
                {
                    GraphicsHandler.DrawText(new DebugText("1st - Player " + m_rankings[0].ToString(), new Vector2(Settings.m_screenWidth / 2 - 450, Settings.m_screenHeight / 2 - 80)));
                   
                    if (m_rankings.Count > 1)
                    {
                        GraphicsHandler.DrawText(new DebugText("2nd - Player " + m_rankings[1].ToString(), new Vector2(Settings.m_screenWidth / 2 - 350, Settings.m_screenHeight / 2 - 80)));
                        if (m_rankings.Count > 2)
                        {
                            GraphicsHandler.DrawText(new DebugText("3rd - Player " + m_rankings[2].ToString(), new Vector2(Settings.m_screenWidth / 2 - 250, Settings.m_screenHeight / 2 - 80)));
                            if (m_rankings.Count > 3)
                            {
                                GraphicsHandler.DrawText(new DebugText("4th - Player " + m_rankings[3].ToString(), new Vector2(Settings.m_screenWidth / 2 - 150, Settings.m_screenHeight / 2 - 80)));
                            }
                        }
                    }
                }

                


            /*if (m_rankings.Count != 0) {
                GraphicsHandler.DrawText(new DebugText("1st - Player " + m_players[0].GetRaceTime(), new Vector2(1000f, 440f)));
                if (m_rankings.Count > 1) {
                    GraphicsHandler.DrawText(new DebugText("2nd - Player " + m_players[1].GetRaceTime(), new Vector2(1000f, 460f)));
                    if (m_rankings.Count > 2) {
                        GraphicsHandler.DrawText(new DebugText("3rd - Player " + m_players[2].GetRaceTime(), new Vector2(1000f, 480f)));
                        if (m_rankings.Count > 3) {
                            GraphicsHandler.DrawText(new DebugText("4th - Player " + m_players[3].GetRaceTime(), new Vector2(1000f, 500f)));
                        }
                    }
                }
            }*/






            /*Debug.AddSprite(m_players[0].GetVehicle().m_vehicleTyres[0].GetSprite());
            Debug.AddSprite(m_players[0].GetVehicle().m_vehicleTyres[1].GetSprite());
            Debug.AddSprite(m_players[0].GetVehicle().m_vehicleTyres[2].GetSprite());
            Debug.AddSprite(m_players[0].GetVehicle().m_vehicleTyres[3].GetSprite());*/


            //GraphicsHandler.DrawSprite(bsv.m_vehicleBody.GetSprite());*/



            if (!startTimer.timerFinished) {
                GraphicsHandler.DrawText(((int)(startTimer.timeRemaining / 1000) + 1).ToString(), new Vector2(1000, 50), Color.Red);
            }
            if(finished){
                GraphicsHandler.DrawText("Player " + m_winner.ToString() + " is the winner", new Vector2(500, 500), Color.Red);
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
