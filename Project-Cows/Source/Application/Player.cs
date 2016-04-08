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
/// Player.cs

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using FarseerPhysics.Dynamics;

using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.Input;
using Project_Cows.Source.Application.Entity;
using Project_Cows.Source.Application.Track;
using Project_Cows.Source.Application.Entity.Vehicle;

namespace Project_Cows.Source.Application {
    class Player {
		// Class to handle all Player functionality
		// ================

		// Variables
        public ControlScheme m_controlScheme;

        private World fs_world;

        private int m_playerID;
        private int m_collideID;
		private Vehicle m_vehicle;
        private Sprite m_cow;
        
        public Checkpoint m_currentCheckpoint;
        public int m_currentLap;

        private bool m_keyLeft;
        private bool m_keyRight;
        private bool m_keyBraking;
        private bool m_finished;
        private int m_raceTime;
        private int m_finishTime;

        // Methods
        public Player(World world_, Texture2D cowTexture_, Texture2D texture_, EntityStruct entityStruct_, float speed_, Quadrent quadrent_, int id_ = 999) {
            // Player constructor
            // ================
            m_vehicle = new Vehicle(world_, texture_, entityStruct_);
            m_cow = new Sprite(cowTexture_, entityStruct_.GetPosition(), entityStruct_.GetRotationDegrees(), new Vector2(0.1f, 0.1f));

            m_controlScheme = new ControlScheme(quadrent_);
            m_playerID = id_;

            m_currentCheckpoint = Checkpoint.First(Vector2.Zero);
            m_currentLap = 1;
            m_finished = false;
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

            m_cow.SetPosition(m_vehicle.m_vehicleBody.GetPosition());
            m_cow.SetRotationDegrees(m_vehicle.m_vehicleBody.GetRotationDegrees());
        }

		public void UpdateSprites() {
			// Updates the player sprites
			// ================

			//m_vehicle.UpdateSprites();
		}

        public void KeyboardMove(bool left_, bool right_, bool braking_) {
            m_keyLeft = left_;
            m_keyRight = right_;
            m_keyBraking = braking_;
        }

		// Getters
        public int GetID() {
            return m_playerID;
        }

        public int GetCollideID() {
            return m_collideID;
        }

		public Vehicle GetVehicle() { return m_vehicle; }
        public Sprite GetCow() { return m_cow; }
        public bool GetFinished() {
            return m_finished;
        }
        public int GetRaceTime()
        {
            return m_raceTime;
        }
        public int GetFinishTime()
        {
            return m_finishTime;
        }

		// Setters
        public void SetCollideID(int ID_) {
            m_collideID = ID_;
        }
        public void SetFinished(bool finished_) {
            m_finished = finished_;
        }
        public void AddRaceTime(int time_)
        {
            m_raceTime += time_;
        }
        public void AddFinishTime(int time_)
        {
            m_finishTime += time_;
        }
    }
}
