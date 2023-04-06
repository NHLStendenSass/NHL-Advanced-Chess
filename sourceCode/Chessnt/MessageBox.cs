using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    public class MessageBox
    {
        private Texture2D _texture;
        private SpriteFont _font;
        private Texture2D _okButtonTexture;
        private Rectangle _rect;
        private string _message = "Chessnt";
        private Vector2 _textPos;
        private Rectangle _okButtonRect;
        private bool _okButtonHovered = false;
        private bool _okButtonClicked = false;
        private bool _showMessageBox = false;



        public bool OkButtonClicked
        {
            get { return _okButtonClicked; }
        }

        public bool ShowMessageBox { get => _showMessageBox; set => _showMessageBox = value; }
        public string Message { get => _message; set => _message = value; }

        public MessageBox(Texture2D texture, SpriteFont font, Texture2D okButtonTexture)
        {
            _texture = texture;
            _font = font;
            _okButtonTexture = okButtonTexture;
            _rect = new Rectangle(Globals.WindowSize.X/3, Globals.WindowSize.Y / 3, Globals.WindowSize.X / 3, Globals.WindowSize.Y / 3);
            _textPos = new Vector2(
                _rect.X + 20,
                _rect.Y + 100);
            _okButtonRect = new Rectangle(
                _rect.X + _rect.Width/3,
                _rect.Y + _rect.Height-100,
                _rect.Width / 3,
                _rect.Height / 5);
        }

        public void Update()
        {
            _okButtonClicked = false;
            // Check if the user hovers over the OK button
            Point mousePos = Mouse.GetState().Position;
            _okButtonHovered = _okButtonRect.Contains(mousePos);

            // Check if the user clicks the OK button
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && _okButtonHovered)
            {
                _okButtonClicked = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, string text)
        {
            // Draw message box
            spriteBatch.Draw(_texture, _rect, Color.White);
            spriteBatch.DrawString(_font, text, _textPos, Color.Black);

            // Draw OK button
            Color okButtonColor = _okButtonHovered ? Color.LightGray : Color.White;
            spriteBatch.Draw(_okButtonTexture, _okButtonRect, okButtonColor);
        }
    }
}
