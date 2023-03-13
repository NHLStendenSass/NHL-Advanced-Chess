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

        private Texture2D backgroundTexture;
        private Texture2D buttonTexture;
        private SpriteFont buttonFont;

        private Button playButton;
        private Button optionButton;
        private Button exitButton;

        public LoadingState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            backgroundTexture = _content.Load<Texture2D>("loading_background");
            buttonTexture = _content.Load<Texture2D>("Button");
            buttonFont = _content.Load<SpriteFont>("Font");
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
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
        }

        private void DrawTextShadow(String text, int x, int y, float scale, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(1 * scale, 1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(-1 * scale, 1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(-1 * scale, -1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(1 * scale, -1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
        }

        private void DrawLoadingTexts(string text, int textX, int textY, float textScale, SpriteBatch spriteBatch)
        {
            DrawTextShadow(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(buttonFont, text, new Vector2(textX, textY), Color.White);
        }
        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            Task.Delay(3000).ContinueWith(t => _game.ChangeState(new MenuState(_game, _graphicsDevice, _content)));
        }
    }
}
