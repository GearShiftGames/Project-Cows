using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using Project_Cows.Source.System.Graphics;

namespace Project_Cows.Source.System
{
    public static class AudioHandler
    {

        // Variables
        public static SoundEffect effect;// ADDED
        public static SoundEffect cargo;// ADDED
        public static SoundEffect brake;// ADDED

        // Methods
        public static void LoadContent()
        {
            effect = GraphicsHandler.m_content.Load<SoundEffect>("Audio\\CowMoo2"); //ADDED
            cargo = GraphicsHandler.m_content.Load<SoundEffect>("Audio\\Driving"); //ADDED
            brake = GraphicsHandler.m_content.Load<SoundEffect>("Audio\\Brake");//ADDED
        }
    }
}
