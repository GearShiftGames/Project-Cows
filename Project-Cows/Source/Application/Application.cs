// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Application.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project_Cows.Source.System;
using Project_Cows.Source.System.Input;

namespace Project_Cows.Source.Application {
	public class Application : Game {
		// Application class for the game, contains the game loop and game structure.
		// ================

		// Variables
		private GraphicsDeviceManager h_graphicsDevice;		// Output graphics device
		private TouchHandler h_touchHandler;				// Touch input handler

		private Settings m_settings;						// Game settings


		// Methods
		public Application() {
			// Application constructor
			h_graphicsDevice = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			h_touchHandler = new TouchHandler();

			m_settings = new Settings();
		}

		protected override void Initialize() {
			// Initialise the application

			// Set up window
			h_graphicsDevice.IsFullScreen = m_settings.m_fullscreen;
			if(m_settings.m_fullscreen) {
				h_graphicsDevice.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
				h_graphicsDevice.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
			} else {
				h_graphicsDevice.PreferredBackBufferWidth = m_settings.m_screenWidth;
				h_graphicsDevice.PreferredBackBufferHeight = m_settings.m_screenHeight;
			}
			
			h_graphicsDevice.ApplyChanges();
			
			base.Initialize();
		}

		protected override void LoadContent() {
			// Load any game content
		}

		protected override void UnloadContent() {
			// Unload any game content
		}

		protected override void Update(GameTime gameTime) {
			// Get user input and update the game

			// Update input handlers
			h_touchHandler.Update();

			// Close window (temp)
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
				Exit();
			}

			// Toggle fullscreen
			if(Keyboard.GetState().IsKeyDown(Keys.F)) {
				m_settings.m_fullscreen = !m_settings.m_fullscreen;
				h_graphicsDevice.IsFullScreen = m_settings.m_fullscreen;
				h_graphicsDevice.ApplyChanges();
			}

			// Update objects

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			// Render graphics to the screen each frame

			// Clear the screen with a blank colour
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Render sprites


			base.Draw(gameTime);
		}
	}
}
