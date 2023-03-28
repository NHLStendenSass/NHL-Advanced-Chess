using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Chessnt.Models.Board;

public class ChessBoard
{
    private readonly int _numRows;
    private readonly int _numCols;
    private readonly int _tileSize;
    private readonly Tile[,] _tiles;


    //-------------


    public ChessBoard(int numRows, int numCols, int tileSize)
    {
        _numRows = numRows;
        _numCols = numCols;
        _tileSize = tileSize;

        _tiles = new Tile[numRows, numCols];

        int boardWidth = numCols * tileSize;
        int boardHeight = numRows * tileSize;

        int x = (Game1.Instance.GraphicsDevice.Viewport.Width - boardWidth) / 2;
        int y = (Game1.Instance.GraphicsDevice.Viewport.Height - boardHeight) / 2;

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                Color tileColor = ((row + col) % 2 == 0) ? Color.White : Color.Black;
                Vector2 tilePosition = new Vector2(x + col * tileSize, y + row * tileSize);
                _tiles[row, col] = new Tile(tilePosition, tileSize, tileColor);
            }
        }

        //--------
        //Texture2D gridSquares = ContentService.Instance.Textures["Empty"];
        //grid = new Sprite2D[8, 8];
        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        grid[i, j] = new Sprite2D(gridSquares, new Rectangle(j * Constants.TILESIZE, i * Constants.TILESIZE, Constants.TILESIZE, Constants.TILESIZE), Color.Black);
        //        if ((i + j) % 2 == 0) grid[i, j].Color = Color.White;
        //    }
        //}
        //-------
    }


    public void Update(SpriteBatch spriteBatch)
    {

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Draw tiles
        for (int row = 0; row < _numRows; row++)
        {
            for (int col = 0; col < _numCols; col++)
            {
                _tiles[row, col].Draw(spriteBatch);
            }
        }
    }

    public bool IsEmpty(int r, int c)
    {
        return board[r, c] == null;
    }
}
