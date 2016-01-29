// Project Cows -- GearShift Games
// Written by D. Divers, 2016
//            D. Sinclair, 2016
// ================
// EntityCollider.cs

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Project_Cows.Source.System.Graphics;

namespace Project_Cows.Source.Application.Entity {
    class EntityCollider {
        // Class for the entity box collider
        // ================

        // Variables
        private Rectangle m_boundingBox;
        private Vector2 m_origin;
        private float m_rotation;

        // Methods
        public EntityCollider(Rectangle box_, float rotation_) {
            // EntityCollider constructor
            // ================

            m_boundingBox = box_;
            m_rotation = rotation_;

            m_origin = new Vector2((int)m_boundingBox.Width / 2, (int)m_boundingBox.Height / 2);
        }

        private Vector2 RotatePoint(Vector2 point_, Vector2 origin_) {
            Vector2 translatedPoint = new Vector2();

            translatedPoint.X = (float)(origin_.X + (point_.X - origin_.X) * Math.Cos(m_rotation)
                - (point_.Y - origin_.Y) * Math.Sin(m_rotation));
            translatedPoint.Y = (float)(origin_.Y + (point_.Y - origin_.Y) * Math.Cos(m_rotation)
                - (point_.X - origin_.X) * Math.Sin(m_rotation));

            return translatedPoint;
        }

        private Vector2 UpperLeftCorner() {
            Vector2 upperLeft = new Vector2(m_boundingBox.Left, m_boundingBox.Top);
            upperLeft = RotatePoint(upperLeft, upperLeft - m_origin);
            return upperLeft;
        }

        private Vector2 UpperRightCorner() {
            Vector2 upperRight = new Vector2(m_boundingBox.Right, m_boundingBox.Top);
            upperRight = RotatePoint(upperRight, upperRight + new Vector2(-m_origin.X, m_origin.Y));
            return upperRight;
        }

        private Vector2 LowerLeftCorner() {
            Vector2 lowerLeft = new Vector2(m_boundingBox.Left, m_boundingBox.Bottom);
            lowerLeft = RotatePoint(lowerLeft, lowerLeft + new Vector2(m_origin.X, -m_origin.Y));
            return lowerLeft;
        }

        private Vector2 LowerRightCorner() {
            Vector2 lowerRight = new Vector2(m_boundingBox.Right, m_boundingBox.Bottom);
            lowerRight = RotatePoint(lowerRight, lowerRight +- m_origin);
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

        public void SetRotation(float rotation_) {
            m_rotation = rotation_;
        }

    }

    enum Corner {
        UPPER_LEFT,
        UPPER_RIGHT,
        LOWER_LEFT,
        LOWER_RIGHT
    }
}
