using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Chessnt.Models.Board;

public class Board
{
    public readonly Point Size = new(8, 8);
    public Tile[,] Tiles { get; }
    public Point TileSize { get; set; }

    public Vector2 MapToScreen(int x, int y) => new(x * TileSize.X, y * TileSize.Y);
    public (int x, int y) ScreenToMap(Vector2 pos) => ((int)pos.X / TileSize.X, (int)pos.Y / TileSize.Y);

    public Board()
    {
        Tiles = new Tile[Size.X, Size.Y];
        var texture = Globals.Content.Load<Texture2D>("tile");
        TileSize = new(texture.Width, texture.Height);

        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++)
            {
                Tiles[x, y] = new(texture, MapToScreen(x, y), x, y);
            }
        }
    }

    public void Update()
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++) Tiles[x, y].Update();
        }
    }

    public void Draw()
    {
        for (int y = 0; y < Size.Y; y++)
        {
            for (int x = 0; x < Size.X; x++) Tiles[x, y].Draw();
        }
    }

    public List<Tile>GetAvailableMoves(Tile startTile)
    {
        if (startTile.piece == null)
        {
            throw new Exception("Empty squares do not have available moves");
        }

        List<Tile> validMoves = new List<Tile>();

        for (int i = 0; i < Size.X; i++)
        {
            for(int j = 0; j < Size.Y; j++)
            {
                int desiredColumn = j;
                int desiredRow = i;
                int currentColumn = startTile.getCol();
                int currentRow = startTile.getRow();

                bool newTileIsValid = startTile.getPiece().isValidMove(currentRow, currentColumn, desiredRow, desiredColumn);

                if (newTileIsValid)
                {
                    Tile possibleTile = new Tile(desiredRow, desiredColumn);
                    validMoves.Add(possibleTile);
                }
            }
        }
        return validMoves;
    }
}
