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
/// Checkpoint.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.Application.Entity;

namespace Project_Cows.Source.Application.Track {
    public class Checkpoint {
        // Class for the invisible checkpoints along the track
        // ================

        // Variables
        private int m_ID;
        private int m_nextID;
        private int m_pathID;
        private Vector2 m_position;
        private float m_rotation;

        private CheckpointType m_checkpointType;

        // Methods
        public Checkpoint(int id_, int nextID_, int pathID_, Vector2 position_, float rotation_) {
            m_ID = id_;
            m_nextID = nextID_;
            m_pathID = pathID_;
            m_position = position_;
            m_rotation = rotation_;

            // Set checkpoint type
            if (m_ID == 0) {
                m_checkpointType = CheckpointType.FIRST;
            } else if (m_nextID == 0) {
                m_checkpointType = CheckpointType.LAST;
            } else {
                m_checkpointType = CheckpointType.NORMAL;
            }
        }

        // Getters
        public int GetID() {
            return m_ID;
        }

        public int GetNextID(){
            return m_nextID;
        }

        public int GetPath() {
            return m_pathID;
        }

        public Vector2 GetPosition() {
            return m_position;
        }

        public float GetRotation() {
            return m_rotation;
        }

        public CheckpointType GetType() {
            return m_checkpointType;
        }

        public static Checkpoint First(Vector2 position_) {
            return new Checkpoint(0, 1, 0, position_, 0);
        }

        public static Checkpoint Last(int numberOfCheckpoints_, Vector2 position_) {
            return new Checkpoint(numberOfCheckpoints_ - 1, 0, 0, position_, 0);
        }

        // Setters
    }

    public enum CheckpointType {
        // Enum for stating the special type of checkpoint
        // ================
        NORMAL,
        FIRST,
        LAST
    }
}
