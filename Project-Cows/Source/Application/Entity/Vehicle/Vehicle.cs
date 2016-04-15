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
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Sprites;

namespace Project_Cows.Source.Application.Entity.Vehicle {
    class Vehicle {
        // Class for the player vehicles
        // ================

        // Variables
        public Entity m_vehicleBody;
        public List<Tyre> m_vehicleTyres = new List<Tyre>();
        private RevoluteJoint m_frontLeftJoint;
        private RevoluteJoint m_frontRightJoint;
        private RevoluteJoint m_backLeftJoint;
        private RevoluteJoint m_backRightJoint;

        // Methods
        public Vehicle(World world_, Texture2D texture_, EntityStruct entityStruct_) {
            // Vehicle constructor
            // ================

            // Initialise the vehicle's main body
            m_vehicleBody = new Entity(world_, texture_, entityStruct_.GetPosition(), 0, BodyType.Dynamic, 10, 0.1f);

            m_vehicleBody.GetBody().AngularDamping = 1;
            m_vehicleBody.GetBody().LinearDamping = 1;

            // Initialise the vehicle's wheels
            Vector2 frontLeftPosition = FarseerPhysics.ConvertUnits.ToDisplayUnits(m_vehicleBody.GetPosition()) + new Vector2(-m_vehicleBody.GetSprite().GetWidth() / 2, -m_vehicleBody.GetSprite().GetHeight() / 2);
            m_vehicleTyres.Add(new Tyre(System.Input.Quadrent.TOP_LEFT, world_, frontLeftPosition, m_vehicleBody.GetRotationDegrees()));

            Vector2 frontRightPosition = FarseerPhysics.ConvertUnits.ToDisplayUnits(m_vehicleBody.GetPosition()) + new Vector2(m_vehicleBody.GetSprite().GetWidth() / 2, -m_vehicleBody.GetSprite().GetHeight() / 2);
            m_vehicleTyres.Add(new Tyre(System.Input.Quadrent.TOP_RIGHT, world_, frontRightPosition, m_vehicleBody.GetRotationDegrees()));

            Vector2 backLeftPosition = FarseerPhysics.ConvertUnits.ToDisplayUnits(m_vehicleBody.GetPosition()) + new Vector2(-m_vehicleBody.GetSprite().GetWidth() / 2, m_vehicleBody.GetSprite().GetHeight() / 2);
            m_vehicleTyres.Add(new Tyre(System.Input.Quadrent.BOTTOM_LEFT, world_, backLeftPosition, m_vehicleBody.GetRotationDegrees()));

            Vector2 backRightPosition = FarseerPhysics.ConvertUnits.ToDisplayUnits(m_vehicleBody.GetPosition()) - new Vector2(m_vehicleBody.GetSprite().GetWidth() / 2, m_vehicleBody.GetSprite().GetHeight() / 2);
            m_vehicleTyres.Add(new Tyre(System.Input.Quadrent.BOTTOM_RIGHT, world_, backRightPosition, m_vehicleBody.GetRotationDegrees()));

            // Create joints for each of the wheels to the body
            // Front Left
            m_frontLeftJoint = JointFactory.CreateRevoluteJoint(world_,
                m_vehicleBody.GetBody(),
                m_vehicleTyres[0].GetBody(),
                FarseerPhysics.ConvertUnits.ToSimUnits(new Vector2(-m_vehicleBody.GetSprite().GetWidth() / 2 * 0.8f, -m_vehicleBody.GetSprite().GetHeight() / 2 * 0.7f)),
                Vector2.Zero, false);
            m_frontLeftJoint.LowerLimit = Util.DegreesToRadians(-10);
            m_frontLeftJoint.UpperLimit = Util.DegreesToRadians(10);
            m_frontLeftJoint.LimitEnabled = true;
            m_frontLeftJoint.MotorEnabled = true;
            m_frontLeftJoint.MaxMotorTorque = 100;

            // Front right
            m_frontRightJoint = JointFactory.CreateRevoluteJoint(world_,
                m_vehicleBody.GetBody(),
                m_vehicleTyres[1].GetBody(),
                FarseerPhysics.ConvertUnits.ToSimUnits(new Vector2(m_vehicleBody.GetSprite().GetWidth() / 2 * 0.8f, -m_vehicleBody.GetSprite().GetHeight() / 2 * 0.7f)),
                Vector2.Zero, false);
            m_frontRightJoint.LowerLimit = Util.DegreesToRadians(-10);
            m_frontRightJoint.UpperLimit = Util.DegreesToRadians(10);
            m_frontRightJoint.LimitEnabled = true;
            m_frontRightJoint.MotorEnabled = true;
            m_frontRightJoint.MaxMotorTorque = 100;

            // Back left
            m_backLeftJoint = JointFactory.CreateRevoluteJoint(world_,
                m_vehicleBody.GetBody(),
                m_vehicleTyres[2].GetBody(),
                FarseerPhysics.ConvertUnits.ToSimUnits(new Vector2(-m_vehicleBody.GetSprite().GetWidth() / 2 * 0.8f, m_vehicleBody.GetSprite().GetHeight() / 2 * 0.7f)),
                Vector2.Zero, false);
            m_backLeftJoint.LowerLimit = 0;
            m_backLeftJoint.UpperLimit = 0;
            m_backLeftJoint.LimitEnabled = true;

            // Back right
            m_backRightJoint = JointFactory.CreateRevoluteJoint(world_,
                m_vehicleBody.GetBody(),
                m_vehicleTyres[3].GetBody(),
                FarseerPhysics.ConvertUnits.ToSimUnits(new Vector2(m_vehicleBody.GetSprite().GetWidth() / 2 * 0.8f, m_vehicleBody.GetSprite().GetHeight() / 2 * 0.7f)),
                Vector2.Zero, false);
            m_backLeftJoint.LowerLimit = 0;
            m_backLeftJoint.UpperLimit = 0;
            m_backRightJoint.LimitEnabled = true;

            m_vehicleBody.SetRotationDegrees(entityStruct_.GetRotationDegrees());
            m_vehicleBody.UpdateSprites();
        }

        public void Update(int ranking_, float steeringValue_ = 0, bool braking_ = false) {
            // Updates the vehicle
            // ================

            foreach (Tyre t in m_vehicleTyres) {
                t.UpdateTyre(ranking_, steeringValue_, braking_);
                t.UpdateFriction();
            }

            foreach (Tyre t in m_vehicleTyres) {
                t.UpdateDrive();

                float lockAngle = Util.DegreesToRadians(20);
                float turnSpeedPerSec = Util.DegreesToRadians(320);
                float turnPerTimeStep = turnSpeedPerSec / 60;
                float desiredAngle = steeringValue_ * lockAngle;
                float angleNow = m_frontLeftJoint.JointAngle;
                float angleToTurn = desiredAngle - angleNow;
                angleToTurn = FarseerPhysics.Common.MathUtils.Clamp(angleToTurn, -turnPerTimeStep, turnPerTimeStep);
                float newAngle = angleNow + angleToTurn;
                m_frontLeftJoint.SetLimits(newAngle, newAngle);
                m_frontRightJoint.SetLimits(newAngle, newAngle);

                t.UpdateSprites();
            }

            Debug.AddText("Body position D: " + FarseerPhysics.ConvertUnits.ToDisplayUnits(m_vehicleBody.GetPosition()).ToString(), new Vector2(10, 300));
            Debug.AddText("Body position S: " + m_vehicleBody.GetPosition().ToString(), new Vector2(10, 320));
            Debug.AddText("FL position D: " + FarseerPhysics.ConvertUnits.ToDisplayUnits(m_vehicleTyres[0].GetPosition()).ToString(), new Vector2(10, 360));
            Debug.AddText("FL position S: " + m_vehicleTyres[0].GetPosition().ToString(), new Vector2(10, 380));
            Debug.AddText("FL rotation: " + Util.RadiansToDegrees(m_frontLeftJoint.JointAngle).ToString(), new Vector2(10, 400));
            Debug.AddText("FR position D: " + FarseerPhysics.ConvertUnits.ToDisplayUnits(m_vehicleTyres[1].GetPosition()).ToString(), new Vector2(10, 420));
            Debug.AddText("FR position S: " + m_vehicleTyres[1].GetPosition().ToString(), new Vector2(10, 440));
            Debug.AddText("FR rotation: " + Util.RadiansToDegrees(m_frontRightJoint.JointAngle).ToString(), new Vector2(10, 460));
            m_vehicleBody.UpdateSprites();
        }
    }
}

