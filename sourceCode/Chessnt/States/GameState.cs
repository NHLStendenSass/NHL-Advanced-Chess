using Chessnt.Chess.Managers;
using Chessnt.Models.Board;
using Chessnt.Models.Pieces;
using Chessnt.Utilities;
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
        private Texture2D _buttonTexture;
        private SpriteFont _buttonFont;
        private Utilities.TextOutline _textOutline;

        private ChessBoard board;
        private Die _die;
        private int _dieRollCount = 0;
        private SpecialRules _specialRules;
        private MessageBox _messageBox;

        private Button _backButton;
        private Button _restartButton;
        private List<Component> _buttons;


        Input currentInput;
        Input previousInput;

        public GameState(Game1 main, GraphicsDevice graphicsDevice, ContentManager content)
            : base(main, graphicsDevice, content)
        {
            Globals.Content = content;
            board = new ChessBoard(Constants.TILE_NUMBER, Constants.TILE_NUMBER, Constants.TILESIZE);
            _backgroundTexture = Globals.Content.Load<Texture2D>("bg1");
            _buttonTexture = base.content.Load<Texture2D>("Button");
            _buttonFont = base.content.Load<SpriteFont>("SmallFont");
            _textOutline = new Utilities.TextOutline(_buttonFont);
            currentInput = new Input();
            previousInput = new Input();
            _die = new Die(Globals.Content.Load<Texture2D>("dndWhite"), content);
            _specialRules = new SpecialRules();
            _messageBox = new MessageBox(Globals.Content.Load<Texture2D>("messagebox_bg"), Globals.Content.Load<SpriteFont>("messageFont"), Globals.Content.Load<Texture2D>("ok_button"));

            _backButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(20, 700),
                Text = "Back",
            };

            _backButton.Click += BackButton_Click;

            _restartButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(20, 300),
                Text = "Restart",
            };

            _restartButton.Click += RestartButton_Click;

            _buttons = new List<Component>()
                  {
                    _backButton,
                    _restartButton
                  };
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
        private void DrawButtons(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _buttons)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            game.ChangeState(new MenuState(game, graphicsDevice, content));
        }
        private void RestartButton_Click(object sender, EventArgs e)
        {
            board.InitializePieces();
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
            DrawButtons(gameTime, spriteBatch);
            _die.Draw(spriteBatch, Globals.Content.Load<SpriteFont>("diceFont"), Globals.Content.Load<SpriteFont>("diceFontOutline"));
            if (_messageBox.ShowMessageBox)
            {
                // Draw message box
                _messageBox.Draw(spriteBatch, _messageBox.Message);
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _buttons)
            {
                component.Update(gameTime);
            }

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

                if (board.IsCheckMate) 
                {
                    if (board.LastPieceMoved.ChessColor == ChessColor.Black)
                    {
                        _messageBox.Message = "Check Mate! Black wins.\nPress Ok to start a new game.";
                    }
                    else if (board.LastPieceMoved.ChessColor == ChessColor.White)
                    {
                        _messageBox.Message = "Check Mate! White wins.\nPress Ok to start a new game";
                    }
                    _messageBox.ShowMessageBox = true;
                    board.IsCheckMate = false;
                }
                if (board.IsStaleMate)
                {
                    _messageBox.Message = "Chess, when played perfectly...\n...is a draw. Stalemate.";
                    _messageBox.ShowMessageBox = true;
                    board.IsStaleMate = false;
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
