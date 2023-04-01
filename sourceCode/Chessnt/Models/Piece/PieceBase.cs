using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Models.Piece
{
    public abstract class PieceBase
    {
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public bool IsSelected { get; set; }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
