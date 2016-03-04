// Project Cows -- GearShift Games
// Written by D. Sinclair, 2016
// ================
// TrackHandler.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.Application.Entity;
using Project_Cows.Source.Application.Physics;
using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;

namespace Project_Cows.Source.Application.Track {
    class TrackHandler {
        // Class to handle any aspects of the track
        // ================

        // Variables
        public List<CheckpointContainer> m_checkpoints = new List<CheckpointContainer>();
        public List<EntityStruct> m_vehicles = new List<EntityStruct>();
        public List<Barrier> m_barriers = new List<Barrier>();
        private List<int> m_rankings = new List<int>();

        private Texture2D m_checkpointTexture, m_barriersTexture;

        // Methods
        public TrackHandler() {
            // TrackHandler constructor
            // ================
        }

        public void Initialise(ContentManager content_) {
            m_checkpoints.Clear();
            m_vehicles.Clear();
            m_barriers.Clear();
            m_rankings.Clear();

            // Set checkpoint texture
            m_checkpointTexture = content_.Load<Texture2D>("Sprites\\Utility\\checkpoint");
            m_barriersTexture = content_.Load<Texture2D>("Sprites\\Track\\Barriers\\barrier");

            // Add checkpoints
            Level.LoadLevel("0");       // NOTE: This would be done in the in-game state in future -Dean
            m_checkpoints = Level.GetCheckpoints();
            // Add entities to the checkpoints
            foreach (CheckpointContainer cc in m_checkpoints) {
                cc.SetEntity(content_, m_checkpointTexture, cc.GetCheckpoint().GetRotation());
            }

            // Add vehicles
            m_vehicles = Level.GetVehicles();

            // Add barriers
            List<EntityStruct> m_barrierEntityStructs = new List<EntityStruct>();
            m_barrierEntityStructs = Level.GetBarriers();
            // Add entities to Barriers
            foreach (EntityStruct es in m_barrierEntityStructs) {
                m_barriers.Add(new Barrier(content_, m_barriersTexture, es));
            }

            // NOTE: Unneeded now, but kept for testing purposes -Dean
            /*m_checkpoints.Add(new CheckpointContainer(new Checkpoint(0, 1, 0, new Vector2(500f, 300f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(1, 2, 0, new Vector2(600f, 250f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(2, 3, 0, new Vector2(700f, 250f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(3, 4, 0, new Vector2(800f, 250f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(4, 5, 0, new Vector2(900f, 250f))));

            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(1, 2, 1, new Vector2(600f, 350f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(2, 3, 1, new Vector2(700f, 350f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(3, 4, 1, new Vector2(800f, 350f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(4, 5, 1, new Vector2(900f, 350f))));


            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(5, 6, 0, new Vector2(1000f, 300f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(6, 7, 0, new Vector2(1100f, 300f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(7, 8, 0, new Vector2(1200f, 300f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(8, 9, 0, new Vector2(1300f, 500f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(9, 10, 0, new Vector2(1200f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(10, 11, 0, new Vector2(1100f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(11, 12, 0, new Vector2(1000f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(12, 13, 0, new Vector2(900f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(13, 14, 0, new Vector2(800f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(14, 15, 0, new Vector2(700f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(15, 16, 0, new Vector2(600f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(16, 17, 0, new Vector2(500f, 700f))));
            m_checkpoints.Add(new CheckpointContainer(new Checkpoint(17, 0, 0, new Vector2(400f, 500f))));*/

        }

        public void Update(List<Player> players_){
            Debug.AddText(new DebugText("Checkpoints:" + m_checkpoints.Count(), new Vector2(20, 500)));        // TEMP
            Debug.AddText(new DebugText("Players:" + players_.Count(), new Vector2(20, 520)));        // TEMP

            // Checkpoint collision
            foreach (Player p in players_) {
                foreach (CheckpointContainer cc in m_checkpoints) {
                    if (CollisionHandler.CheckForCollision(p.GetVehicle().GetCollider(), cc.GetEntity().GetCollider())) {
                        if (cc.GetCheckpoint().GetID() == p.m_currentCheckpoint.GetNextID()) {
                            p.m_currentCheckpoint = cc.GetCheckpoint();
                            if (p.m_currentCheckpoint.GetType() == CheckpointType.FIRST) {
                                ++p.m_currentLap;
                            }
                        }
                    }
                }
                Debug.AddText(new DebugText("Player " + p.GetID(), new Vector2(20.0f + 150 * p.GetID(), 70.0f)));
                Debug.AddText(new DebugText("Lap: " + p.m_currentLap.ToString(), new Vector2(20.0f + 150 * p.GetID(), 90.0f)));
                Debug.AddText(new DebugText("Checkpoint: " + p.m_currentCheckpoint.GetID().ToString(), new Vector2(20.0f + 150 * p.GetID(), 110.0f)));
                Debug.AddText(new DebugText("Path: " + p.m_currentCheckpoint.GetPath().ToString(), new Vector2(20.0f + 150 * p.GetID(), 130.0f)));
            }


            // Get rankings
            m_rankings.Clear();
            while (m_rankings.Count != players_.Count) {
                int highestID = 0;
                int highestScore = 0;

                // Check for highest score (i.e. front-most non-ranked player)
                foreach(Player p in players_) {
                    int checkpointScore = p.m_currentLap * (m_checkpoints.Count - 1) + p.m_currentCheckpoint.GetID();
                    if (checkpointScore > highestScore) {
                        bool ranked = false;
                        foreach (int i in m_rankings) {
                            if (p.GetID() == i) {
                                ranked = true;
                            }
                        }

                        if (!ranked) {
                            highestScore = checkpointScore;
                            highestID = p.GetID();
                        }
                    }
                }
                // Add front-most player to rankings
                m_rankings.Add(highestID);
            }

            foreach (Barrier b in m_barriers) {
                b.UpdateCollider();
                b.UpdateSprites();
            }
        }

        public void Draw(ref GraphicsHandler graphicsHandler_) {
            // Draw the objects to the screen
            // ================

            // Render barriers
            foreach (Barrier b in m_barriers) {
                graphicsHandler_.DrawSprite(b.GetSprite());
            }

            // Add checkpoints to Debug screen
            foreach (CheckpointContainer cp in m_checkpoints) {
                Debug.AddSprite(cp.GetEntity().GetSprite());
            }

            // Render ranking text
            if (m_rankings.Count != 0) {
                Debug.AddText(new DebugText("1st - Player " + m_rankings[0].ToString(), new Vector2(1500f, 50f)));
                if (m_rankings.Count > 1) {
                    Debug.AddText(new DebugText("2nd - Player " + m_rankings[1].ToString(), new Vector2(1500f, 70f)));
                    if (m_rankings.Count > 2) {
                        Debug.AddText(new DebugText("3rd - Player" + m_rankings[2].ToString(), new Vector2(1500f, 90f)));
                        if (m_rankings.Count > 3) {
                            Debug.AddText(new DebugText("4th - Player" + m_rankings[3].ToString(), new Vector2(1500f, 110f)));
                        }
                    }  
                }
            }
        }

        // Getters


        // Setters


    }
}
