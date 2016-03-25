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
/// Vehicle.cs

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.Application.Physics;

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

        private bool barrierHit = false;

        public Sprite debugSprite = new Sprite(TextureHandler.m_tempRed, new Vector2(0.0f, 0.0f), 0.0f, new Vector2(1.0f, 1.0f));

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
            //SetPosition(m_position + m_velocity);
            debugSprite.SetPosition(m_position + m_velocity*10);
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

        public bool HasHitBarrier(List<Barrier> barriers_) {
            foreach (Barrier b in barriers_) {
                EntityCollider fuckDean = new EntityCollider(m_collider);
                Vector2 m_newPosition = fuckDean.GetPosition() + m_velocity;
                Vector2 m_barrierPosition = b.GetPosition();

                fuckDean.SetPosition(m_collider.GetPosition() + m_velocity);

                if (CollisionHandler.CheckForCollision(fuckDean, b.GetCollider())) {
                    Debug.AddText(new DebugText("New Position = " + m_newPosition, new Vector2(10.0f, 180.0f)));
                    
                    return true;
                }

            }
            return false;
        }

        // Getters
        public Vector2 GetVelocity()
        {
            return m_velocity;
        }

    }
}

