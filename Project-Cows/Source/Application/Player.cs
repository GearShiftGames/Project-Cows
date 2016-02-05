// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
//			  D. Divers, 2016
// ================
// Player.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        public int m_currentCheckpoint;
        public int m_currentLap;

        private bool m_keyLeft;
        private bool m_keyRight;
        private bool m_keyBraking;

        // Methods
        public Player(ContentManager content_, Texture2D texture_, Vector2 position_, float rotation_, float speed_, Quadrent quadrent_, int id_ = 999) {
			// Player constructor
			// ================

			m_vehicle = new Vehicle(content_, texture_, position_, rotation_);
			
            m_controlScheme = new ControlScheme(quadrent_);
            m_playerID = id_;

            m_currentCheckpoint = 0;
            m_currentLap = 1;
        }

        public void Update(List<TouchLocation> touches_) {
            // Updates the player
            // ================

            m_controlScheme.Update(touches_);

            if (!m_keyLeft && !m_keyRight && !m_keyBraking) {
                m_vehicle.Update(m_controlScheme.GetSteeringValue(), m_controlScheme.GetBraking());
            } else {
                float turn = 0;
                if (m_keyLeft) {
                    turn -= 1;
                }
                if (m_keyRight) {
                    turn += 1;
                }
                m_vehicle.Update(turn, m_keyBraking);
            }
        }

		public void UpdateSprites() {
			// Updates the player sprites
			// ================

			m_vehicle.UpdateSprites();
		}

        public void KeyboardMove(bool left_, bool right_, bool braking_) {
            m_keyLeft = left_;
            m_keyRight = right_;
            m_keyBraking = braking_;
        }

		// Getters
		public Vehicle GetVehicle() { return m_vehicle; }

		// Setters
    }
}
