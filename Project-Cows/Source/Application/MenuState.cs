// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// MenuState.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.Application {
	class MenuState : State {
		// Class to handle the menu state of the game
		// ================

		// Variables
		

		// Methods
		public MenuState() : base() {
			// MenuState constructor

		}

		public override void Initialise() {
			// Initialise menu state
			//throw new NotImplementedException();
		}

		public override void Update(ref TouchHandler touchHandler_) {
			// Update menu state
			//throw new NotImplementedException();
		}

		public override void Draw(GraphicsDevice graphicsDevice_) {
			// Render objects to the screen
			graphicsDevice_.Clear(Color.CornflowerBlue);
			// Clear the screen
			//GraphicsDevice.Clear(Color.CornflowerBlue);
		}

		protected override void CleanUp() {
			// Clean up any objects
			//throw new NotImplementedException();
		}

		private void HandleInput(ref TouchHandler touchHandler_) {
			// Handles any user input

		}

		// Getters
		public override GameState GetNextState() {
			//throw new NotImplementedException();
			return GameState.MAIN_MENU;
		}

		public override ExecutionState GetExecutionState() {
			//throw new NotImplementedException();
			return ExecutionState.RUNNING;
		}

		// Setters

	}
}
