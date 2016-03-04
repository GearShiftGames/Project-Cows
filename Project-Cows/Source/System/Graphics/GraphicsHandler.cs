// Project: Cow Racing -- GearShift Games
// Written by N. Headley, 2016
// ================
// GraphicsHandler.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Project_Cows.Source.System.Graphics.Particles;
using Project_Cows.Source.System.Graphics.Sprites;
using Project_Cows.Source.System.StateMachine;

namespace Project_Cows.Source.System.Graphics {
    public class GraphicsHandler {
        // Graphics Handler class, renders sprites, text and particles.
        // ================

        // Variables
        private ParticleHandler m_particleHandler;
        private SpriteBatch m_spriteBatch;
        private SpriteFont m_font;

        // Methods
        public GraphicsHandler(GraphicsDevice graphicsDevice_, ContentManager content_) {
            // GraphicsHandler constructor
            // ================
            m_particleHandler = new ParticleHandler();
            m_spriteBatch = new SpriteBatch(graphicsDevice_);
            m_font = content_.Load<SpriteFont>("Fonts\\basic_font");
        }

        public void StartDrawing() {
            // Enable drawing
            // ================
            m_spriteBatch.Begin();
        }

        public void StopDrawing() {
            // Disable drawing
            // ================
            m_spriteBatch.End();
        }

        public void DrawSprite(Sprite sprite_) {
            // Draw a sprite from its' variables data
            // ================
            Rectangle scale = new Rectangle((int)sprite_.GetPosition().X,
                                            (int)sprite_.GetPosition().Y,
                                            (int)(sprite_.GetWidth() * sprite_.GetScale().X),
                                            (int)(sprite_.GetHeight() * sprite_.GetScale().Y));
            m_spriteBatch.Draw(sprite_.GetTexture(), scale, null, Color.White, sprite_.GetRotationRadians(), sprite_.GetOrigin(), SpriteEffects.None, 0);
        }

        public void DrawAnimatedSprite(AnimatedSprite animSprite_) {
            // Draw an animated sprite from its' variables data
            // ================
            Rectangle destination = new Rectangle((int)animSprite_.GetPosition().X,
                                                  (int)animSprite_.GetPosition().Y,
                                                  (int)(animSprite_.GetFrameWidth() * animSprite_.GetScale().X),
                                                  (int)(animSprite_.GetFrameHeight() * animSprite_.GetScale().Y));
            Rectangle source = new Rectangle(animSprite_.GetFrameWidth() * animSprite_.GetCurrentHorizontal(),
                                             animSprite_.GetFrameHeight() * animSprite_.GetCurrentVertical(),
                                             animSprite_.GetFrameWidth(),
                                             animSprite_.GetFrameHeight());
            // FIXME: Origin doesn't work> - Nathan
            m_spriteBatch.Draw(animSprite_.GetTexture(), destination, source, Color.White, animSprite_.GetRotationRadians(), animSprite_.GetOrigin(), SpriteEffects.None, 0);
        }

        public void DrawText(string text_, Vector2 position_, Color colour_) {
            // Draw text with standard font
            // ================
            m_spriteBatch.DrawString(m_font, text_, position_, colour_);
        }

		public void DrawText(DebugText text_) {
			// Draw text with standard font, using DebugText
			// ================
			m_spriteBatch.DrawString(m_font, text_.GetText(), text_.GetPosition(), text_.GetColor());
		}

        public void DrawText(string text_, Vector2 position_, Color colour_, SpriteFont font_) {
            // Draw text with custom font
            // ================
            m_spriteBatch.DrawString(m_font, text_, position_, colour_);
        }

        public List<Particle> UpdatePFX(double time_) {
            // Update particle effects
            // ================
            m_particleHandler.Update(time_);
            return m_particleHandler.GetParticles();
        }

        public void DrawParticle(Texture2D texture_, Vector2 position_, Color colour_) {
            // Draw a particle
            // ================
            m_spriteBatch.Draw(texture_, position_, colour_);
        }
    }
}
