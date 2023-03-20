using Chessnt.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chessnt
{
    public class Main : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Screen _currentBaseView;
        private Screen _nextBaseView;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void ChangeView(Screen baseView)
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
            Globals.SpriteBatch = _spriteBatch;

            //Screen management logic
            _currentBaseView = new GameScreen(this, _graphics.GraphicsDevice, Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (_nextBaseView != null)
            {
                _currentBaseView = _nextBaseView;

                _nextBaseView = null;
            }

            _currentBaseView.Update(gameTime);

            _currentBaseView.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _currentBaseView.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}