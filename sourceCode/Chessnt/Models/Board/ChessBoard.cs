using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;

namespace Chessnt.Models.Board;

public class ChessBoard
{
    private Texture2D _whiteTexture;
    private Texture2D _blackTexture;
    private Tile[,] _tiles;
    private const int BoardSize = 8;

    public int Width { get; private set; }
    public int Height { get; private set; }

    public ChessBoard(Texture2D whiteTexture, Texture2D blackTexture)
    {
        _blackTexture = blackTexture;
        _whiteTexture = whiteTexture;

        // Create tiles
        _tiles = new Tile[BoardSize, BoardSize];
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                if ((row + col) % 2 == 0)
                {
                    _tiles[row, col] = new Tile(whiteTexture);
                }
                else
                {
                    _tiles[row, col] = new Tile(blackTexture);
                }

                _tiles[row, col].Position = new Vector2(col * Tile.Size, row * Tile.Size);
            }
        }
    }

    //public void SetTextures(Texture2D whiteTexture, Texture2D blackTexture)
    //{
    //    this.whiteTexture = whiteTexture;
    //    this.blackTexture = blackTexture;
    //}


    public void Update()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                _tiles[row, col].Update();
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw tiles
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                _tiles[row, col].Draw(spriteBatch);
            }
        }
    }
}
