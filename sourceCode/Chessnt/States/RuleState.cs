using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessnt.Utilities;
using static System.Formats.Asn1.AsnWriter;

namespace Chessnt
{
    public class RuleState : State
    {
        private List<Component> _components;
        private Texture2D _backgroundTexture;
        private Texture2D _buttonTexture;
        private SpriteFont _buttonFont;
        private Button _saveButton;
        private TextOutline _textOutline;

        public RuleState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            _backgroundTexture = base.content.Load<Texture2D>("option_background");
            _buttonTexture = base.content.Load<Texture2D>("Button");
            _buttonFont = base.content.Load<SpriteFont>("Font");
            _textOutline = new TextOutline(_buttonFont);

            _saveButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(725, 875),
                Text = "Save",
            };
            _saveButton.Click += SaveButton_Click;
            _components = new List<Component>()
            {
                _saveButton,
            };

            Text text = new Text("Hello World!", 100, 100, 1.0f, 20, Color.White);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game, graphicsDevice, content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);

            DrawOptionTexts("Rules", 650, 50, 1.015f, spriteBatch);
            //DrawOptionTexts("Voice:", 150, 250, 0.9f, spriteBatch);
            //DrawOptionTexts("Dice:", 150, 450, 1.015f, spriteBatch);
            //DrawOptionTexts("Bruh:", 150, 650, 1.015f, spriteBatch);
            DrawContent("Hello World!", 650, 300, 0.5f, spriteBatch);


            DrawComponents(gameTime, spriteBatch);

            spriteBatch.End();
        }

        private void DrawComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        private void DrawContent(string text, int textX, int textY, float textScale, SpriteBatch spriteBatch)
        {
            _textOutline.DrawTextOutLine(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(textX, textY), Color.White, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0f);

        }

        private void DrawOptionTexts(string text, int textX, int textY, float textScale, SpriteBatch spriteBatch)
        {
            _textOutline.DrawTextOutLine(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(textX, textY), Color.White);
        }
    }
}