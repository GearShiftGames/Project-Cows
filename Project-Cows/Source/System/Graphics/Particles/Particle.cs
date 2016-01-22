/* Project Cows -- GearShift Games
 * Written by N. Headley 2015
 * ================
 * Particle.cs

/* Change Log
 * 
 * 15/01/16 - Changed all variable and method names to be inline with naming conventions
 * 
 */

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Cows.Source.System.Graphics.Particles {

    public class Particle {

        // Variables
        Vector2 m_position,
                m_velocity;
        double m_life;

        // Initialiser
        public Particle(Vector2 position_, double life_, int angle_, float speed_) {
            m_position = position_;
            m_life = life_;
            double radians = angle_ * Math.PI / 180;
            m_velocity.X = (float)(speed_ * Math.Cos(radians));
            m_velocity.Y = (float)(speed_ * Math.Sin(radians));
        }

        // Getters
        public Vector2 GetPosition() {
            return m_position;
        }
        public double GetLife() {
            return m_life;
        }

        // Setters
        public void update(double time_) {
            if ((m_life - time_) > 0) {
                m_life -= time_;
            } else {
                m_life = 0;
            }
            m_position.X += (float)(m_velocity.X * (time_ / 1000));
            m_position.Y += (float)(m_velocity.Y * (time_ / 1000));
        }

    }

}
