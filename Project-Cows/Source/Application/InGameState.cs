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

using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Particles;
using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.Application {
	class InGameState : State {
		// Class to handle the in game state of the game
		// ================

		// Variables
        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Sprite> m_sprites = new List<Sprite>();
        private List<Particle> m_particles = new List<Particle>();

        Texture2D carTexture, squareTexture; 

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

			// Initialise players
            m_players = new List<Player>();
            m_players.Clear();
            m_players.Add(new Player(carTexture, new Vector2(20, 20), 0, 0, Quadrent.TOP_LEFT, 1));
			m_players[0].m_controlScheme.SetSteeringSprite(new Sprite(content_.Load<Texture2D>("controlTemp"), new Vector2(100.0f, 100.0f), 0, 1, true));
			m_players[0].m_controlScheme.SetInterfaceSprite(new Sprite(content_.Load<Texture2D>("controlTempBG"), new Vector2(100.0f, 100.0f), 0, 1, true));

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

			foreach(TouchLocation tl in touchHandler_.GetTouches()) {

				// TODO:
				// Check touch input for each touch zone of the screen
				// Check if touch zone has had three simultaneous touches
					// Penalise player
				// Change values based on touch locations
                
			}

            //m_players[0].m_controlScheme.Update(touchHandler_.GetTouches());                // Temp

			m_players[0].Update(touchHandler_.GetTouches());

			// Update game objects
			// TODO: perform collision checks, etc.

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

            // Update particles
            m_particles = graphicsHandler_.UpdatePFX(gameTime_.ElapsedGameTime.TotalMilliseconds);

            //TEMP: Controlling the player
            #region Player Controller
            KeyboardState CurrentKeyboard = Keyboard.GetState();

            //car wants to break
            /*if (CurrentKeyboard.IsKeyDown(Keys.Down))
            {
                if (!CurrentKeyboard.IsKeyDown(Keys.Space))
                {
                    m_players[0].breaking = true;
                }
                else m_players[0].breaking = false;
            }

            //turn right
            if (CurrentKeyboard.IsKeyDown(Keys.Right))
            {
                m_players[0].turnRight = true;

                if (CurrentKeyboard.IsKeyDown(Keys.Space))
                {
                    m_players[0].breaking = true;
                }
            }
            //no point checking if turning left if turning right is true
            else if (CurrentKeyboard.IsKeyDown(Keys.Left))
            {
                m_players[0].turnLeft = true;

                if (CurrentKeyboard.IsKeyDown(Keys.Space))
                {
                    m_players[0].breaking = true;
                }
            }

            if (CurrentKeyboard.IsKeyDown(Keys.Space))
            {
                m_players[0].breaking = true;
            }*/

            m_players[0].Update(touchHandler_.GetTouches());
            #endregion

		}

		public override void Draw(GraphicsDevice graphicsDevice_, ref GraphicsHandler graphicsHandler_) {
			// Render objects to the screen
			// ================

			// Clear the screen
			graphicsDevice_.Clear(Color.Beige);

			// Render graphics
            graphicsHandler_.StartDrawing();

            foreach (AnimatedSprite anim_ in m_animatedSprites) {
                if (anim_.IsVisible()) {
                    //graphicsHandler_.DrawAnimatedSprite(anim_);
                }
            }
            foreach (Sprite sprite_ in m_sprites) {
                if (sprite_.IsVisible()) {
                    //graphicsHandler_.DrawSprite(sprite_);
                }
            }
            foreach (Particle part_ in m_particles) {
                if (part_.GetLife() > 0) {
                    //graphicsHandler_.DrawParticle(/*texture,*/ part_.GetPosition(), Color.White);
                }
            }

            graphicsHandler_.DrawSprite(m_players[0].m_controlScheme.m_controlInterfaceSprite);             // Temp
            graphicsHandler_.DrawSprite(m_players[0].m_controlScheme.m_steeringIndicatorSprite);            // Temp

            //m_players[0].m_carBounds.m_Rotation = m_players[0].m_carBounds.m_Rotation - (m_players[0].slide * m_players[0].sliding) * 2;

            //cars collision rect
            //Rectangle AdjustsedPos = new Rectangle(m_players[0].m_carBounds.X + (m_players[0].m_carBounds.Width / 2), m_players[0].m_carBounds.Y + (m_players[0].m_carBounds.Height / 2), m_players[0].m_carBounds.Width, m_players[0].m_carBounds.Height);
            //graphicsHandler_.m_spriteBatch.Draw(squareTexture, AdjustsedPos, m_players[0].m_carBounds.collisionRectangle, Color.Red, m_players[0].m_carBounds.m_Rotation, m_players[0].center, SpriteEffects.None, 0);

            //the moving car sprite
            //AdjustsedPos = new Rectangle(m_players[0].m_carBounds.X + (m_players[0].m_carBounds.Width / 2), m_players[0].m_carBounds.Y + (m_players[0].m_carBounds.Height / 2), m_players[0].m_carBounds.Width, m_players[0].m_carBounds.Height);
            //graphicsHandler_.m_spriteBatch.Draw(m_players[0].m_car.GetTexture(), m_players[0].position, null, Color.Red, m_players[0].m_carBounds.m_Rotation, m_players[0].center, 1.0f, SpriteEffects.None, 0);
			graphicsHandler_.DrawSprite(m_players[0].GetVehicle().GetSprite());
            //graphicsHandler_.DrawSprite(m_players[0].m_car);
           
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
