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

        private Texture2D _backgroundTexture;
        private Texture2D _buttonTexture;
        private SpriteFont _buttonFont;

        private Button _playButton;
        private Button _optionButton;
        private Button _exitButton;
        private Button _voiceButton;

        private VoiceCommand _voiceCommand;

        private Utilities.TextOutline _textOutline;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            _backgroundTexture = base.content.Load<Texture2D>("menu_background");
            _buttonTexture = base.content.Load<Texture2D>("Button");
            _buttonFont = base.content.Load<SpriteFont>("Font");
            _textOutline = new Utilities.TextOutline(_buttonFont);
            _voiceCommand = new VoiceCommand(game, graphicsDevice, content);

            _playButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(150, 400),
                Text = "Play",
            };

            _playButton.Click += PlayButton_Click;

            _optionButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(160, 550),
                Text = "Rule",
            };

            _optionButton.Click += OptionButton_Click;

            _exitButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(135, 700),
                Text = "Exit",
            };

            _exitButton.Click += QuitGameButton_Click;

            _voiceButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(1400, 170),
                Text = "Talk",
            };
            _voiceButton.Click += VoiceButton_Click;

            _voiceButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(1400, 170),
                Text = "Talk",
            };
            _voiceButton.Click += VoiceButton_Click;

            _components = new List<Component>()
                  {
                    _playButton,
                    _optionButton,
                    _exitButton,
                    _voiceButton
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
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
        }

        private void DrawMenuTexts(string text, int textX, int textY, float textScale, SpriteBatch spriteBatch)
        {
            _textOutline.DrawTextOutLine(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(textX, textY), Color.White);
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new RuleState(game, graphicsDevice, content));
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new GameState(game, graphicsDevice, content));
        }

        private void VoiceButton_Click(object sender, EventArgs e)
        {
            _voiceCommand.RecognitionWithMicrophoneAsync().Wait();
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
            game.Exit();
        }
    }
}
