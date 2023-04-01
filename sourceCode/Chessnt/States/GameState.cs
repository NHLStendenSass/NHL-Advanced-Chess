using Chessnt.Chess.Managers;
using Chessnt.Models.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Die _die;
        private int _dieX;
        private int _dieY;

        private SpriteBatch _spriteBatch;

        Input currentInput;
        Input previousInput;    

        public GameState(Game1 main, GraphicsDevice graphicsDevice, ContentManager content)
            : base(main, graphicsDevice, content)
        {
            Globals.Content = content;
            board = new ChessBoard(Constants.TILE_NUMBER, Constants.TILE_NUMBER, Constants.TILESIZE);
            _backgroundTexture = Globals.Content.Load<Texture2D>("bg1");
            currentInput = new Input();
            previousInput = new Input();
            _dieX = 1510;
            _dieY = 390;
            _die = new Die(Globals.Content.Load<Texture2D>("dndWhite"), new Vector2(_dieX, _dieY), content);

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
            _die.Draw(spriteBatch, Globals.Content.Load<SpriteFont>("diceFont"), Globals.Content.Load<SpriteFont>("diceFontOutline"));
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            previousInput.Keyboard = currentInput.Keyboard;
            previousInput.Mouse = currentInput.Mouse;

            MouseState currentMouseState = Mouse.GetState();
            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);

            if (mousePosition.X > _dieX && mousePosition.X < _dieX + _die.getWidth() && mousePosition.Y > _dieY && mousePosition.Y < _dieY + _die.getHeight() && currentMouseState.LeftButton == ButtonState.Pressed && !_die.IsRolling())
            {
                _die.Roll();
            }

            _die.Update();

            currentInput.Update();

            ChessUpdate(gameTime, currentInput, previousInput);
        }
    }
}
