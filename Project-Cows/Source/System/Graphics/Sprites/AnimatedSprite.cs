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
/// AnimatedSprite.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Cows.Source.System.Graphics.Sprites {
    public class AnimatedSprite : Sprite {
        // AnimatedSprite class, holds data for/manages animated sprites.
        // ================

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

        // Methods
        public AnimatedSprite(Texture2D spriteSheet_, Vector2 position_, int width_, int height_, double time_, bool visible_ = true, float rotation_ = 0, float scale_ = 1) {
            // AnimatedSprite constructor
            // ================
            SetTexture(spriteSheet_);
            SetPosition(position_);
            SetRotationDegrees(rotation_);
            SetScale(scale_);
            SetVisible(visible_);
            SetOrigin(new Vector2(position_.X + (m_frameWidth / 2), position_.Y + (m_frameHeight / 2)));
            m_frameWidth = width_;
            m_frameHeight = height_;
            m_horizontalFrames = GetTexture().Width / m_frameWidth;
            m_verticalFrames = GetTexture().Height / m_frameHeight;
            m_frameTime = time_;
            m_currentState = 1;
        }

        public void ChangeFrame(double time_) {
            // Change the frame that is rendering
            // ================
            if (m_currentHorizontal < m_horizontalFrames - 1) {
                m_currentHorizontal++;
            } else {
                m_currentHorizontal = 0;
            }
            m_lastTime = time_;
        }

        public void StartAnimation(int animation_) {
            // Start animating a specific animation
            // ================
            m_currentVertical = animation_;
            m_currentState = 1;
        }

        public void StopAnimation() {
            // Stop animating
            // ================
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
