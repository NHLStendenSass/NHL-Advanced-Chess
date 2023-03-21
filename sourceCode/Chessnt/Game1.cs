using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chessnt
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;

<<<<<<< HEAD:sourceCode/Chessnt/Main.cs
        private Screen _currentBaseView;
        private Screen _nextBaseView;

        public Main()
=======
        public Game1()
>>>>>>> parent of 7430d80 (update of using view manager):sourceCode/Chessnt/Game1.cs
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

<<<<<<< HEAD:sourceCode/Chessnt/Main.cs
        public void ChangeView(Screen baseView)
        {
            _nextBaseView = baseView;
        }

=======
>>>>>>> parent of 7430d80 (update of using view manager):sourceCode/Chessnt/Game1.cs
        protected override void Initialize()
        {
            Globals.WindowSize = new(640, 640);
            _graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            _graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            _graphics.ApplyChanges();

            Globals.Content = Content;
            _gameManager = new();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
<<<<<<< HEAD:sourceCode/Chessnt/Main.cs

            //Screen management logic
            _currentBaseView = new GameScreen(this, _graphics.GraphicsDevice, Content);
=======
>>>>>>> parent of 7430d80 (update of using view manager):sourceCode/Chessnt/Game1.cs
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);
            _gameManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _gameManager.Draw();

            base.Draw(gameTime);
        }
    }
}