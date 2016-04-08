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
/// Entity.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Sprites;

namespace Project_Cows.Source.Application.Entity {
    public class Entity {
        // Class to base all game objects upon
        // ================

        // Variables
        protected Sprite m_sprite;                  // Sprite for the entity
        protected Body fs_body;                     // Physics body for the entity

        // Methods
        public Entity(World world_, Texture2D texture_, Vector2 position_, float rotation_, BodyType bodyType_, float mass_ = 10f, float restitution_ = 0.1f) {
            // Entity constructor
            // ================
            
            fs_body = BodyFactory.CreateRectangle(world_, FarseerPhysics.ConvertUnits.ToSimUnits(texture_.Width), FarseerPhysics.ConvertUnits.ToSimUnits(texture_.Height), 1f, FarseerPhysics.ConvertUnits.ToSimUnits(position_));
            fs_body.BodyType = bodyType_;
            fs_body.Mass = mass_;
            fs_body.Restitution = restitution_;
            fs_body.Rotation = Util.DegreesToRadians(rotation_);

            m_sprite = new Sprite(texture_, FarseerPhysics.ConvertUnits.ToDisplayUnits(fs_body.Position), fs_body.Rotation, new Vector2(1.0f, 1.0f));
        }

		public void UpdateSprites() {
			// Updates the position and rotation of the entity's sprite
			// ================

			m_sprite.SetPosition(FarseerPhysics.ConvertUnits.ToDisplayUnits(fs_body.Position));
			m_sprite.SetRotationDegrees(Util.RadiansToDegrees(fs_body.Rotation));
		}

        // Getters
        public Body GetBody() {
            return fs_body;
        }

        public Sprite GetSprite() {
            return m_sprite;
        }

		public Vector2 GetPosition() {
            return fs_body.Position;
        }

        public float GetRotationDegrees() {
			// Returns the entity's rotation, in degrees
			// ================

			return Util.RadiansToDegrees(fs_body.Rotation);
		}

        /*public Vector2 GetCornerPosition(System.Input.Quadrent quadrent_) {
            Vector2 position = Vector2.Zero;
            switch (quadrent_) {
                case System.Input.Quadrent.TOP_LEFT:
                    position = 
                    break;
            }
            return position;
        }*/

        // Setters
        public void SetSprite(Sprite sprite_) {
            m_sprite = sprite_;
        }

		public void SetPosition(Vector2 position_) {
            fs_body.Position = FarseerPhysics.ConvertUnits.ToSimUnits(position_);
        }

		public void SetRotationDegrees(float degrees_) {
			fs_body.Rotation = Util.DegreesToRadians(degrees_);
		}

    }
}
