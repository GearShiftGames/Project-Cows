// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Application.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_Cows {
	public class Application : Game {
		// Application class for the game, contains the game loop and game structure.
		// ================

		// Variables
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;



		// Methods
		public Application() {
			// Application constructor
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {
			// Any application initialisation is performed in here

			// Set up window
			
			base.Initialize();
		}

		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}

		protected override void UnloadContent() {
			// TODO: Unload any non ContentManager content here
		}

		protected override void Update(GameTime gameTime) {
			// Get user input and update the game

			// Input
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// Update
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			// Render graphics to the screen each frame

			// Clear the screen with a blank colour
			GraphicsDevice.Clear(Color.CornflowerBlue);

			base.Draw(gameTime);
		}
	}
}
