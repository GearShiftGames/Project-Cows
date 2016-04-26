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
        public static Song menu; // ADDED
        public static Song game; // ADDED
        public static SoundEffect countdown; // ADDED

        // Methods
        public static void LoadContent()
        {
            //effect = GraphicsHandler.m_content.Load<SoundEffect>("Audio\\CowMoo2"); //ADDED
            cargo = GraphicsHandler.m_content.Load<SoundEffect>("Audio\\Car_Engine_Loop"); //ADDED
            brake = GraphicsHandler.m_content.Load<SoundEffect>("Audio\\Car_Brake_Loop");//ADDED
            menu = GraphicsHandler.m_content.Load<Song>("Audio\\Menu-Background_Music"); //ADDED
            game = GraphicsHandler.m_content.Load<Song>("Audio\\Game_Music"); // ADDED  
            countdown = GraphicsHandler.m_content.Load<SoundEffect>("Audio\\Countdown_Sound"); // ADDED
        }
    }
}
