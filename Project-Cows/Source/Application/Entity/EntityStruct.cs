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
/// EntityStruct.cs


using Microsoft.Xna.Framework;

namespace Project_Cows.Source.Application.Entity {
    public class EntityStruct {
        // Class to hold an Entity Struct, for use with creating Entities
        // ================

        // Variables
        private Vector2 m_position;
        private float m_rotation;

        // Methods
        public EntityStruct(Vector2 position_, float rotation_ = 0) {
            // EntityStruct constructor
            // ================

            m_position = position_;
            m_rotation = rotation_;
        }

        // Getters
        public Vector2 GetPosition() { return m_position; }
        public float GetRotation() { return m_rotation; }

        // Setters
        public void SetPosition(Vector2 position_) { m_position = position_; }
        public void SetRotation(float rotation_) { m_rotation = rotation_; }
    }
}
