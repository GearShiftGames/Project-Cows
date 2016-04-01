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
using Microsoft.Xna.Framework.Graphics;

using FarseerPhysics.Dynamics;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.Application.Physics;

namespace Project_Cows.Source.Application.Entity.Vehicle {
    class Vehicle : Entity {
        // Class for the player vehicles
        // ================

        // Variables
        public float m_speed;
        private float m_steeringValue;
        private bool m_braking;

        private const float MAXSPEED = 4.0f;
        private const float ACCELERATION_RATE = 10f;
        private const float DECELERATION_RATE = -0.1f;
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
        public Vehicle(World world_, Texture2D texture_, EntityStruct entityStruct_, float mass_ = 10f, float restitution_ = 0.3f)
            : base(world_, texture_, entityStruct_.GetPosition(), entityStruct_.GetRotationDegrees(), BodyType.Dynamic, mass_, restitution_) {
            // Vehicle constructor
            // ================
            m_speed = 0.0f;

            m_velocity.X = 0.0f;
            m_velocity.Y = 0.0f;

            m_steeringValue = 0.0f;
            m_braking = false;
            m_forward = new Vector2(0, -1);

            fs_body.AngularDamping = 10f;
        }

        public void Update(float steeringValue_ = 0, bool braking_ = false) {
            // Updates the vehicle
            // ================
            m_steeringValue = steeringValue_;
            m_braking = braking_;

            m_forward = new Vector2((float)Math.Cos(fs_body.Rotation), (float)Math.Sin(fs_body.Rotation));
            if (m_forward.Length() > 0) {
                m_forward.Normalize();
            }

            fs_body.ApplyAngularImpulse(steeringValue_/5000);

            if (!m_braking) {
                fs_body.ApplyForce(m_forward * ACCELERATION_RATE * 1.5f);
            }

            fs_body.Friction = 10000f;

            // TEMP
            Debug.AddText(new DebugText("Position: " + fs_body.Position.ToString(), new Vector2(100, 1000)));
            Debug.AddText(new DebugText("Rotation: " + Util.RadiansToDegrees(fs_body.Rotation), new Vector2(100, 1020)));
            Debug.AddText(new DebugText("Velocity: " + fs_body.LinearVelocity.ToString(), new Vector2(100, 1040)));
            Debug.AddText(new DebugText("Forward: " + m_forward.ToString(), new Vector2(100, 1060)));
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
            /*foreach (Barrier b in barriers_) {
                EntityCollider fuckDean = new EntityCollider(m_collider);
                Vector2 m_newPosition = fuckDean.GetPosition() + m_velocity;
                Vector2 m_barrierPosition = b.GetPosition();

                fuckDean.SetPosition(m_collider.GetPosition() + m_velocity);

                if (CollisionHandler.CheckForCollision(fuckDean, b.GetCollider())) {
                    Debug.AddText(new DebugText("New Position = " + m_newPosition, new Vector2(10.0f, 180.0f)));
                    
                    return true;
                }

            }*/
            return false;
        }

        // Getters
        public Vector2 GetVelocity()
        {
            return m_velocity;
        }

    }
}

