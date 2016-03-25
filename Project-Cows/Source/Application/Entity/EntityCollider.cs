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
/// EntityCollider.cs

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System;

namespace Project_Cows.Source.Application.Entity {
    public class EntityCollider {
        // Class for the entity box collider
        // ================

        // Variables
        private Rectangle m_boundingBox;
        private Vector2 m_origin;
        private float m_rotation;

        private Sprite m_debugSprite;
        private Sprite m_corner1, m_corner2, m_corner3, m_corner4;

        // Methods
        public EntityCollider(Texture2D corner_, Texture2D texture_, Rectangle box_, float rotation_) {
            // EntityCollider constructor
            // ================

            m_boundingBox = box_;
            m_rotation = rotation_;

            m_origin = new Vector2(m_boundingBox.Width / 2, m_boundingBox.Height / 2);
       
			Vector2 scale = new Vector2((float)m_boundingBox.Width / (float)texture_.Width, (float)m_boundingBox.Height / (float)texture_.Height);
            m_debugSprite = new Sprite(texture_, GetPosition(), m_rotation, scale);
            m_corner1 = new Sprite(corner_, Vector2.Zero, 0, new Vector2(0.1f, 0.1f));
            m_corner2 = new Sprite(corner_, Vector2.Zero, 0, new Vector2(0.1f, 0.1f));
            m_corner3 = new Sprite(corner_, Vector2.Zero, 0, new Vector2(0.1f, 0.1f));
            m_corner4 = new Sprite(corner_, Vector2.Zero, 0, new Vector2(0.1f, 0.1f));
			
		}

        public EntityCollider(EntityCollider collider_) {
            // EntityCollider constructor
            // ================

            m_boundingBox = collider_.m_boundingBox;
            m_rotation = collider_.m_rotation;

            m_origin = collider_.m_origin;

            m_debugSprite = collider_.m_debugSprite;
            m_corner1 = collider_.m_corner1;
            m_corner2 = collider_.m_corner2;
            m_corner3 = collider_.m_corner3;
            m_corner4 = collider_.m_corner4;
        }

		public void UpdateSprite() {
			m_debugSprite.SetPosition(GetPosition());
			m_debugSprite.SetRotationDegrees(m_rotation);

            m_corner1.SetPosition(UpperLeftCorner());
            Debug.AddSprite(m_corner1);

            m_corner2.SetPosition(UpperRightCorner());
            Debug.AddSprite(m_corner2);

            m_corner3.SetPosition(LowerLeftCorner());
            Debug.AddSprite(m_corner3);

            m_corner4.SetPosition(LowerRightCorner());
            Debug.AddSprite(m_corner4);
		}

        private Vector2 RotatePoint(Vector2 point_, Vector2 origin_) {
            // Returns the position of a point rotated around an origin
            // ================
            Vector2 translatedPoint = new Vector2();

            translatedPoint.X = (float)(origin_.X + (point_.X - origin_.X) * Math.Cos(m_rotation * 3.1415 / 180)//GET REKT 
                - (point_.Y - origin_.Y) * Math.Sin(m_rotation * 3.1415 / 180));
            translatedPoint.Y = (float)(origin_.Y + (point_.Y - origin_.Y) * Math.Cos(m_rotation * 3.1415 / 180)
                + (point_.X - origin_.X) * Math.Sin(m_rotation * 3.1415 / 180));

            return translatedPoint;
        }

        private Vector2 UpperLeftCorner() {
            // Returns the position of the upper left corner
            // ================
            Vector2 upperLeft = new Vector2(m_boundingBox.Left, m_boundingBox.Top);
            upperLeft = RotatePoint(upperLeft, upperLeft + m_origin);
            return upperLeft;
        }

        private Vector2 UpperRightCorner() {
            // Returns the position of the upper right corner
            // ================
            Vector2 upperRight = new Vector2(m_boundingBox.Right, m_boundingBox.Top);
            upperRight = RotatePoint(upperRight, upperRight + new Vector2(-m_origin.X, m_origin.Y));
            return upperRight;
        }

        private Vector2 LowerLeftCorner() {
            // Returns the position of the lower left corner
            // ================
            Vector2 lowerLeft = new Vector2(m_boundingBox.Left, m_boundingBox.Bottom);
            lowerLeft = RotatePoint(lowerLeft, lowerLeft + new Vector2(m_origin.X, -m_origin.Y));
            return lowerLeft;
        }

        private Vector2 LowerRightCorner() {
            // Returns the position of the lower right corner
            // ================
            Vector2 lowerRight = new Vector2(m_boundingBox.Right, m_boundingBox.Bottom);
            lowerRight = RotatePoint(lowerRight, lowerRight + new Vector2(-m_origin.X, -m_origin.Y));
            return lowerRight;
        }

        // Getters
        public Vector2 GetPosition() {
            return m_boundingBox.Center.ToVector2();
        }

        public float GetWidth() {
            return m_boundingBox.Width;
        }

        public float GetHeight() {
            return m_boundingBox.Height;
        }

		public Sprite GetDebugSprite() {
			return m_debugSprite;
		}

        public Vector2 GetCornerPosition(Corner corner) {
            switch (corner) {
                case Corner.UPPER_LEFT:
                    return UpperLeftCorner();
                case Corner.UPPER_RIGHT:
                    return UpperRightCorner();
                case Corner.LOWER_LEFT:
                    return LowerLeftCorner();
                case Corner.LOWER_RIGHT:
                    return LowerRightCorner();
                default:
                    return Vector2.Zero;
            }
        }

        // Setters
        public void SetPosition(Vector2 position_) {
            m_boundingBox.X = (int)position_.X - m_boundingBox.Width/2;
			m_boundingBox.Y = (int)position_.Y - m_boundingBox.Height/2;
        }

        public void SetRotationDegrees(float degrees_) {
            m_rotation = degrees_;
        }

		public void SetRotationRadians(float radians_) {
			m_rotation = radians_ * (180 / 3.1415f);
		}

    }

    public enum Corner {
        // Enum for the four corners of a rectangle
        // ================
        UPPER_LEFT,
        UPPER_RIGHT,
        LOWER_LEFT,
        LOWER_RIGHT
    }
}
