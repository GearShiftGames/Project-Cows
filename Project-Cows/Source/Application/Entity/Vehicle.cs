// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
//            D. Divers, 2016
// ================
// Vehicle.cs

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Cows.Source.Application.Entity {
    class Vehicle : Entity {
        // Class for the player vehicles
        // ================

        // Variables
        private float m_velocity;
        private float m_steeringValue;
        private bool m_braking;

        private const float MAX_SPEED = 5.0f;
        private const float ACCELERATION_RATE = 0.1f;
        private const float DECELERATION_RATE = -0.1f;
		private const float STEERING_SENSITIVITY = 5.0f;
        
        // Methods
        public Vehicle(Texture2D texture_, Vector2 position_, float rotation_) : base(texture_, position_, rotation_) {
            // Vehicle constructor
            // ================
            m_velocity = 0.0f;
            m_steeringValue = 0.0f;
            m_braking = false;
        }

        public void Update(float steeringValue_, bool braking_) {
            // Updates the vehicle
            // ================
            m_steeringValue = steeringValue_;
            m_braking = braking_;

            // Set rotation according to the steering value (touch distance)
            if (m_velocity > 1.0f) {
                float turn = m_steeringValue * -1;

                if (!m_braking) {
                    turn *= ACCELERATION_RATE * m_velocity * STEERING_SENSITIVITY;
                }

                SetRotationDegrees(GetRotationDegrees() + turn);
            }

            // Check if braking
            if (m_braking) {
                // Decelerate
                if (m_velocity > 0) {
                    m_velocity += DECELERATION_RATE;
                }else if(m_velocity < 0){
                    m_velocity = 0;
                }
            } else {
                // Accelerate
                if (m_velocity < MAX_SPEED) {
                    m_velocity += ACCELERATION_RATE;
                } else if (m_velocity > MAX_SPEED) {
                    m_velocity = MAX_SPEED;
                }
            }

			Vector2 direction = new Vector2((float)Math.Cos(GetRotationRadians()), (float)Math.Sin(GetRotationRadians()));

			direction.Normalize();

			SetPosition(GetPosition() + direction * m_velocity);

            // TODO: Set direction, position, rotation etc.
            // NOTE: Look at code from MonoGame-UI-Touch-Prototype -Dean
			UpdateSprite();
        }


        // Getters
		

        // Setters

    }
}
