// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Checkpoint.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.Application.Entity;

namespace Project_Cows.Source.Application.Track {
    class Checkpoint {
        // Class for the invisible checkpoints along the track
        // ================

        // Variables
        private int m_ID;
        private int m_nextID;
        private int m_pathID;

        private CheckpointType m_checkpointType;

        // Methods
        public Checkpoint(int id_, int nextID_, int pathID_, CheckpointType checkpointType_) {
            m_ID = id_;
            m_nextID = nextID_;
            m_pathID = pathID_;
            m_checkpointType = checkpointType_;
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

        public CheckpointType GetType() {
            return m_checkpointType;
        }

        public static Checkpoint First = new Checkpoint(0, 1, 0, CheckpointType.FIRST);

        public static Checkpoint Last(int numberOfCheckpoints_) {
            return new Checkpoint(numberOfCheckpoints_ - 1, 0, 0, CheckpointType.LAST);
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
