// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// State.cs

using System;
using System.Collections.Generic;

namespace Project_Cows.Source.System.StateMachine {
	abstract class State {
		// Basic state class for extending game states
		// ================

		// Variables
		private bool m_stateToChange;
		private bool m_initialised;


		// Methods
		public State() { }

		public abstract void Initialise();

		public abstract void Update();

		public abstract void Draw();

		public abstract bool IsStateToChange();

		protected abstract void CleanUp();


		// Getters
		public abstract GameState GetNextState();

		

		// Setters
	}

	enum GameState {
		MAIN_MENU,
		IN_GAME,
		VICTORY_SCREEN
	}
}
