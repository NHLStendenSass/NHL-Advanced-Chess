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
    public class GameState : State
    {
        private Texture2D _backgroundTexture;

        //private GameManager _gameManager;
        private ChessBoard board;

        private SpriteBatch _spriteBatch;

        public GameState(Game1 main, GraphicsDevice graphicsDevice, ContentManager content)
            : base(main, graphicsDevice, content)
        {
            Globals.Content = content;
            board = new ChessBoard();
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
            board.Draw(spriteBatch);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public void ChessUpdate(GameTime gameTime, Input curInput, Input prevInput)
        {
            board.Update(gameTime, curInput, prevInput);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            DrawMenuBackground(spriteBatch);
            DrawChessBoard(spriteBatch);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            Input curInput= new Input();
            Input prevInput = new Input();
            ChessUpdate(gameTime, curInput, prevInput);
        }
    }
}
