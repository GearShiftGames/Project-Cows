// Project Cows -- GearShift Games
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

namespace Project_Cows.Source.Application.Entity
{
    class Vehicle : Entity
    {
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
        public Vehicle(ContentManager content_, Texture2D texture_, Vector2 position_, float m_rotation_)
            : base(content_, texture_, position_, m_rotation_)
        {
            // Vehicle constructor
            // ================
            m_rotation = m_rotation_;
            m_speed = 0.0f;

			m_velocity.X = 0.0f;
			m_velocity.Y = 0.0f;

            m_steeringValue = 0.0f;
            m_braking = false;
        }

        public Vehicle(ContentManager content_, Texture2D texture_, EntityStruct entityStruct_)
            : base(content_, texture_, entityStruct_)
        {
            // Vehicle constructor
            // ================
            m_rotation = entityStruct_.GetRotation();
            m_speed = 0.0f;
            m_steeringValue = 0.0f;
            m_braking = false;
        }

        public void Update(float steeringValue_ = 0, bool braking_ = false)
        {
            // Updates the vehicle
            // ================
            m_steeringValue = steeringValue_;
            m_braking = braking_;

            if (!m_braking) 
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
                
                if(counter >50)
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

           }

            //if turning right
            if (steeringValue_ > 0.2) 
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
			}

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

            lastMoveX = m_speed * (float)Math.Cos(GetRotationRadians() + (slide * sliding));
            lastMoveY = m_speed * (float)Math.Sin(GetRotationRadians() + (slide * sliding));

			m_position.X += lastMoveX;
			m_position.Y += lastMoveY;

            Debug.AddText(new DebugText(GetRotationRadians().ToString(), new Vector2(500, 90)));
            //reset values to false, to check the next update

                    Debug.AddText(new DebugText(GetRotationRadians().ToString(), new Vector2(500, 90)));
                    //reset values to false, to check the next update

                    m_braking = false;
                    // Update position and rotation of the vehicle's sprite
                    UpdateCollider();
                }
            }
        }

