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
/// ParticleHandler.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Project_Cows.Source.System.Graphics.Particles {
    public class ParticleHandler {
        // Particle Handler class, holds data on particles and maintains it.
        // ================

        // Variables
        List<Particle> m_particles;
        //List<Particle> m_skidMarks;

        // Methods
        public ParticleHandler() {
            // ParticleHandler constructor
            // ================
            m_particles = new List<Particle>();
        }

        public void StartSkidMarks(int x_, int y_) {
            m_particles.Add(new Particle(new Vector2(x_, y_), 2000, 0, 0, Color.Black));
        }

        public void StartFireTrail(int x_, int y_) {
            // Start a dirt trail of particles
            // ================
            Random rnd = new Random();
            for (int i = 0; i < 12; i++) {
                // Vector Position(x,y), double life, int angle, float velocity
                //m_particles.Add(new Particle(new Vector2(500.0f, rnd.Next(500, 525)), rnd.Next(1000, 2500), rnd.Next(160, 200), rnd.Next(10, 100)));
                m_particles.Add(new Particle(new Vector2(x_, rnd.Next(y_ - 3, y_ + 3)), rnd.Next(50, 100), rnd.Next(170, 190), rnd.Next(10, 100), Color.Red));
            }
        }

        public void StartDriveTrail(int x_, int y_) {
            // Start a dirt trail of particles
            // ================
            Random rnd = new Random();
            for (int i = 0; i < 4; i++) {
                // Vector Position(x,y), double life, int angle, float velocity
                //m_particles.Add(new Particle(new Vector2(500.0f, rnd.Next(500, 525)), rnd.Next(1000, 2500), rnd.Next(160, 200), rnd.Next(10, 100)));
                m_particles.Add(new Particle(new Vector2(x_, rnd.Next(y_ - 3, y_ + 3)), rnd.Next(50, 100), rnd.Next(170, 190), rnd.Next(10, 100), Color.Gray));
            }
        }

        public void StartBrakeTrail(int x_, int y_) {
            // Start a dirt trail of particles
            // ================
            Random rnd = new Random();
            for (int i = 0; i < 8; i++) {
                // Vector Position(x,y), double life, int angle, float velocity
                //m_particles.Add(new Particle(new Vector2(500.0f, rnd.Next(500, 525)), rnd.Next(1000, 2500), rnd.Next(160, 200), rnd.Next(10, 100)));
                m_particles.Add(new Particle(new Vector2(x_, rnd.Next(y_ - 3, y_ + 3)), rnd.Next(50, 150), rnd.Next(160, 200), rnd.Next(10, 100), Color.Gray));
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
