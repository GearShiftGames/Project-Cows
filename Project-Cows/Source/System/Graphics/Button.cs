using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Project_Cows.Source.System.Graphics.Sprites;

namespace Project_Cows.Source.System.Graphics {
    public class Button {

        // Variables
        private Vector2 m_position;
        private Sprite m_pressed, m_notPressed;
        private int m_actionNumber = 0;
        private int m_state = 0;

        // Methods
        public Button(Vector2 _position, Sprite _pressed, Sprite _notPressed, int _actionNumber) {
            m_position = _position;
            m_pressed = _pressed;
            m_notPressed = _notPressed;
            m_actionNumber = _actionNumber;
        }

    }
}
