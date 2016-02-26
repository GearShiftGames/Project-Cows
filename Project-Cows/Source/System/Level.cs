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
        private static IniFile m_barriersData;                           // File for vehicles

        private static List<CheckpointContainer> m_checkpoints = new List<CheckpointContainer>();   // Track checkpoints
        private static List<EntityStruct> m_vehicles = new List<EntityStruct>();                    // Player vehicles
        private static List<EntityStruct> m_barriers = new List<EntityStruct>();                    // Track barriers
        // TODO: List any other object types here

        // Methods
        public static void ClearLevel() {
            // Clears the level data saved in the lists
            // ================
            m_checkpoints.Clear();
            m_vehicles.Clear();
            m_barriers.Clear();
            // TODO: Clear any other lists
        }

        public static void LoadLevel(string levelFolder){
            // Loads a level into the application
            // ================
            LoadCheckpoints(levelFolder);           // Loads track checkpoints
            LoadVehicles(levelFolder);              // Loads vehicles
            LoadBarriers(levelFolder);              // Loads barriers
        }

        private static void LoadCheckpoints(string levelFolder) {
            // Load checkpoint data into the application
            // ================
            m_checkpointData = new IniFile("\\Data\\Level\\" + levelFolder + "\\checkpoints.ini");

            bool gotAllCheckpoints = false;
            int index = 0;
            while (!gotAllCheckpoints) {
                string s_ID = m_checkpointData.ReadValue(index.ToString(), "ID");
                string s_nextID = m_checkpointData.ReadValue(index.ToString(), "nextID");
                string s_pathID = m_checkpointData.ReadValue(index.ToString(), "pathID");
                string s_positionX = m_checkpointData.ReadValue(index.ToString(), "positionX");
                string s_positionY = m_checkpointData.ReadValue(index.ToString(), "positionY");
                string s_rotation = m_checkpointData.ReadValue(index.ToString(), "rotation");


                if (IsStringEmpty(s_ID) || IsStringEmpty(s_nextID) || IsStringEmpty(s_pathID) || IsStringEmpty(s_positionX) || IsStringEmpty(s_positionY)) {
                    gotAllCheckpoints = true;
                } else {
                    int ID = Convert.ToInt32(s_ID.Replace("\0", string.Empty));
                    int nextID = Convert.ToInt32(s_nextID.Replace("\0", string.Empty));
                    int pathID = Convert.ToInt32(s_pathID.Replace("\0", string.Empty));
                    int positionX = Convert.ToInt32(s_positionX.Replace("\0", string.Empty));
                    int positionY = Convert.ToInt32(s_positionY.Replace("\0", string.Empty));
                    int rotation = Convert.ToInt32(s_rotation.Replace("\0", string.Empty));

                    m_checkpoints.Add(new CheckpointContainer(new Checkpoint(ID, nextID, pathID, new Vector2(positionX, positionY), rotation)));
                    ++index;
                }
            }
        }

        private static void LoadVehicles(string levelFolder) {
            // Load vehicles position and rotation into the application
            // ================
            m_vehicleData = new IniFile("\\Data\\Level\\" + levelFolder + "\\vehicles.ini");

            bool gotAllVehicles = false;
            int index = 0;
            while (!gotAllVehicles) {
                string s_positionX = m_vehicleData.ReadValue(index.ToString(), "positionX");
                string s_positionY = m_vehicleData.ReadValue(index.ToString(), "positionY");
                string s_rotation = m_vehicleData.ReadValue(index.ToString(), "rotation");

                if (IsStringEmpty(s_positionX) || IsStringEmpty(s_positionY) || IsStringEmpty(s_rotation)) {
                    gotAllVehicles = true;
                } else {
                    int positionX = Convert.ToInt32(s_positionX.Replace("\0", string.Empty));
                    int positionY = Convert.ToInt32(s_positionY.Replace("\0", string.Empty));
                    int rotation = Convert.ToInt32(s_rotation.Replace("\0", string.Empty));

                    m_vehicles.Add(new EntityStruct(new Vector2(positionX, positionY), rotation));
                    ++index;
                }
            }
        }

        private static void LoadBarriers(string levelFolder) {
            // Load barriers position and rotation into the application
            // ================
            m_barriersData = new IniFile("\\Data\\Level\\" + levelFolder + "\\barriers.ini");

            bool gotAllBarriers = false;
            int index = 0;
            while (!gotAllBarriers) {
                string s_positionX = m_barriersData.ReadValue(index.ToString(), "positionX");
                string s_positionY = m_barriersData.ReadValue(index.ToString(), "positionY");
                string s_rotation = m_barriersData.ReadValue(index.ToString(), "rotation");

                if (IsStringEmpty(s_positionX) || IsStringEmpty(s_positionY) || IsStringEmpty(s_rotation)) {
                    gotAllBarriers = true;
                } else {
                    int positionX = Convert.ToInt32(s_positionX.Replace("\0", string.Empty));
                    int positionY = Convert.ToInt32(s_positionY.Replace("\0", string.Empty));
                    int rotation = Convert.ToInt32(s_rotation.Replace("\0", string.Empty));

                    m_barriers.Add(new EntityStruct(new Vector2(positionX, positionY), rotation));
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

        public static List<EntityStruct> GetVehicles() {
            return m_vehicles;
        }

        public static List<EntityStruct> GetBarriers() {
            return m_barriers;
        }

        // Setters


    }
}
