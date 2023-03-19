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
    public class GameView : BaseView
    {
        private Texture2D backgroundTexture;

        private GameManager _gameManager;
        private SpriteBatch _spriteBatch;
        public GameView(Main main, GraphicsDevice graphicsDevice, ContentManager content)
            : base(main, graphicsDevice, content)
        {
            Globals.Content = content;
            _gameManager = new GameManager();
        }

        protected void LoadContent()
        {
            Globals.SpriteBatch = _spriteBatch;
        }

        private void DrawMenuBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) 
        {
            spriteBatch.Begin();

            _gameManager.Draw();
            //DrawMenuBackground(spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        { 
        
        }

        public override void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);
            _gameManager.Update();
        }
    }
}
