using Chessnt.Models.Board;
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
    public class GameScreen : State
    {
        private Texture2D _backgroundTexture;

        //private GameManager _gameManager;
        private ChessBoard _board;

        private SpriteBatch _spriteBatch;

        public GameScreen(Main main, GraphicsDevice graphicsDevice, ContentManager content)
            : base(main, graphicsDevice, content)
        {
            Globals.Content = content;
            _board = new(numRows: 8, numCols: 8, tileSize: 100);
            _backgroundTexture = Globals.Content.Load<Texture2D>("bg1");
            
            //_gameManager = new GameManager();
        }

        public void LoadContent()
        {
            Globals.SpriteBatch = _spriteBatch;
        }

        public void DrawMenuBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
        }

        public void DrawChessBoard(SpriteBatch spriteBatch)
        {
            _board.Draw(spriteBatch);
        }

        public override void PostUpdate(GameTime gameTime)
        { 
        
        }

        public override void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);
            //_gameManager.Update();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            DrawMenuBackground(spriteBatch);
            DrawChessBoard(spriteBatch);

            spriteBatch.End();
        }
    }
}
