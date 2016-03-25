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
/// Timer.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Cows.Source.System {
    class Timer {
        // Class for used timed operations
        // ================

        // Variables
        public float timeRemaining { get; private set; }
        public float delay { get; private set; }
        public bool timerFinished { get; private set; }
        public bool timerPaused { get; private set; }

        // Methods
        public Timer() {
            // Timer constructor
            // ================

            timerFinished = false;
        }

        public void StartTimer(float delay_) {
            // Starts the timer with a set delay
            // ================

            delay = delay_;
            timeRemaining = delay_;
        }

        public void StopTimer() {
            // Stops the timer and removes the remaining time
            timeRemaining = 0;
        }

        public void PauseTimer() {
            // Pauses the timer's progress
            // ================

            timerPaused = true;
        }

        public void ResumeTimer() {
            // Resumes the timer's progress
            // ================

            timerPaused = false;
        }

        public void Update(float deltaTime) {
            if (!timerPaused) {
                timeRemaining -= deltaTime;

                if (timeRemaining <= 0) {
                    timerFinished = true;
                } else {
                    timerFinished = false;
                }
            }
        }

        // Getters


        // Setters
    }
}
