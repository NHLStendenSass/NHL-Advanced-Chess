using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Chessnt
{
    public class LoadingState : State
    {
        private List<Component> _components;

        private Texture2D _backgroundTexture;
        private Texture2D _buttonTexture;
        private SpriteFont _buttonFont;

        private Button _playButton;
        private Button _optionButton;
        private Button _exitButton;

        private TextOutline _textOutline;

        public LoadingState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            _backgroundTexture = base.content.Load<Texture2D>("loading_background");
            _buttonTexture = base.content.Load<Texture2D>("Button");
            _buttonFont = base.content.Load<SpriteFont>("Font");
            _textOutline = new TextOutline(_buttonFont);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            DrawMenuBackground(spriteBatch);
            DrawLoadingTexts("Chessn't", 600, 140, 1.01f, spriteBatch);

            spriteBatch.End();
        }

        private void DrawMenuBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
        }

        private void DrawLoadingTexts(string text, float textX, float textY, float textScale, SpriteBatch spriteBatch)
        {
            _textOutline.DrawTextOutLine(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(textX, textY), Color.White);
        }
        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            //TODO: Change to menu state after merge
            Task.Delay(1000).ContinueWith(t => game.ChangeState(new MenuState(game, graphicsDevice, content)));
        }
    }
}
