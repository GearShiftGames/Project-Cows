﻿// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// ControlScheme.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace Project_Cows.Source.System.Input {
    class ControlScheme {
        // Interface to take user input and return the control output
        // ================

        // Variables
        private double m_steeringValue;                 // Steering value, between -1 (left) and 1 (right)
        private bool m_braking;                         // True/False whether the car is braking
        private Quadrent m_quadrent;                    // Area of the screen which is being used
        private Vector2 m_homeSteeringPosition;         // The centre-point of the screen
        private float m_steeringMaxDistance;            // The maximum distance the indicator can move

        // TODO: Add relevant sprites with getters/setters for UI

        // Methods
        public ControlScheme(Quadrent quadrent_) {
            // ControlScheme constructor
            // ================

            m_quadrent = quadrent_;

            m_steeringValue = 0;
            m_braking = false;

            switch (m_quadrent) {
                case Quadrent.TOP_LEFT:
                    m_homeSteeringPosition = new Vector2(400, 400);         // Temp hard-coding
                    break;
                case Quadrent.TOP_RIGHT:
                    m_homeSteeringPosition = new Vector2(800, 400);         // Temp hard-coding
                    break;
                case Quadrent.BOTTOM_LEFT:
                    m_homeSteeringPosition = new Vector2(400, 800);         // Temp hard-coding
                    break;
                case Quadrent.BOTTOM_RIGHT:
                    m_homeSteeringPosition = new Vector2(800, 800);         // Temp hard-coding
                    break;
            }
            m_steeringMaxDistance = 200;
        }

        public void Update(List<TouchLocation> touches_) {
            // Updates the variables
            // ================
            bool performedSteering = false;

            // TODO: Process touches to control outputs for use by the player
            foreach (TouchLocation tl in touches_) {
                if (!performedSteering) {
                    // TODO: Process steering
                    float steeringDistance = m_homeSteeringPosition.X - tl.Position.X;              // Centre-point minus the touch position

                    // Clamps the distance within the max
                    if (steeringDistance > m_steeringMaxDistance) {
                        steeringDistance = m_steeringMaxDistance;
                    } else if (steeringDistance < -m_steeringMaxDistance) {
                        steeringDistance = -m_steeringMaxDistance;
                    }

                    CalculateSteeringValue(steeringDistance);

                    performedSteering = true;
                } else {
                    // TODO: Process braking
                    m_braking = true;
                }
            }

        }

        private void CalculateSteeringValue(float steeringDistance_) {
            // Processes inputs to get the steering value
            // ================
            m_steeringValue = steeringDistance_ / m_steeringMaxDistance;
        }


        // Getters
        public double GetSteeringValue() { return m_steeringValue; }

        public bool GetBraking() { return m_braking; }

        // Setters

    }

    enum Quadrent {
        // Enum for stating a quadrent of the screen
        // ================
        TOP_LEFT,
        TOP_RIGHT,
        BOTTOM_LEFT,
        BOTTOM_RIGHT
    }
}