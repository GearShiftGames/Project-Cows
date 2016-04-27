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
/// Application.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.Application {
	public class Application : Game {
		// Application class for the game, contains the game loop and game structure.
		// ================

		// Variables
		private GraphicsDeviceManager h_graphicsDeviceHandler;		// Graphics device handler
		private TouchHandler h_touchHandler;						// Touch input handler
        //private GraphicsHandler h_graphicsHandler;                  // Deals with rendering of graphics

		private State m_currentState;								// Current state being executed
		private MenuState m_menuState;								// Game state: Menu screen
		private InGameState m_inGameState;							// Game state: In game state
		private VictoryState m_victoryState;						// Game state: Victory state

		// Methods
		public Application() {
			// Application constructor
			// ================
			h_graphicsDeviceHandler = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			h_touchHandler = new TouchHandler();
		}

		protected override void Initialize() {
			// Initialise the application
			// ================

            // Load settings
            Settings.LoadSettings();

			// Set up window
			h_graphicsDeviceHandler.IsFullScreen = Settings.m_fullscreen;
			h_graphicsDeviceHandler.PreferredBackBufferWidth = Settings.m_screenWidth;
			h_graphicsDeviceHandler.PreferredBackBufferHeight = Settings.m_screenHeight;
			
			h_graphicsDeviceHandler.ApplyChanges();

            GraphicsHandler.Initialise(GraphicsDevice, Content);

            TextureHandler.LoadContent();

            AudioHandler.LoadContent();

			// Initialise states
            m_menuState = new MenuState();
            m_inGameState = new InGameState();
            m_victoryState = new VictoryState();

			// Set initial state
            switch (Settings.m_startState) {
                case GameState.MAIN_MENU:
                    m_currentState = m_menuState;
                    break;
                case GameState.IN_GAME:
                    m_currentState = m_inGameState;
                    break;
                case GameState.VICTORY_SCREEN:
                    m_currentState = m_victoryState;
                    break;
            }
			
			base.Initialize();
		}

		protected override void LoadContent() {
			// Load any game content
			// ================
          }

		protected override void UnloadContent() {
			// Unload any game content
			// ================
		}

		protected override void Update(GameTime gameTime) {
			// Get user input and update the game
			// ================

			// Activate debug screen
			if(Keyboard.GetState().IsKeyDown(Keys.F1)) {
				Settings.m_debug = true;
			}

			// Deactivate debug screen
			if(Keyboard.GetState().IsKeyDown(Keys.F2)) {
				Settings.m_debug = false;
			}

			// Close window - TEMP
			if(Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Settings.SaveSettings();
				Exit();
			}

            // Reset state - TEMP
            if (Keyboard.GetState().IsKeyDown(Keys.F5)) {
                m_currentState.SetExecutionState(ExecutionState.INITIALISING);
            }

			// Set fullscreen mode
			if(Keyboard.GetState().IsKeyDown(Keys.F11) && !Settings.m_fullscreen) {
				Settings.m_fullscreen = true;
				h_graphicsDeviceHandler.IsFullScreen = Settings.m_fullscreen;
				h_graphicsDeviceHandler.ApplyChanges();
			}

			// Set windowed mode
			if(Keyboard.GetState().IsKeyDown(Keys.F12) && Settings.m_fullscreen) {
				Settings.m_fullscreen = false;
				h_graphicsDeviceHandler.IsFullScreen = Settings.m_fullscreen;
				h_graphicsDeviceHandler.ApplyChanges();
			}

			// Update current state based on its execution state
			switch(m_currentState.GetExecutionState()) {
				case ExecutionState.INITIALISING:
					// State is initialising
					
					// TODO: Pass along variables necessary for use
					m_currentState.Initialise();
					break;
				case ExecutionState.RUNNING:
					// State is currently running
					m_currentState.Update(ref h_touchHandler, gameTime);

					
					Debug.AddText(new DebugText("State: " + m_currentState.ToString().Substring(32), new Vector2(10.0f, 30.0f)));
					break;
				case ExecutionState.CHANGING:
					// State has finished and needs to be changed

					// Change state to initialising
					m_currentState.SetExecutionState(ExecutionState.INITIALISING);

					// Set state to current state
					switch(m_currentState.GetState()) {
						case GameState.MAIN_MENU:
							m_menuState = (MenuState)m_currentState;
							break;
						case GameState.IN_GAME:
							m_inGameState = (InGameState)m_currentState;
							break;
						case GameState.VICTORY_SCREEN:
							m_victoryState = (VictoryState)m_currentState;
							break;
					}

					// Change state
					switch(m_currentState.GetNextState()) {
						case GameState.MAIN_MENU:
							// Set new state
							m_currentState = m_menuState;
							break;
						case GameState.IN_GAME:
							// Set new state
							m_currentState = m_inGameState;
							break;
						case GameState.VICTORY_SCREEN:
							// Set new state
							m_currentState = m_victoryState;
							break;
					}
					break;
				default:
					goto case ExecutionState.INITIALISING;
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			// Render graphics to the screen each frame
			// ================

			switch(m_currentState.GetExecutionState()) {
				case ExecutionState.INITIALISING:
					// State is initialising

					// TODO: Show loading screen
					break;
				case ExecutionState.RUNNING:
					// State is currently running
					m_currentState.Draw(GraphicsDevice);

					// Calculate the FPS
					FrameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

					// Display the FPS and current state on the debug screen
					Debug.AddText(new DebugText(FrameCounter.AverageFramesPerSecond.ToString(), new Vector2(Settings.m_screenWidth - 75, 10), Color.Red));

					Debug.Render();
					break;
				case ExecutionState.CHANGING:
					// State has finished and needs to be changed

					// State changing, render nothing
					break;
				default:
					goto case ExecutionState.INITIALISING;
			}

			base.Draw(gameTime);
		}
	}
}
