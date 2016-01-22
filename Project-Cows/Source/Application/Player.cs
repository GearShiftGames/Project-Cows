// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Player.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input.Touch;

using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.Input;

namespace Project_Cows.Source.Application {
    class Player {
        // Class to handle the player controls and data
        // ================

        // Variables
        private ControlScheme m_controlScheme;
        private int m_playerID;

        // Methods
        public Player(Quadrent quadrent_, int id_ = 999) {
            // Player constructor
            // ================

            m_controlScheme = new ControlScheme(quadrent_);
            m_playerID = id_;
        }

        public void Update(List<TouchLocation> touches_) {
            // Updates the player
            // ================

            // Input
            m_controlScheme.Update(touches_);

            // TODO: Move player car according to input


        }

        // Getters


        // Setters


    }
}
