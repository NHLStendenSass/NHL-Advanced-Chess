using Chessnt.Chess.Managers;
using Chessnt.Models.Board;
using Chessnt.Models.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace Chessnt
{
    public class GameState : State
    {
        private SpriteBatch _spriteBatch;

        private Texture2D _backgroundTexture;

        private ChessBoard board;

        private Die _die;
        private int _dieRollCount = 0;

        private SpecialRules _specialRules;

        private MessageBox _messageBox;

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
            _die = new Die(Globals.Content.Load<Texture2D>("dndWhite"), content);
            _specialRules = new SpecialRules();
            _messageBox = new MessageBox(Globals.Content.Load<Texture2D>("messagebox_bg"), Globals.Content.Load<SpriteFont>("messageFont"), Globals.Content.Load<Texture2D>("ok_button"));
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
            if (_messageBox.ShowMessageBox)
            {
                // Draw message box
                _messageBox.Draw(spriteBatch, _messageBox.Message, _messageBox.ExtraText);
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (_messageBox.ShowMessageBox)
            {
                // Update message box
                _messageBox.Update();

                // Check if the user clicks the OK button
                if (_messageBox.OkButtonClicked)
                {
                    _messageBox.ShowMessageBox = false;
                }
            }

            if (!_messageBox.ShowMessageBox)
            {
                previousInput.Keyboard = currentInput.Keyboard;
                previousInput.Mouse = currentInput.Mouse;

                MouseState currentMouseState = Mouse.GetState();
                Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);

                if (board.DiceRollPossible == true)
                {
                    rollDie(currentMouseState, mousePosition);
                }

                currentInput.Update();

                if (!_die.IsRolling())
                {
                    ChessUpdate(gameTime, currentInput, previousInput);
                }
            }
        }

        private void rollDie(MouseState currentMouseState, Point mousePosition)
        {
            if (mousePosition.X > _die.PositionX && mousePosition.X < _die.PositionX + _die.getWidth() && mousePosition.Y > _die.PositionY && mousePosition.Y < _die.PositionY + _die.getHeight() && currentMouseState.LeftButton == ButtonState.Pressed && !_die.IsRolling())
            {
                _die.Roll();
            }

            _die.Update();

            if (_die.getDieRolledCount() > _dieRollCount)
            {
                doRule();
                _dieRollCount++;
                board.DiceRollPossible = false;
                _messageBox.ShowMessageBox = true;
            }
        }

        private void doRule()
        {
            _specialRules.doSelectedRule(_die.getValue(), board, _messageBox);
        }
    }
}
