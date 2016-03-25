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

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System;

namespace Project_Cows.Source.Application.Entity{
    class Barrier : Entity{
        // Class for the track barriers
        // ================

        // Variables


        // Methods
        public Barrier(Texture2D texture_, Vector2 position_, float rotation_ = 0) : base(texture_, position_, rotation_) {
            // Barrier constructor
            // ================
            //GetSprite().SetScale(new Vector2(0.4f, 0.4f));      // TEMP: Will be replaced in future by correctly sized assets -Dean
        }

        public Barrier(Texture2D texture_, EntityStruct entityStruct_) : base(texture_, entityStruct_) {
            // Barrier constructor
            // ================
            //GetSprite().SetScale(new Vector2(0.4f, 0.4f));      // TEMP: Will be replaced in future by correctly sized assets -Dean
        }

        // Getters


        // Setters
    }
}