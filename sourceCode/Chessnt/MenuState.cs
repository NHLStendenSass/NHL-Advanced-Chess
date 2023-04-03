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
using Windows.ApplicationModel.VoiceCommands;

namespace Chessnt
{
    public class MenuState : State
    {
        private List<Component> _components;

        private Texture2D backgroundTexture;
        private Texture2D buttonTexture;

        private SpriteFont buttonFont;

        private Button playButton;
        private Button optionButton;
        private Button exitButton;
        private Button voiceButton;

        private VoiceCommand voiceCommand;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            backgroundTexture = _content.Load<Texture2D>("menu_background");
            buttonTexture = _content.Load<Texture2D>("Button");
            buttonFont = _content.Load<SpriteFont>("Font");
            voiceCommand = new VoiceCommand(game, graphicsDevice, content);

            playButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(150, 400),
                Text = "Play",
            };

            playButton.Click += PlayButton_Click;

            optionButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(270, 550),
                Text = "Option",
            };

            optionButton.Click += OptionButton_Click;

            exitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(135, 700),
                Text = "Exit",
            };

            exitButton.Click += QuitGameButton_Click;

            voiceButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1400, 170),
                Text = "Talk",
            };
            voiceButton.Click += VoiceButton_Click;

            _components = new List<Component>()
                  {
                    playButton,
                    optionButton,
                    exitButton,
                    voiceButton
                  };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            DrawMenuBackground(spriteBatch);
            DrawMenuTexts("Chessn't", 180, 140, 1.015f, spriteBatch);
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

        private void DrawMenuTexts(string text, int textX, int textY, float textScale, SpriteBatch spriteBatch)
        {
            DrawTextShadow(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(buttonFont, text, new Vector2(textX, textY), Color.White);
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new OptionState(_game, _graphicsDevice, _content));
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void VoiceButton_Click(object sender, EventArgs e)
        {
            voiceCommand.RecognitionWithMicrophoneAsync().Wait();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }   
    }
}
