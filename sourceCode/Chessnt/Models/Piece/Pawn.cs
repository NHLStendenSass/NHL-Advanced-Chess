using Chessnt.Models.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;

namespace Chessnt.Models.Piece
{
    public class Pawn : PieceBase
    {
        private readonly Tile _sprite;

        public Pawn(Texture2D texture)
        {
            _sprite = new Tile
            {
                Texture = texture,
                Color = Color.White,
                Scale = 1f
            };
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Implement update logic for Pawn.
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Position = Position;
            _sprite.Draw(spriteBatch);
        }
    }
}
