﻿// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// VictoryState.cs

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
	class VictoryState : State {
		// Class to handle the victory state of the game
		// ================

		// Variables
        private List<AnimatedSprite> m_animatedSprites = new List<AnimatedSprite>();
        private List<Sprite> m_sprites = new List<Sprite>();
        private List<Particle> m_particles = new List<Particle>();

		// Methods
		public VictoryState() : base() {
			// VictoryState constructor
			// ================

			m_currentState = GameState.VICTORY_SCREEN;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

		public override void Initialise(ContentManager content_) {
			// Initialise victory state
			// ================

			// Set initial next state
			m_nextState = GameState.MAIN_MENU;

			// Change execution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

        public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_, ref GraphicsHandler graphicsHandler_) {
			// Update victory state
			// ================

			// Update touch input handler
			touchHandler_.Update();

			foreach(TouchLocation tl in touchHandler_.GetTouches()) {

				// NOTE: TEMP CODE -Dean
				m_currentExecutionState = ExecutionState.CHANGING;
				break;
				// /NOTE

				// TODO: Run code based on what button/area is touched
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
			graphicsDevice_.Clear(Color.LawnGreen);

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
            graphicsHandler_.DrawText("VICTORY STATE", new Vector2(100.0f, 100.0f), Color.Red);

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