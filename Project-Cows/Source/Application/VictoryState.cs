// Project Cows -- GearShift Games
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

using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.Application {
	class VictoryState : State {
		// Class to handle the victory state of the game
		// ================

		// Variables


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

        public override void Update(ref TouchHandler touchHandler_, GameTime gameTime_)
        {
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
			
			// Update screen objects
			// TODO: Update any screen objects

			// Update sprites
			// TODO: animate sprites, etc.
		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			// ================

			// Clear the screen
			graphicsDevice_.Clear(Color.LawnGreen);

			// Render graphics
			// TODO: Render sprites in the game
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
