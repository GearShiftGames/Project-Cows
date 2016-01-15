// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// ControlScheme.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input.Touch;

namespace Project_Cows.Source.System.Input {
    class ControlScheme {
        // Interface to take user input and return the control output
        // ================

        // Variables
        private double m_steeringValue;                 // Steering value, between -1 (left) and 1 (right)
        private bool m_braking;                         // True/False whether the car is braking
        

        // Methods
        public ControlScheme() {
            // ControlScheme constructor
            // ================

            m_steeringValue = 0;
            m_braking = false;
        }

        public void Update(List<TouchLocation> touches_) {
            // Updates the variables
            // ================



        }

        private void CalculateSteeringValue() {
            // Processes inputs to get the steering value
            // ================

        }


        // Getters
        public double GetSteeringValue() { return m_steeringValue; }

        public bool GetBraking() { return m_braking; }

        // Setters

    }
}
