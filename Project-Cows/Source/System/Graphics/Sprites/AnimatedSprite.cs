/* Project Cows -- GearShift Games
 * Written by N. Headley 2015
 * ================
 * Animated Sprite Class
 */

/* Change Log
 * 
 * 25/11/15 - Works with different animations in one sprite sheet
 *              - startAnimation(line number) will decide which animation to play
 *  
 * 15/01/16 - Changed all variable and method names to be inline with naming conventions
 * 
 */

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Cows.Source.System.Graphics.Sprites {

    public class AnimatedSprite : Sprite {

        // Variables
        int m_frameWidth,         // Width of each frame in pixels
            m_frameHeight,        // Height of each frame in pixels
            m_horizontalFrames,   // Number of frames in each row
            m_verticalFrames,     // Number of rows or vertical frames
            m_currentHorizontal,  // Current horizontal frame
            m_currentVertical,    // Current vertical frame (current animation)
            m_currentState;       // Current state of sprite (0 = still, 1 = animating)
        double m_frameTime,       // Interval between each frame in milliseconds (1000ms = 1s)
                m_lastTime;       // The time that the last animation occurred

        // Initializer
        public AnimatedSprite(Texture2D spriteSheet_, Vector2 position_, int width_, int height_, double time_, float scale_ = 1) {
            SetTexture(spriteSheet_);
            SetPosition(position_);
            m_frameWidth = width_;
            m_frameHeight = height_;
            m_horizontalFrames = GetTexture().Width / m_frameWidth;
            m_verticalFrames = GetTexture().Height / m_frameHeight;
            m_frameTime = time_;
            m_currentState = 1;
        }

        // Method to change which frame is displaying
        public void ChangeFrame(double time_) {
            if (m_currentHorizontal < m_horizontalFrames - 1) {
                m_currentHorizontal++;
            } else {
                m_currentHorizontal = 0;
            }
            m_lastTime = time_;
        }

        // Method to start animating, takes in which animation to start
        public void StartAnimation(int animation_) {
            m_currentVertical = animation_;
            m_currentState = 1;
        }

        // Method to stop animating
        public void StopAnimation() {
            m_currentVertical = 0;
            m_currentState = 0;
        }

        // Getters
        // NOTE: No need for setters at the moment, set in the initializer
        public int GetFrameWidth() {
            return m_frameWidth;
        }
        public int GetFrameHeight() {
            return m_frameHeight;
        }
        public int GetCurrentHorizontal() {
            return m_currentHorizontal;
        }
        public int GetCurrentVertical() {
            return m_currentVertical;
        }
        public int GetCurrentState() {
            return m_currentState;
        }
        public double GetFrameTime() {
            return m_frameTime;
        }
        public double GetLastTime() {
            return m_lastTime;
        }

    }

}
