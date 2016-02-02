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
        //public Texture2D sprite;
        /*public Vector2 position;
        public Vector2 center;
        public float rotation;
        public float speed;
        public float maxspeed;
        public float sliding;
        public float slide;
        public int target;

        public RotatedRectangle m_carBounds;
        public Sprite m_car;
        public bool breaking, turnLeft, turnRight;*/

        //Control Scheme stuff
        public ControlScheme m_controlScheme;
        private int m_playerID;

		private Vehicle m_vehicle;

        // Methods
        public Player(Texture2D texture_, Vector2 position_, float rotation_, float speed_, Quadrent quadrent_, int id_ = 999) {
			// Player constructor
			// ================

            /*position = position_;
            rotation = rotation_;

            maxspeed = 5.0f;
            speed = 0f;
            //car.rotation = 0.0f;

            m_car = new Sprite(texture, position, rotation, 1.0f, true);

            center = new Vector2(m_car.GetTexture().Width / 2, m_car.GetTexture().Height / 2);

            

            //rectangle used for detecting collsions
            m_carBounds = new RotatedRectangle(new Rectangle(100, 200, texture.Width, texture.Height), 0.0f);
			*/

			m_vehicle = new Vehicle(texture_, position_, rotation_);

            m_controlScheme = new ControlScheme(quadrent_);
            m_playerID = id_;
        }

        public void Update(List<TouchLocation> touches_) {
            // Updates the player
            // ================

            m_controlScheme.Update(touches_);

			m_vehicle.Update(m_controlScheme.GetSteeringValue(), m_controlScheme.GetBraking());
			/*
            #region MovementController
            //Apply constant accelaration unless breaking
            if (!breaking)
            {
                speed *= 1.02f;
                speed += 0.01f;
            }
            else
            {
                sliding -= 0.02f;
                sliding *= 1.02f;
            }
            if (turnRight)
            {
                if (breaking)
                {
                    slide += 0.1f * (speed / 10);
                    if (speed > 2.0f)
                        rotation += (0.02f + (-sliding / 60));
                    if (speed < 2.0f && speed > 0.2f)
                        rotation += 0.02f;
                }
                else
                    rotation += (0.02f + (-sliding / 60)) * (speed / 5);
            }

            if (turnLeft)
            {
                if (breaking)
                {
                    slide -= 0.1f * (speed / 10);
                    if (speed > 2.0f)
                        rotation -= (0.02f + (-sliding / 60));
                    if (speed < 2.0f && speed > 0.2f)
                        rotation -= 0.02f;
                }
                else
                    rotation -= (0.02f + (-sliding / 60)) * (speed / 5);
            }

            if (speed > maxspeed)
                speed = maxspeed;
            speed *= 0.999f;
            sliding *= 0.99f;

            if (sliding > 0.02f || sliding < -0.02f)
                speed *= 0.99f;
            if (sliding > 0.3f)
                sliding = 0.3f;
            if (sliding < -0.3f)
                sliding = -0.3f;
            if (slide > 1)
                slide = 1.0f;
            if (slide < -1)
                slide = -1.0f;

            position.X += speed * (float)Math.Cos(rotation + (slide * sliding));
            position.Y += speed * (float)Math.Sin(rotation + (slide * sliding));

            //NOTE: I DONT KNOW WHY THESE NUMBERS WORK BUT THEY DO
            m_carBounds.collisionRectangle.X = (int)position.X - 32;
            m_carBounds.collisionRectangle.Y = (int)position.Y - 15;
            m_carBounds.m_Rotation = rotation;

           
            //reset values to false, to check the next update
            turnRight = false;
            turnLeft = false;
            breaking = false;

            #endregion
			*/
        }

		// Getters
		public Vehicle GetVehicle() { return m_vehicle; }

		// Setters
    }
}
