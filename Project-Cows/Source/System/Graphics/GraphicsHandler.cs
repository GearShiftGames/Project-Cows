using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project_Cows.Source.System.Graphics {
    
    public class GraphicsHandler {

        SpriteBatch m_spriteBatch;
        SpriteFont m_font;

        public GraphicsHandler(GraphicsDevice graphicsDevice_, ContentManager content_) {
            m_spriteBatch = new SpriteBatch(graphicsDevice_);
            m_font = content_.Load<SpriteFont>("basic_font");
        }

        public void StartDrawing() {
            m_spriteBatch.Begin();
        }

        public void StopDrawing() {
            m_spriteBatch.End();
        }

        // Draws a Sprite from all it's variables information
        public void DrawSprite(Sprite sprite_) {
            Rectangle scale = new Rectangle((int)sprite_.GetPosition().X,
                                            (int)sprite_.GetPosition().Y,
                                            (int)(sprite_.GetWidth() * sprite_.GetScale()),
                                            (int)(sprite_.GetHeight() * sprite_.GetScale()));
            m_spriteBatch.Draw(sprite_.GetTexture(), scale, null, Color.White, sprite_.GetRotationRadians(), sprite_.GetOrigin(), SpriteEffects.None, 0);
        }

        // Draws an animated sprite from all it's variables information
        public void DrawAnimatedSprite(AnimatedSprite animSprite_) {
            Rectangle destination = new Rectangle((int)animSprite_.GetPosition().X,
                                                  (int)animSprite_.GetPosition().Y,
                                                    animSprite_.GetFrameWidth(),
                                                    animSprite_.GetFrameHeight());
            Rectangle source = new Rectangle(animSprite_.GetFrameWidth() * animSprite_.GetCurrentHorizontal(),
                                             animSprite_.GetFrameHeight() * animSprite_.GetCurrentVertical(),
                                             animSprite_.GetFrameWidth(),
                                             animSprite_.GetFrameHeight());
            m_spriteBatch.Draw(animSprite_.GetTexture(), destination, source, Color.White);
        }

        // Uses only the standard font
        public void DrawText(string text_, Vector2 position_, Color colour_) {
            m_spriteBatch.DrawString(m_font, text_, position_, colour_);
        }

        // For use with different fonts
        public void DrawText(string text_, Vector2 position_, Color colour_, SpriteFont font_) {
            m_spriteBatch.DrawString(m_font, text_, position_, colour_);
        }

    }
}
