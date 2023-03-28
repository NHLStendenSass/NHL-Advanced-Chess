using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt.Models.Board;

public class Tile
{
    private Vector2 _position;
    private readonly int _size;
    private readonly Color _color;

    private static Texture2D _whiteTexture;

    public Tile(Vector2 position, int size, Color color)
    {
        _position = position;
        _size = size;
        _color = color;
    }

    public Vector2 getPosition{ get { return this._position; } }
    public void setPosition(float valueX, float valueY) 
    {
        _position.X = valueX;
        _position.Y = valueY;
    }
    public int getSize { get { return this._size;} }
    public Color GetColor { get { return this._color;} }

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
