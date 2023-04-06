using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Chessnt.Chess.Managers;

namespace Chessnt
{
    public class Game1 : Game
    {
        public static Game1 Instance { get; private set; }
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public State _currentState;
        private State _nextState;
        private double timer;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            Instance = this;
            _graphics = new GraphicsDeviceManager(this);
            _graphics.SynchronizeWithVerticalRetrace= false;
            IsFixedTimeStep = false;
            Content.RootDirectory = "Content";
            timer = 0;
            //Set resolution
            //_graphics.PreferredBackBufferWidth = 1920;
            //_graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true;


            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.WindowSize = new(1920, 1080);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            //Globals.Content = Content;
            //_gameManager = new();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new LoadingState(this, _graphics.GraphicsDevice, Content);
            Globals.SpriteBatch = _spriteBatch;
            ContentService.Instance.LoadContent(this.Content, GraphicsDevice, _spriteBatch);
            new OptionState(this, _graphics.GraphicsDevice, Content);
            new GameState(this, _graphics.GraphicsDevice, Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _currentState.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}