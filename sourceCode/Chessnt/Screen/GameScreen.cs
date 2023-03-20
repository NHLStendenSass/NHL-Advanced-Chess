using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.View
{
    public class GameScreen : Screen
    {
        private Texture2D backgroundTexture;

        private GameManager _gameManager;
        private SpriteBatch _spriteBatch;
        public GameScreen(Main main, GraphicsDevice graphicsDevice, ContentManager content)
            : base(main, graphicsDevice, content)
        {
            Globals.Content = content;
            _gameManager = new GameManager();
        }

        public void LoadContent()
        {
            Globals.SpriteBatch = _spriteBatch;
            backgroundTexture = Globals.Content.Load<Texture2D>("bg1");
        }

        public void DrawMenuBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
        }

        public void DrawChessBoard()
        {
            _gameManager.Draw();
        }

        public override void PostUpdate(GameTime gameTime)
        { 
        
        }

        public override void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);
            _gameManager.Update();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            DrawChessBoard();
            DrawMenuBackground(spriteBatch);

            spriteBatch.End();
        }
    }
}
