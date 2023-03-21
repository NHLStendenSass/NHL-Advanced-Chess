using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt.Models.Board;

public class Tile
{
    private readonly Vector2 _position;
    private readonly int _size;
    private readonly Color _color;

    private static Texture2D _whiteTexture;

    public Tile(Vector2 position, int size, Color color)
    {
        _position = position;
        _size = size;
        _color = color;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // initialize the white texture if it hasn't been initialized yet
        if (_whiteTexture == null)
        {
            _whiteTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _whiteTexture.SetData(new[] { Color.White });
        }
        // draw the tile using the white texture and the tile color
        spriteBatch.Draw(_whiteTexture, new Rectangle((int)_position.X, (int)_position.Y, _size, _size), _color);
    }
}
