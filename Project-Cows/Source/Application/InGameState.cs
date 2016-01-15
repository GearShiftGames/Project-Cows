// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// InGameState.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.Application {
	class InGameState : State {
		// Class to handle the in game state of the game
		// ================

		// Variables


		// Methods
		public InGameState() : base() {
			// InGameState constructor
			// ================

			m_currentState = GameState.IN_GAME;

			m_currentExecutionState = ExecutionState.INITIALISING;
		}

		public override void Initialise() {
			// Initialise in game state
			// ================

			// Set initial next state
			m_nextState = GameState.VICTORY_SCREEN;

			// Change execution state
			m_currentExecutionState = ExecutionState.RUNNING;
		}

		public override void Update(ref TouchHandler touchHandler_) {
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
		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			// ================

			// Clear the screen
			graphicsDevice_.Clear(Color.Beige);

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
