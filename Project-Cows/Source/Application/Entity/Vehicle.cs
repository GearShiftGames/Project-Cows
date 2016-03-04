// Project: Cow Racing -- GearShift Games
// Written by D. Sinclair, 2016
//            D. Divers, 2016
// ================
// Vehicle.cs

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System;

namespace Project_Cows.Source.Application.Entity {
    class Vehicle : Entity {
        // Class for the player vehicles
        // ================

        // Variables
        public float m_speed;
        private float m_steeringValue;
        private bool m_braking;

        private const float MAXSPEED = 7.5f;
        private const float ACCELERATION_RATE = 0.1f;
        private const float DECELERATION_RATE = -0.15f;
        private const float STEERING_SENSITIVITY = 10.0f;

        public Vector2 m_forward, m_right, m_velocity;

        public float sliding;
        public int turn;
        public float slide;

        public float lastMoveX = 0;
        public float lastMoveY = 0;
        int counter = 0;

        // Methods
        public Vehicle(Texture2D texture_, Vector2 position_, float m_rotation_) : base(texture_, position_, m_rotation_) {
            // Vehicle constructor
            // ================
            m_rotation = m_rotation_;
            m_speed = 0.0f;

            m_velocity.X = 0.0f;
            m_velocity.Y = 0.0f;

            m_steeringValue = 0.0f;
            m_braking = false;
            m_forward = new Vector2(0, -1);
        }

        public Vehicle(Texture2D texture_, EntityStruct entityStruct_) : base(texture_, entityStruct_) {
            // Vehicle constructor
            // ================
            m_rotation = entityStruct_.GetRotation();
            m_speed = 0.0f;

            m_velocity.X = 0.0f;
            m_velocity.Y = 0.0f;

            m_steeringValue = 0.0f;
            m_braking = false;
            m_forward = new Vector2(0, -1);
        }

        public void Update(float steeringValue_ = 0, bool braking_ = false) {
            // Updates the vehicle
            // ================
            m_steeringValue = steeringValue_;
            m_braking = braking_;

            /*if (!m_braking)
            {
                if (m_speed > 0)
                {
                    m_speed *= 1.02f;
                }
                else
                {
                    m_speed /= 1.10f;
                }
                m_speed += ACCELERATION_RATE;

                //m_velocity.X += ACCELERATION_RATE;

                counter++;

                if (counter > 50)
                    slide = 0;
            }
            else
            {
                //if you have breaked, the start reset the counter again
                counter = 0;
                sliding -= 0.02f;
                sliding *= 1.02f;

                //only do this break function if the car is not turning   
                m_speed *= 0.99f;

            }*/

            //if turning right
            /* if (steeringValue_ > 0.2) 
             {
                 if (steeringValue_ > 0.6)
                 {
                     slide += 0.1f * (m_speed / 10);

                     if (m_speed > 2.0f)
                     {
                         SetRotationRadians(GetRotationRadians() + (0.04f + (-sliding / 60)));
                     }
                     if (m_speed < 2.0f && m_speed > 0.5f)
                     {
                         SetRotationRadians(GetRotationRadians() + 0.04f);
                     }
                     m_speed *= 0.99f;
                 }
                 else
                 {
                     SetRotationRadians(GetRotationRadians() + (0.02f + (-sliding / 60)) * (m_speed / 5));
                 }	
             }

             //if turning left
             if (steeringValue_ < -0.2)
             {
                 if (steeringValue_ < -0.6)
                 {
                     slide -= 0.1f * (m_speed / 10);
                     if (m_speed > 2.0f)
                     {
                         slide -= 0.1f * (m_speed / 10);
                         if (m_speed > 2.0f)
                         {
                             SetRotationRadians(GetRotationRadians() - (0.04f + (-sliding / 60)));
                         }
                         if (m_speed < 2.0f && m_speed > 0.5f)
                         {
                             SetRotationRadians(GetRotationRadians() - 0.04f);
                         }
                     }
                     if (m_speed < 2.0f && m_speed > 0.5f)
                     {
                         SetRotationRadians(GetRotationRadians() - (0.02f + (-sliding / 60)) * (m_speed / 5));
                     }
                     m_speed *= 0.99f;
                 }
                 else
                 {
                     SetRotationRadians(GetRotationRadians() - (0.02f + (-sliding / 60)) * (m_speed / 5));
                 }
             }*/
/*
            //Cap the the speed to MAXSPEED
            if (m_speed > MAXSPEED)
            {
                m_speed = MAXSPEED;
            }

            sliding *= 0.98f;

            //Cap the sliding values, so it doesnt spin
            if (sliding > 0.4f)
            {
                sliding = 0.4f;
            }
            if (sliding < -0.4f)
            {
                sliding = -0.4f;
            }
            if (slide > 2)
            {
                slide = 2.0f;
            }
            if (slide < -2)
            {
                slide = -2.0f;
            }
*//*
            // Get steer angle
            float steer_angle = steeringValue_ * STEERING_SENSITIVITY;
            // Get forward vector
            m_forward = RotateAroundAxis(m_forward, steer_angle);

            m_speed += ACCELERATION_RATE;

            //last

            lastMoveX = m_speed * m_forward.X;
            lastMoveY = m_speed * m_forward.Y;

            m_position.X += lastMoveX;
            m_position.Y += lastMoveY;

            //m_position += m_for

            Debug.AddText(new DebugText(GetRotationRadians().ToString(), new Vector2(500, 90)));
            //reset values to false, to check the next update

            Debug.AddText(new DebugText(GetRotationRadians().ToString(), new Vector2(500, 90)));
            //reset values to false, to check the next update

            m_braking = false;
   * */

            // ==ACCELERATION==

            // Get forward vector
            m_forward.X = (float)Math.Cos(2 * Math.PI * (GetRotationDegrees()) / 360);
            m_forward.Y = (float)Math.Sin(2 * Math.PI * (GetRotationDegrees()) / 360);

            float acceleration_input;

            if (m_braking)
            {
                acceleration_input = 0.0f;
            }
            else
            {
                acceleration_input = 1.0f;
            }

            Vector2 acceleration_vector = m_forward * acceleration_input * 0.15f;

            // ==STEERING==
            float steer_angle;
            if (m_braking)
            {
                steer_angle = m_steeringValue * 2.25f;
            }
            else
            {
                steer_angle = m_steeringValue * 1.5f;
            }

            m_forward = RotateAroundAxis(m_forward, steer_angle);
            m_forward.Normalize();

            // ==MOVING==
            // Handle friction
            m_right = new Vector2(-m_forward.Y, m_forward.X);
            Vector2 lateral_velocity = m_right * Vector2.Dot(m_velocity, m_right);
            Vector2 lateral_friction = -lateral_velocity * 0.04f;
            m_velocity += lateral_friction;

            // Set the speed
            if (m_velocity.Length() < MAXSPEED) {
                m_velocity += acceleration_vector;
            }

            // Set position
            SetPosition(m_position + m_velocity);
            SetRotationDegrees(m_rotation + steer_angle);

            // TEMP
            Debug.AddText(new DebugText("Position: (" + m_position.X + ", " + m_position.Y + ")", new Vector2(100, 1000)));
            Debug.AddText(new DebugText("Rotation: " + m_rotation, new Vector2(100, 1020)));
            Debug.AddText(new DebugText("Velocity: (" + m_velocity.X + ", " + m_velocity.Y + ")", new Vector2(100, 1040)));
            Debug.AddText(new DebugText("Forward: (" + m_forward.X + ", " + m_forward.Y + ")", new Vector2(100, 1060)));

            // Update position and rotation of the vehicle's sprite
            UpdateCollider();
 
        }

        private Vector2 RotateAroundAxis(Vector2 forward_, float degrees_) {
            // Rotate a vector around an axis
            // ================
            Vector2 temp = Vector2.Zero;

            float radians = degrees_ * (float)Math.PI / 180;

            temp.X = (float)(forward_.X * Math.Cos(radians) - forward_.Y * Math.Sin(radians));
            temp.Y = (float)(forward_.X * Math.Sin(radians) + forward_.Y * Math.Cos(radians));

            return temp;

        }
    }
}

