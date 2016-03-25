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
/// CheckpointContainer.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.Application.Entity;

namespace Project_Cows.Source.Application.Track {
    public class CheckpointContainer {
        // Class to hold the checkpoint 'struct' and the entity
        // ================

        // Variables
        private Checkpoint m_checkpoint;
        private Entity.Entity m_entity;

        // Methods
        public CheckpointContainer(Checkpoint checkpoint_) {
            // CheckpointContainer constructor
            // ================

            m_checkpoint = checkpoint_;
        }

        public CheckpointContainer(Checkpoint checkpoint_, Entity.Entity entity_) {
            // CheckpointContainer constructor
            // ================

            m_checkpoint = checkpoint_;
            m_entity = entity_;
        }


        // Getters
        public Checkpoint GetCheckpoint() {
            return m_checkpoint;
        }

        public Entity.Entity GetEntity() {
            return m_entity;
        }

        // Setters
        public void SetCheckpoint(int id_, int nextID_, int pathID_, Vector2 position_, float rotation_) {
            m_checkpoint = new Checkpoint(id_, nextID_, pathID_, position_, rotation_);
        }

        public void SetEntity(Texture2D texture_, float rotation_=0) {
            m_entity = new Entity.Entity(texture_, m_checkpoint.GetPosition(), rotation_);
        }
    }
}
