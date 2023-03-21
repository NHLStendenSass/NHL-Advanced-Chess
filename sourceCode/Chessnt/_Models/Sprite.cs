using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt;

public class Sprite
{
    private Texture2D _texture;

    public Sprite(Texture2D texture)
    {
        _texture = texture;
    }

    //public Vector2 Position { get; set; }
    //public Vector2 Size { get; set; }

    public virtual void Draw(SpriteBatch spriteBatch, Rectangle rectangle)
    {
        spriteBatch.Draw(_texture, rectangle, Color.White);
    }
}
