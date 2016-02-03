// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
//			  D. Divers, 2016
// ================
// Player.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.Input;

using Project_Cows.Source.Application.Entity;

namespace Project_Cows.Source.Application {
    class Player {
		// Class to handle all Player functionality
		// ================

		// Variables
        public ControlScheme m_controlScheme;

        private int m_playerID;
		private Vehicle m_vehicle;

        // Methods
        public Player(Texture2D collider_, Texture2D texture_, Vector2 position_, float rotation_, float speed_, Quadrent quadrent_, int id_ = 999) {
			// Player constructor
			// ================

			m_vehicle = new Vehicle(collider_, texture_, position_, rotation_);
			
            m_controlScheme = new ControlScheme(quadrent_);
            m_playerID = id_;
        }

        public void Update(List<TouchLocation> touches_) {
            // Updates the player
            // ================

            m_controlScheme.Update(touches_);

			m_vehicle.Update(m_controlScheme.GetSteeringValue(), m_controlScheme.GetBraking());
        }

		public void UpdateSprites() {
			// Updates the player sprites
			// ================

			m_vehicle.UpdateSprites();
		}

		// Getters
		public Vehicle GetVehicle() { return m_vehicle; }

		// Setters
    }
}
