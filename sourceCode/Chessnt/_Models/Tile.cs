using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt;

public class Tile : Sprite
{
    public const int Size = 64;

    private Texture2D _texture;

    public Vector2 Position { get; set; }

    public Tile(Texture2D texture) : base(texture)
    {
        _texture = texture;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, Color.White);
    }

    public void Update()
    { 
    
    
    }
}
