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
/// Barrier.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FarseerPhysics.Dynamics;

using Project_Cows.Source.System;

namespace Project_Cows.Source.Application.Entity{
    class Barrier : Entity {
        // Class for the track barriers
        // ================

        // Variables


        // Methods
        public Barrier(World world_, Texture2D texture_, EntityStruct entityStruct_)
            : base(world_, texture_, entityStruct_.GetPosition(), entityStruct_.GetRotationDegrees(), BodyType.Static) {
            // Barrier constructor
            // ================
        }

        // Getters


        // Setters
    }
}