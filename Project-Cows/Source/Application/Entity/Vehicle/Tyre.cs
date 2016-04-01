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
/// Tyre.cs

using System;

using Microsoft.Xna.Framework;

using FarseerPhysics.Dynamics;

using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.Graphics;

namespace Project_Cows.Source.Application.Entity.Vehicle {
    class Tyre : Entity {
        // Class to handle tyre movement for player vehicles
        // ================

        // Variables
        Quadrent m_vehicleQuadrent;
        bool m_isPowered;
        bool m_canSteer;

        float m_steeringValue;
        bool m_braking;

        const float MAX_SPEED = 100;
        const float MAX_REVERSE_SPEED = -10f;
        const float MAX_DRIVE_FORCE = 15f;

        // NOTE: Make the variable scopes explicit

        // Methods
        public Tyre(Quadrent quadrent_, World world_, Vector2 position_, float rotation_)
            : base(world_, TextureHandler.m_vehicleBlue, position_, rotation_, BodyType.Dynamic) {
            // Tyre constructor
            // ================

            m_vehicleQuadrent = quadrent_;

            if (m_vehicleQuadrent == Quadrent.TOP_LEFT || m_vehicleQuadrent == Quadrent.TOP_RIGHT) {
                m_isPowered = false;
                m_canSteer = true;
            } else {
                m_isPowered = true;
                m_canSteer = false;
            }

        }

        public void UpdateTyre(float steeringValue_, bool braking_) {
            m_steeringValue = steeringValue_;
            m_braking = braking_;

            // NOTE: Might have to update the friction of all tyres, then update the drive of
            //       the tyres instead of doing one at a time -Dean

            if (m_isPowered) {
                UpdateFriction();
                UpdateDrive();

            }

            // Update tyre sprite - TEMP
            UpdateSprites();
        }

        private void UpdateDrive() {
            // Get desired speed
            float desiredSpeed = 0;
            if (!m_braking) {
                desiredSpeed = MAX_SPEED;
            } else {
                desiredSpeed = MAX_REVERSE_SPEED;
            }

            // Find current forward speed
            Vector2 currentForwardNormal = fs_body.GetWorldVector(Vector2.UnitX);
            float currentSpeed = Vector2.Dot(GetForwardVelocity(), currentForwardNormal);

            // Apply necessary force
            float force = 0;
            if (desiredSpeed > currentSpeed) {
                force = MAX_DRIVE_FORCE;
            } else if (desiredSpeed < currentSpeed) {
                force = -MAX_DRIVE_FORCE;
            } else {
                return;
            }

            fs_body.ApplyForce(force * currentForwardNormal);
        }

        private void UpdateFriction() {
            // Lateral linear impulse
            Vector2 impulse = fs_body.Mass * -GetLateralVelocity();
            fs_body.ApplyLinearImpulse(impulse);

            // Angular impulse
            fs_body.ApplyAngularImpulse(0.1f * fs_body.Inertia * -fs_body.AngularVelocity);

            // Forward linear velocity
            Vector2 currentForwardNormal = GetForwardVelocity();
            float currentForwardSpeed = currentForwardNormal.Length();      // NOTE: Possibly not right, but it should be -Dean
            float dragForceMagnitude = -2 * currentForwardSpeed;
            fs_body.ApplyForce(dragForceMagnitude * currentForwardNormal);
        }

        private Vector2 GetLateralVelocity() {
            // Returns the lateral (right) velocity of the tyre
            // ================
            Vector2 currentRightNormal = fs_body.GetWorldVector(Vector2.UnitY);
            return Vector2.Dot(currentRightNormal, fs_body.LinearVelocity) * currentRightNormal;
        }

        private Vector2 GetForwardVelocity() {
            // Returns the forward velocity of the tyre
            // ================
            Vector2 currentForwardNormal = fs_body.GetWorldVector(Vector2.UnitX);
            return Vector2.Dot(currentForwardNormal, fs_body.LinearVelocity) * currentForwardNormal;
        }

        // Getters


        // Setters
    }
}
