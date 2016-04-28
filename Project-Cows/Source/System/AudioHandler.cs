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
		public static Song menuMusic;
		public static Song raceMusic;

        public static SoundEffect vehicleEngine;
        public static SoundEffect vehicleBrake;
		public static SoundEffect countdownBeeps;
		public static SoundEffect fanfareCheer;
		public static SoundEffect cheer;

        // Methods
        public static void LoadContent() {
			menuMusic = GraphicsHandler.m_content.Load<Song>("Audio/Music/menuMusic");
			raceMusic = GraphicsHandler.m_content.Load<Song>("Audio/Music/raceMusic");

            vehicleEngine = GraphicsHandler.m_content.Load<SoundEffect>("Audio/SFX/Vehicles/vehicleEngine");
            vehicleBrake = GraphicsHandler.m_content.Load<SoundEffect>("Audio/SFX/Vehicles/vehicleBrake");
			countdownBeeps = GraphicsHandler.m_content.Load<SoundEffect>("Audio/SFX/Miscellaneous/countdownBeeps");
			fanfareCheer = GraphicsHandler.m_content.Load<SoundEffect>("Audio/SFX/Miscellaneous/fanfareCheer");
			cheer = GraphicsHandler.m_content.Load<SoundEffect>("Audio/SFX/Miscellaneous/cheer");
        }
    }
}
