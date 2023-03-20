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

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        private State _currentBaseView;
        private State _nextBaseView;

        public Game1()
        {
            Instance = this;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Set resolution
            //_graphics.PreferredBackBufferWidth = 1920;
            //_graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            IsMouseVisible = true;
        }

        public void ChangeView(State baseView)
        {
            _nextBaseView = baseView;
        }

        protected override void Initialize()
        {
            Globals.WindowSize = new(1920, 1080);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
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
            // Create 1x1 white pixel texture
            Globals.PixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            Globals.PixelTexture.SetData(new[] { Color.White });

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