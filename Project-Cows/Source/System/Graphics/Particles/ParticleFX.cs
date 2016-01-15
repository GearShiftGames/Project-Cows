/* Project Cows -- GearShift Games
 * Written by N. Headley 2015
 * ================
 * Particle Effects Class
 */

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

    public class ParticleFX {

        // Variables
        List<Particle> m_particles;

        // Initialiser
        public ParticleFX() {
            m_particles = new List<Particle>();
        }

        // Method to start a dirt trail of particles
        public void StartDirtTrail(float x_, float y_) {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++) {
                // Vector Position(x,y), double life, int angle, float velocity
                m_particles.Add(new Particle(new Vector2(500.0f, rnd.Next(500, 525)), rnd.Next(1000, 2500), rnd.Next(160, 200), rnd.Next(10, 100)));
            }
        }

        // Method to update all particles
        public void Update(double time_) {
            for (int i = 0; i < m_particles.Count; i++) {
                if (m_particles[i].GetLife() > 0) {
                    m_particles[i].update(time_);
                } else {
                    m_particles.RemoveAt(i);
                }
            }
        }

        // Getters
        public List<Particle> GetParticles() {
            return m_particles;
        }

    }

}
