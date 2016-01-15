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
        protected Sprite m_sprite;
        protected Vector2 m_position;
        // NOTE: vector needed for velocity, however it could be either x/y or forward/right vectors
        //       (I may be talking a bunch of shite with this...)

        // Methods


        // Getters
        public Sprite GetSprite() { return m_sprite; }


        // Setters
        public void SetSprite(Sprite sprite_) { m_sprite = sprite_; }

    }
}
