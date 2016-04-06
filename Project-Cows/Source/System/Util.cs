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
/// Util.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Cows.Source.System {
    public static class Util{
        // Utility class to hold general functions
        // ================

        public static float DegreesToRadians(float degrees_) {
            return (degrees_ * (float)Math.PI / 180);
        }

        public static float RadiansToDegrees(float radians_) {
            return (radians_ * 180 / (float)Math.PI);
        }
    }
}
