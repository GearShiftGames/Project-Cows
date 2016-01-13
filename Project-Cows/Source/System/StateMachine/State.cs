// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// State.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System.Input;


namespace Project_Cows.Source.System.StateMachine {
	abstract class State {
		// Basic state class for extending game states
		// ================

		// Variables
		protected GameState m_nextState;
		protected ExecutionState m_currentExecutionState;

		// Methods
		public State() { }

		public abstract void Initialise();

		public abstract void Update(ref TouchHandler touchHandler_);

		public abstract void Draw(GraphicsDevice graphicsDevice_);

		// NOTE: Possibly should be public, for access within Application class
		// NOTE: If public, should possibly return variables for use in other states
		protected abstract void CleanUp();


		// Getters
		public abstract GameState GetNextState();

		public abstract ExecutionState GetExecutionState();

		// Setters

	}

	enum GameState {
		// Enum for each type of game state
		// ================
		MAIN_MENU,
		IN_GAME,
		VICTORY_SCREEN
	}

	enum ExecutionState {
		// Enum for the current state of each game state (initialising, running, changing, etc.)
		// ================
		INITIALISING,
		RUNNING,
		CHANGING
	}
}
