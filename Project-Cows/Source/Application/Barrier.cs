// Project: Cow Racing -- GearShift Games
// Written by D. Divers, 2016
//            D. Sinclair, 2016
// ================
// Barrier.cs

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
        public Barrier(ContentManager content_, Texture2D texture_, Vector2 position_, float rotation_ = 0) : base(content_, texture_, position_, rotation_) {
            // Barrier constructor
            // ================
            //GetSprite().SetScale(new Vector2(0.4f, 0.4f));      // TEMP: Will be replaced in future by correctly sized assets -Dean
        }

        public Barrier(ContentManager content_, Texture2D texture_, EntityStruct entityStruct_)
            : base(content_, texture_, entityStruct_) {
            // Barrier constructor
            // ================
            //GetSprite().SetScale(new Vector2(0.4f, 0.4f));      // TEMP: Will be replaced in future by correctly sized assets -Dean
        }

        // Getters


        // Setters
    }
}