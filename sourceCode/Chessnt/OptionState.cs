using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    public class OptionState : State
    {
        private VoiceCommand voiceCommand;
        private List<Component> _components;
        private Texture2D backgroundTexture;
        private Texture2D buttonTexture;
        private SpriteFont buttonFont;
        private Button saveButton;
        private Button voiceButton;

        public OptionState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            backgroundTexture = _content.Load<Texture2D>("option_background");
            buttonTexture = _content.Load<Texture2D>("Button");
            buttonFont = _content.Load<SpriteFont>("Font");
            voiceCommand = new VoiceCommand(game, graphicsDevice, content);

            saveButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(725, 875),
                Text = "Save",
            };
            saveButton.Click += SaveButton_Click;

            voiceButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(700, 320),
                Text = "Talk",
            };
            voiceButton.Click += VoiceButton_Click;

            _components = new List<Component>()
            {
                saveButton,
                voiceButton,
            };
        }

        private void VoiceButton_Click(object sender, EventArgs e)
        {
            voiceCommand.RecognitionWithMicrophoneAsync().Wait();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);

            DrawOptionTexts("Option", 650, 50, 1.015f, spriteBatch);
            DrawOptionTexts("Voice:", 150, 250, 1.015f, spriteBatch);
            DrawOptionTexts("Dice:", 150, 450, 1.015f, spriteBatch);
            DrawOptionTexts("Bruh:", 150, 650, 1.015f, spriteBatch);

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

        private void DrawOptionTexts(string text, int textX, int textY, float textScale, SpriteBatch spriteBatch)
        {
            DrawTextShadow(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(buttonFont, text, new Vector2(textX, textY), Color.White);
        }
        
        private void DrawTextShadow(String text, int x, int y, float scale, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(1 * scale, 1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(-1 * scale, 1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(-1 * scale, -1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, text, new Vector2(x, y) + new Vector2(1 * scale, -1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
        }
    }
}