// Project Cows -- GearShift Games
// Written by D. Divers, 2016
// ================

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Project_Cows.Source.System;

namespace Project_Cows.Source.Application.Entity
{
    class Barrier
    {
        public Entity m_entity;

        public Barrier(ContentManager content_, Texture2D texture_, Vector2 position_, float m_rotation_ = 0)
        {

            m_entity = new Entity(content_, texture_, position_, m_rotation_);
            m_entity.GetSprite().SetScale(new Vector2(0.4f, 0.4f));

        }
    }
}