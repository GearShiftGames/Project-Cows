// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// Level.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using Project_Cows.Source.Application;
using Project_Cows.Source.Application.Entity;
using Project_Cows.Source.Application.Track;

namespace Project_Cows.Source.System {
    public static class Level {
        // Class to load in level data
        // ================

        // Variables
        private static IniFile m_checkpointData;                        // File for checkpoints
        private static IniFile m_vehicleData;                           // File for vehicles

        private static List<CheckpointContainer> m_checkpoints = new List<CheckpointContainer>();    // Track checkpoints
        private static List<Vehicle> m_vehicles = new List<Vehicle>();                               // Player vehicles
        // TODO: List any other object types here

        // Methods
        public static void ClearLevel() {
            // Clears the level data saved in the lists
            // ================
            m_checkpoints.Clear();
            m_vehicles.Clear();
            // TODO: Clear any other lists
        }

        public static void LoadLevel(string levelFolder){
            // Loads a level into the application
            // ================
            LoadCheckpoints(levelFolder);           // Loads in the track checkpoints
        }

        private static void LoadCheckpoints(string levelFolder) {
            // Load checkpoint data into the application
            m_checkpointData = new IniFile("\\Data\\Level\\" + levelFolder + "\\checkpoints.ini");

            bool gotAllCheckpoints = false;
            int index = 0;
            while (!gotAllCheckpoints) {
                string s_ID = m_checkpointData.ReadValue(index.ToString(), "ID");
                string s_nextID = m_checkpointData.ReadValue(index.ToString(), "nextID");
                string s_pathID = m_checkpointData.ReadValue(index.ToString(), "pathID");
                string s_positionX = m_checkpointData.ReadValue(index.ToString(), "positionX");
                string s_positionY = m_checkpointData.ReadValue(index.ToString(), "positionY");

                if (IsStringEmpty(s_ID) || IsStringEmpty(s_nextID) || IsStringEmpty(s_pathID) || IsStringEmpty(s_positionX) || IsStringEmpty(s_positionY)) {
                    gotAllCheckpoints = true;
                } else {
                    int ID = Convert.ToInt32(s_ID.Replace("\0", string.Empty));
                    int nextID = Convert.ToInt32(s_nextID.Replace("\0", string.Empty));
                    int pathID = Convert.ToInt32(s_pathID.Replace("\0", string.Empty));
                    int positionX = Convert.ToInt32(s_positionX.Replace("\0", string.Empty));
                    int positionY = Convert.ToInt32(s_positionY.Replace("\0", string.Empty));

                    m_checkpoints.Add(new CheckpointContainer(new Checkpoint(ID, nextID, pathID, new Vector2(positionX, positionY))));
                    ++index;
                }
            }
        }



        public static bool IsStringEmpty(string s){
            if (s[0] == '\0') {
                return true;
            } else {
                return false;
            }
        }

        // Getters
        public static List<CheckpointContainer> GetCheckpoints() {
            return m_checkpoints;
        }

        // Setters


    }
}
