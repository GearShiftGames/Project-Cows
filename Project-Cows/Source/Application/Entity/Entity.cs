// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Entity.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Project_Cows.Source.System.Graphics.Sprites;

namespace Project_Cows.Source.Application.Entity {
    class Entity {
        // Class to base all game objects upon
        // ================

        // Variables
        protected Sprite m_sprite;                  // Sprite for the entity
        protected Vector2 m_position;               // Position of the entity
        protected bool m_visible;                   // Whether the entity is visible or not
        protected bool m_collidable;                // Whether the entity is collidable

        // Methods
        public Entity() {
            // Entity constructor
            // ================

        }


        // Getters
        public Sprite GetSprite() { return m_sprite; }


        // Setters
        public void SetSprite(Sprite sprite_) { m_sprite = sprite_; }

    }
}
