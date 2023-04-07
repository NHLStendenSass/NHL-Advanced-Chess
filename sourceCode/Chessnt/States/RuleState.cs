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
using System.Diagnostics;

namespace Chessnt
{
    public class RuleState : State
    {
        private List<Component> _components;
        private Texture2D _backgroundTexture;
        private Texture2D _buttonTexture;
        private SpriteFont _buttonFont;
        private Button _saveButton;
        private Button _urlButton;
        private TextOutline _textOutline;
        private String _url;
        Texture2D _pixelTexture;

        public RuleState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            _url = "https://github.com/NHLStendenSass/NHL-Advanced-Chess/blob/main/README.md";
            _backgroundTexture = base.content.Load<Texture2D>("option_background");
            _buttonTexture = base.content.Load<Texture2D>("Button");
            _buttonFont = base.content.Load<SpriteFont>("Font");
            _textOutline = new TextOutline(_buttonFont);

            _saveButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(725, 875),
                Text = "Go back!",
            };
            _saveButton.Click += SaveButton_Click;
            _urlButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(725, 690),
                Text = "Open rules!",
            };
            _urlButton.Click += new EventHandler(UrlButton_Click);
            _components = new List<Component>()
            {
                _saveButton,
                _urlButton
            };

            _pixelTexture = new Texture2D(graphicsDevice, 1, 1);
            _pixelTexture.SetData(new Color[] { Color.White });
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

            DrawContent("Chess is a two-player strategy game played\n" +
                "on a square boardwith 64 squares alternately colored\n" +
                "light and dark. Each player has one king, one queen,\n" +
                "two rooks, two knights, two bishops, and eight pawns\n" +
                "to use in the game. There are countless possible moves\n" +
                "and moves combinations.", 190, 300, 0.3f, spriteBatch);



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


            //_textOutline.DrawTextOutLine(text, textX, textY, textScale, spriteBatch);
            //spriteBatch.DrawString(_buttonFont, text, new Vector2(textX, textY), Color.White, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0f);
            Vector2 textSize = _buttonFont.MeasureString(text) * textScale;
            Rectangle rect = new Rectangle(textX, textY, (int)textSize.X + 25, (int)textSize.Y + 25);

            // Draw black box behind text
            spriteBatch.Draw(_pixelTexture, rect, Color.Black);

            // Draw text on top of black box
            _textOutline.DrawTextOutLine(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(textX + 5, textY + 5), Color.White, 0f, Vector2.Zero, textScale, SpriteEffects.None, 0f);
        }

        private void DrawOptionTexts(string text, int textX, int textY, float textScale, SpriteBatch spriteBatch)
        {
            _textOutline.DrawTextOutLine(text, textX, textY, textScale, spriteBatch);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(textX, textY), Color.White);
        }

        private void UrlButton_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {_url}") { CreateNoWindow = true });
        }
    }
}