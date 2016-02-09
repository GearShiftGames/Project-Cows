// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Checkpoint.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.Application.Entity;

namespace Project_Cows.Source.Application.Entity {
    class Checkpoint : Entity{
        // Class for the invisible checkpoints along the track
        // ================

        // Variables
        private int m_id;

        // Methods
        public Checkpoint(int id_, ContentManager content_, Texture2D texture_, Vector2 position_, float rotation_) : base(content_, texture_, position_, rotation_) {
            m_id = id_;

        }

        // Getters
        public int GetID() {
            return m_id;
        }

        // Setters
    }
}
