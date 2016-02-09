// Project Cows -- GearShift Games
// Written by N. Headley 2015
// ================
// ParticleFX.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Cows.Source.System.Graphics.Particles {
    public class ParticleHandler {
        // Particle Handler class, holds data on particles and maintains it.
        // ================

        // Variables
        List<Particle> m_particles;

        // Methods
        public ParticleHandler() {
            // ParticleHandler constructor
            // ================
            m_particles = new List<Particle>();
        }

        public void StartDirtTrail(float x_, float y_) {
            // Start a dirt trail of particles
            // ================
            Random rnd = new Random();
            for (int i = 0; i < 50; i++) {
                // Vector Position(x,y), double life, int angle, float velocity
                m_particles.Add(new Particle(new Vector2(500.0f, rnd.Next(500, 525)), rnd.Next(1000, 2500), rnd.Next(160, 200), rnd.Next(10, 100)));
            }
        }

        public void Update(double time_) {
            // Update all particles
            // ================
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
