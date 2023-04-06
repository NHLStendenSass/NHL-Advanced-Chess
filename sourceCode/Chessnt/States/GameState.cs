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

namespace Chessnt
{
    public class GameState : State
    {
        private Texture2D _backgroundTexture;

        private ChessBoard board;
        private Die _die;
        private int _dieX;
        private int _dieY;
        private int _dieValue;
        private int _dieRollCount;

        private SpriteBatch _spriteBatch;

        private List<Component> _components;
        private Button _voiceButton;
        private VoiceCommand _voiceCommand;

        private Texture2D _buttonTexture;
        private SpriteFont _buttonFont;
        private Utilities.TextOutline _textOutline;

        Input currentInput;
        Input previousInput;

        public GameState(Game1 main, GraphicsDevice graphicsDevice, ContentManager content)
            : base(main, graphicsDevice, content)
        {
            Globals.Content = content;
            board = new ChessBoard(Constants.TILE_NUMBER, Constants.TILE_NUMBER, Constants.TILESIZE);
            _backgroundTexture = Globals.Content.Load<Texture2D>("bg1");
            _buttonTexture = base.content.Load<Texture2D>("Button");
            _buttonFont = base.content.Load<SpriteFont>("Font");
            _textOutline = new Utilities.TextOutline(_buttonFont);
            _voiceCommand = new VoiceCommand(game, graphicsDevice, content);

            currentInput = new Input();
            previousInput = new Input();

            _dieX = 1510;
            _dieY = 390;
            _dieRollCount = 0;
            _die = new Die(Globals.Content.Load<Texture2D>("dndWhite"), new Vector2(_dieX, _dieY), content);

            _voiceButton = new Button(_buttonTexture, _buttonFont)
            {
                Position = new Vector2(1400, 170),
                Text = "Talk",
            };
            _voiceButton.Click += VoiceButton_Click;

            _components = new List<Component>()
                  {
                    _voiceButton
                  };
        }

        private void VoiceButton_Click(object sender, EventArgs e)
        {
            _voiceCommand.RecognitionWithMicrophoneAsync().Wait();
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

        public int getDieValue()
        {
            int row = 1;
            int col = 3;
            board.getBlacks().Remove(board.getBoard()[row, col]);
            Piece x = new Queen(new Sprite2D(ContentService.Instance.Textures["BlackQueen"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), 1, 3, ChessColor.Black, this.board);
            x.Center(board.Grid[1, 3].Bounds);
            board.getBoard()[row, col] = x;
            board.getBlacks().Add(x);
            board.getBoard()[row, col].MarkAnimation = new ButtonAnimation(null, new Rectangle(board.getBoard()[row, col].Bounds.Location, new Point(Constants.MARKED_PIECESIZE, Constants.MARKED_PIECESIZE)), null, true);
            board.getBoard()[row, col].UnMarkAnimation = new ButtonAnimation(null, new Rectangle(board.getBoard()[row, col].Bounds.Location, new Point(Constants.PIECESIZE, Constants.PIECESIZE)), null, true);
            return _dieValue;
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
            DrawComponents(gameTime, spriteBatch);
            _die.Draw(spriteBatch, Globals.Content.Load<SpriteFont>("diceFont"), Globals.Content.Load<SpriteFont>("diceFontOutline"));
            spriteBatch.End();
        }

        private void DrawComponents(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
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

            if (_die.getDieRolledCount() > _dieRollCount)
            {
                _dieValue = _die.getValue();
                getDieValue();
                _dieRollCount++;
            }

            currentInput.Update();

            ChessUpdate(gameTime, currentInput, previousInput);
            TalkButtonUpdate(gameTime);
        }

        private void TalkButtonUpdate(GameTime gameTime) {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
