// Project: Cow Racing -- GearShift Games
// Based on code written by N. Headley, 2015
// Adapted by D. Sinclair, 2016
// ================
// Sprite.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Cows.Source.System.Graphics.Sprites {
	public class Sprite {
		// Basic sprite class, for drawing images to the screen
		// ================

		// Variables
		private Texture2D m_texture;		// Texture of the sprite
		private Vector2 m_position;			// Position of the sprite on the screen
		private Vector2 m_origin;			// Origin of the sprite
		private float m_rotation;			// Rotation of the sprite, in degrees
		private Vector2 m_scale;			// Scaling of the sprite
        private bool m_visible;             // Visibility of the sprite, default = true

		// Methods
        public Sprite() {}

		public Sprite(Texture2D texture_, Vector2 position_, float rotation_, Vector2 scale_, bool visible_ = true) {
			// Sprite constructor
			// ================

			SetTexture(texture_);
			SetPosition(position_);
			SetRotationDegrees(rotation_);
			SetScale(scale_);
            SetVisible(visible_);

			// Set origin to centre of texture
			SetOrigin(new Vector2(m_texture.Width / 2, 
                                m_texture.Height / 2));
		}


		// Getters
		public Texture2D GetTexture() { 
            return m_texture; 
        }

		public Vector2 GetPosition() { 
            return m_position; 
        }

		public Vector2 GetOrigin() { 
            return m_origin; 
        }

		public float GetRotationDegrees() { 
            return m_rotation; 
        }

		// TODO: Create universal function to convert deg -> rad, and vice versa -Dean
		public float GetRotationRadians() { 
            return (m_rotation * (3.1415f / 180)); 
        }

		public Vector2 GetScale() { 
            return m_scale; 
        }

        public bool IsVisible() {
            return m_visible;
        }

		public float GetWidth() { 
            return m_texture.Width; 
        }

		public float GetHeight() { 
            return m_texture.Height; 
        }


		// Setters
		public void SetTexture(Texture2D texture_) { 
            m_texture = texture_; 
        }

		public void SetPosition(Vector2 position_) { 
            m_position = position_; 
        }

		public void SetRotationDegrees(float degrees_) { 
            m_rotation = degrees_; 
        }

		public void SetRotationRadians(float radians_) { 
            m_rotation = radians_ * (180 / 3.1415f); 
        }

		public void SetScale(float scale_) {
            if (scale_ > 0) {
                m_scale = new Vector2(scale_, scale_);
            } else {
                m_scale = new Vector2(1.0f, 1.0f);
            }
        }

		public void SetScale(Vector2 scale_) {
			if(scale_.X > 0 && scale_.Y > 0) {
				m_scale = scale_;
			} else {
				m_scale = new Vector2(1.0f, 1.0f);
			}
		}

        public void SetVisible(bool visible_) {
            m_visible = visible_;
        }

        public void SetOrigin(Vector2 position_) {
            m_origin = position_;
        }

	}
}
