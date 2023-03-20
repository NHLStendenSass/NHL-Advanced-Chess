using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame;
using System;

namespace Chessnt
{
    public class Button : Component
    {
        #region Fields

        private MouseState _currentMouse;
        private SpriteFont _font;
        private bool _isHovering;
        private MouseState _previousMouse;
        private Texture2D _texture;
        private float _scale;
        private Rectangle mouseRectangle;

        #endregion

        #region Properties
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }
        public string Text { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width * 3, _texture.Height * 3);
            }
        }
        #endregion

        #region Methods
        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
            PenColour = Color.White;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            HoveringEffect();
            DrawRectangleForButton(spriteBatch);
            DrawText(spriteBatch);
        }

        private void DrawRectangleForButton(SpriteBatch spriteBatch)
        {
            var colour = Color.Black * 0.0f;
            spriteBatch.Draw(_texture, Rectangle, colour);
        }

        private void DrawText(SpriteBatch spriteBatch)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                _scale = 1.010f;
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y) + new Vector2(1 * _scale, 1 * _scale), Color.Black, 0, Vector2.Zero, _scale, SpriteEffects.None, 1f);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y) + new Vector2(-1 * _scale, 1 * _scale), Color.Black, 0, Vector2.Zero, _scale, SpriteEffects.None, 1f);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y) + new Vector2(-1 * _scale, -1 * _scale), Color.Black, 0, Vector2.Zero, _scale, SpriteEffects.None, 1f);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y) + new Vector2(1 * _scale, -1 * _scale), Color.Black, 0, Vector2.Zero, _scale, SpriteEffects.None, 1f);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        private void HoveringEffect()
        {
            if (_isHovering)
            {
                PenColour = Color.Gray;
            }
            else
            {
                PenColour = Color.White;
            }
        }

        public override void Update(GameTime gameTime)
        {
            MouseInteractButton();
        }

        private void MouseInteractButton()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        internal object ContinuousRecognitionWithKeywordSpottingAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}