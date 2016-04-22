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
/// State.cs

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System.Input;
using Project_Cows.Source.Application;

namespace Project_Cows.Source.System.StateMachine {
	abstract class State {
		// Basic state class for extending game states
		// ================

		// Variables
		protected GameState m_currentState;
		protected GameState m_nextState;
		protected ExecutionState m_currentExecutionState;

        protected static List<Player> m_players;
        protected static List<int>    m_rankings;

		// Methods
		public State() { }

		public abstract void Initialise();

		public abstract void Update(ref TouchHandler touchHandler_, GameTime gameTime_);

		public abstract void Draw(GraphicsDevice graphicsDevice_);

		// NOTE: Possibly should be public, for access within Application class
		//       If public, should possibly return variables for use in other states -Dean
		protected abstract void CleanUp();

		// Getters
		public abstract GameState GetState();

		// NOTE: Possibly need not be overridden -Dean
		public abstract GameState GetNextState();

		// NOTE: Possibly need not be overridden -Dean
		public abstract ExecutionState GetExecutionState();

		// Setters
		public void SetExecutionState(ExecutionState executionState_) { m_currentExecutionState = executionState_; }

	}

	public enum GameState {
		// Enum for each type of game state
		// ================
		MAIN_MENU,
		IN_GAME,
		VICTORY_SCREEN
	}

	public enum ExecutionState {
		// Enum for the current state of each game state (initialising, running, changing, etc.)
		// ================
		INITIALISING,
		RUNNING,
		CHANGING
	}
}
