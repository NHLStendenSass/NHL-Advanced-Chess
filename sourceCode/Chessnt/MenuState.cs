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
    public class MenuState : State
    {
        private List<Component> _components;

        private Texture2D backgroundTexture;
        private Texture2D buttonTexture;
        private SpriteFont buttonFont;

        private Button playButton;
        private Button optionButton;
        private Button exitButton;

        private float titleScale;


        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            backgroundTexture = _content.Load<Texture2D>("Background_Menu");
            buttonTexture = _content.Load<Texture2D>("Button");
            buttonFont = _content.Load<SpriteFont>("Font");

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

            _components = new List<Component>()
                  {
                    playButton,
                    optionButton,
                    exitButton,
                  };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);


            titleScale = 1.015f;
            spriteBatch.DrawString(buttonFont, "Chessn't", new Vector2(180, 140) + new Vector2(1 * titleScale, 1 * titleScale), Color.Black, 0, Vector2.Zero, titleScale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, "Chessn't", new Vector2(180, 140) + new Vector2(-1 * titleScale, 1 * titleScale), Color.Black, 0, Vector2.Zero, titleScale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, "Chessn't", new Vector2(180, 140) + new Vector2(-1 * titleScale, -1 * titleScale), Color.Black, 0, Vector2.Zero, titleScale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, "Chessn't", new Vector2(180, 140) + new Vector2(1 * titleScale, -1 * titleScale), Color.Black, 0, Vector2.Zero, titleScale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(buttonFont, "Chessn't", new Vector2(180, 140), Color.White);

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
