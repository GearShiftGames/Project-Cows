// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
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
using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.Application {
	class InGameState : State {
		// Class to handle the in game state of the game
		// ================

		// Variables
        GraphicsHandler m_graphicsHandler;
        AnimatedSprite m_sprite;

		// Methods
		public InGameState(GraphicsHandler graphicsHandler_) : base() {
			// InGameState constructor
			// ================

            m_graphicsHandler = graphicsHandler_;

			m_currentState = GameState.IN_GAME;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

		public override void Initialise(ContentManager content_) {
			// Initialise in game state
			// ================

            // Initialise sprites
            m_sprite = new AnimatedSprite(content_.Load<Texture2D>("animZombie"), new Vector2(50.0f, 50.0f), 51, 108, 250);

            // FIXME: Move me to appropriate gamestate
            /*PFX.update(gameTime.ElapsedGameTime.TotalMilliseconds);
            particles = PFX.GetParticles();*/
            // ENDFIXME:
            /*if (m_sprite.GetCurrentState() == 1)
            {
                if (gameTime.TotalGameTime.TotalMilliseconds - m_sprite.GetLastTime() > m_sprite.GetFrameTime())
                {
                    m_sprite.ChangeFrame(gameTime.TotalGameTime.TotalMilliseconds);
                }
            }*/

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

			foreach(TouchLocation tl in touchHandler_.GetTouches()) {
				
				// NOTE: TEMP CODE
				m_currentExecutionState = ExecutionState.CHANGING;
				break;
				// /NOTE

				// TODO:
				// Check touch input for each touch zone of the screen
				// Check if touch zone has had three simultaneous touches
					// Penalise player
				// Change values based on touch locations
			}

			// Update game objects
			// TODO: perform collision checks, etc.

			// Update sprites
			// TODO: animate sprites, etc.
            if (m_sprite.GetCurrentState() == 1)
            {
                if (gameTime_.TotalGameTime.TotalMilliseconds - m_sprite.GetLastTime() > m_sprite.GetFrameTime())
                {
                    m_sprite.ChangeFrame(gameTime_.TotalGameTime.TotalMilliseconds);
                }
            }
		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			// ================

            /*Random rnd = new Random();
            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i].getLife() > 0)
                {
                    spriteBatch.Draw(particleTexts[rnd.Next(0, 6)], new Vector2(particles[i].getPosition().X,
                                                            particles[i].getPosition().Y), Color.White);
                }
            }*/
       

			// Clear the screen
			graphicsDevice_.Clear(Color.Beige);

			// Render graphics
			// TODO: Render sprites in the game
            m_graphicsHandler.StartDrawing();

            m_graphicsHandler.DrawAnimatedSprite(m_sprite);
            m_graphicsHandler.DrawText("Hi i'm some text.", new Vector2(100.0f, 100.0f), Color.Red);

            m_graphicsHandler.StopDrawing();
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
