// Project Cows -- GearShift Games
// Based on code written by N. Headley, 2015
// Adapted by D. Sinclair, 2016
// ================
// Sprite.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Cows.Source.System.Graphics {
	public class Sprite {
		// Basic sprite class, for drawing images to the screen
		// ================

		// Variables
		private Texture2D m_texture;		// Texture of the sprite
		private Vector2 m_position;			// Position of the sprite on the screen
		private Vector2 m_origin;			// Origin of the sprite
		private float m_rotation;			// Rotation of the sprite, in degrees
		private float m_scale;				// Scaling of the sprite


		// Methods
		public Sprite() { }

		public Sprite(Texture2D texture_, Vector2 position_, float rotation_, float scale_) {
			// Sprite constructor
			// ================
			m_texture = texture_;
			m_position = position_;
			m_rotation = rotation_;
			m_scale = scale_;

			// Set origin to centre of texture
			m_origin.X = m_position.X + (m_texture.Width / 2);
			m_origin.Y = m_position.Y + (m_texture.Height / 2);
		}


		// Getters
		public Texture2D GetTexture() { return m_texture; }

		public Vector2 GetPosition() { return m_position; }

		public Vector2 GetOrigin() { return m_origin; }

		public float GetRotationDegrees() { return m_rotation; }

		// TODO: Create universal function to convert deg -> rad, and vice versa
		public float GetRotationRadians() { return (m_rotation * (3.1415f / 180)); }

		public float GetScale() { return m_scale; }

		public float GetWidth() { return m_texture.Width; }

		public float GetHeight() { return m_texture.Height; }


		// Setters
		public void SetTexture(Texture2D texture_) { m_texture = texture_; }

		public void SetPosition(Vector2 position_) { m_position = position_; }

		public void SetRotationDegrees(float degrees_) { m_rotation = degrees_; }

		public void SetRotationRadians(float radians_) { m_rotation = radians_ * (180 / 3.1415f); }

		// WARNING: no validation is performed, so scale could be set to 0
		public void SetScale(float scale_) { m_scale = scale_; }

	}
}
