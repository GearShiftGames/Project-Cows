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
        int m_ranking;

        const float MAX_SPEED = 200f;
        const float MAX_REVERSE_SPEED = -20f;
        const float MAX_DRIVE_FORCE = 50f;
        const float MAX_REVERSE_DRIVE_FORCE = -10f;
        const float MAX_LATERAL_IMPULSE = 3f;
        const float RUBBER_BAND_INTERVAL = 10f;

        // NOTE: Make the variable scopes explicit -Dean

        // Methods
        public Tyre(Quadrent quadrent_, World world_, Vector2 position_, float rotation_)
            : base(world_, TextureHandler.m_vehicleTyre, position_, rotation_, BodyType.Dynamic, 1, 1) {
            // Tyre constructor
            // ================

            m_vehicleQuadrent = quadrent_;

            // TODO: Revert to original version -Dean
            if (m_vehicleQuadrent == Quadrent.TOP_LEFT || m_vehicleQuadrent == Quadrent.TOP_RIGHT) {
                m_isPowered = false;
                m_canSteer = true;
            } else {
                m_isPowered = true;
                m_canSteer = false;
            }

        }

        public void UpdateTyre(int ranking_, float steeringValue_, bool braking_) {
            m_steeringValue = steeringValue_;
            m_braking = braking_;
            m_ranking = ranking_;

            UpdateSprites();
        }

        public void UpdateDrive() {
            if (m_isPowered) {
                // Get desired speed
                float desiredSpeed = 0;
                if (m_braking) {
                    desiredSpeed = MAX_REVERSE_SPEED;
                } else {
                    desiredSpeed = MAX_SPEED + ((m_ranking - 1) * RUBBER_BAND_INTERVAL);
                }

                // Find current forward speed
                Vector2 currentForwardNormal = fs_body.GetWorldVector(-Vector2.UnitY);
                float currentSpeed = Vector2.Dot(GetForwardVelocity(), currentForwardNormal);

                // Apply necessary force
                float force = 0;
                if (m_braking) {
                    force = MAX_REVERSE_DRIVE_FORCE;
                }else{
                    force = MAX_DRIVE_FORCE;
                }

                if (!m_braking) {
                    if (desiredSpeed > currentSpeed) {
                        force *= 1;
                    } else if (desiredSpeed < currentSpeed) {
                        force *= -1;
                    } else {
                        return;
                    }
                } else {
                    if (desiredSpeed < currentSpeed) {
                        force *= 1;
                    } else if (desiredSpeed > currentSpeed) {
                        force *= -1;
                    } else {
                        return;
                    }
                }
                

                fs_body.ApplyForce(force * currentForwardNormal);
            }
        }

        public void UpdateFriction() {
            // Lateral linear impulse
            Vector2 impulse = fs_body.Mass * -GetLateralVelocity();
            if (impulse.Length() > MAX_LATERAL_IMPULSE) {
                impulse *= MAX_LATERAL_IMPULSE / impulse.Length();
            }
            if (m_vehicleQuadrent == Quadrent.BOTTOM_LEFT || m_vehicleQuadrent == Quadrent.BOTTOM_RIGHT) {
                impulse *= 0.85f;
            } else {
                impulse *= 1f;
            }
            fs_body.ApplyLinearImpulse(impulse *0.25f);

            // Angular impulse
            fs_body.ApplyAngularImpulse(0.01f * fs_body.Inertia * -fs_body.AngularVelocity);

            // Forward linear velocity
            Vector2 currentForwardNormal = GetForwardVelocity();
            float currentForwardSpeed = currentForwardNormal.Length();      // NOTE: Possibly not right, but it should be -Dean
            float dragForceMagnitude = -1 * currentForwardSpeed;
            fs_body.ApplyForce(dragForceMagnitude * currentForwardNormal);
        }

        public void UpdateTurn() {
            // NOTE: DEPRECATED
            if (m_canSteer) {
                float desiredTorque = 0;
                desiredTorque = m_steeringValue * 0.0001f;        // TODO: Replace magic number with const -Dean
                fs_body.ApplyTorque(desiredTorque);
            }
        }

        private Vector2 GetLateralVelocity() {
            // Returns the lateral (right) velocity of the tyre
            // ================
            Vector2 currentRightNormal = fs_body.GetWorldVector(Vector2.UnitX);
            return Vector2.Dot(currentRightNormal, fs_body.LinearVelocity) * currentRightNormal;
        }

        private Vector2 GetForwardVelocity() {
            // Returns the forward velocity of the tyre
            // ================
            Vector2 currentForwardNormal = fs_body.GetWorldVector(-Vector2.UnitY);
            return Vector2.Dot(currentForwardNormal, fs_body.LinearVelocity) * currentForwardNormal;
        }

        // Getters


        // Setters
    }
}
