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
/// Button.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System.Input;
using Project_Cows.Source.System.Graphics.Sprites;

namespace Project_Cows.Source.Application {
    class Button {
        // Class for menu buttons
        // ================

        // Variables
        public Sprite m_sprite;
        public TouchZone m_touchZone;
        public bool m_active;

        // Methods
        public Button(Texture2D texture_, Vector2 position_) {
            // Button constructor
            // ================
            m_sprite = new Sprite(texture_, position_, 0, Vector2.One);

            Vector2 halfDim = new Vector2(m_sprite.GetWidth() / 2, m_sprite.GetHeight() / 2);
            m_touchZone = new TouchZone(m_sprite.GetPosition() - halfDim, m_sprite.GetPosition() + halfDim);

            m_active = true;
        }
        public Button(Sprite sprite_, TouchZone zone_) {
            // Button constructor
            // ================
            m_sprite = sprite_;
            m_touchZone = zone_;

            m_active = true;
        }
        public Button(Sprite sprite_) {
            // Button constructor
            // ================
            m_sprite = sprite_;

            m_active = true;
        }
        
        // Getters


        // Setters


    }
}
