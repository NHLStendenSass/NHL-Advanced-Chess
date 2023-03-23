using Chessnt.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chessnt.Models.Board;

public class Tile : Sprite
{
    public const int SIZE = 64;
    private bool isWhite;
    private Vector2 position;
    private Texture2D texture;

    private int row;
    private int col;
    public PieceBase piece;

    public int DesiredRow { get; }
    public int DesiredColumn { get; }

    public Tile(bool isWhite, Vector2 position) : base(isWhite, position)
    {
        this.isWhite = isWhite;
        this.position = position;
        this.texture = isWhite ? Globals.Content.Load<Texture2D>("white_tile") : Globals.Content.Load<Texture2D>("black_tile");
    }

    public Tile(bool isWhite, Vector2 position, int row, int col) : base(isWhite, position)
    {
        this.row = row;
        this.col = col;
        this.isWhite = isWhite;
        this.position = position;
        this.texture = isWhite ? Globals.Content.Load<Texture2D>("white_tile") : Globals.Content.Load<Texture2D>("black_tile");
    }

    public Tile(bool isWhite, Vector2 position, int row, int col, PieceBase piece) : base(isWhite, position)
    {
        this.row = row;
        this.col = col;
        this.isWhite = isWhite;
        this.position = position;
        this.texture = isWhite ? Globals.Content.Load<Texture2D>("white_tile") : Globals.Content.Load<Texture2D>("black_tile");
        this.piece = piece;
    }

    public Tile(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public string getDisplayCoordinates()
    {
        char rowCoordinate = Convert.ToChar(row + 65 + 32);
        return rowCoordinate + col.ToString();
    }

    public int getRow() { return row; }
    public int getCol() { return col; }
    public PieceBase getPiece() {  return piece; }
    public void Update()
    {
        //if (Pathfinder.Ready() && Rectangle.Contains(InputManager.MouseRectangle))
        //{
        //    if (InputManager.MouseClicked)
        //    {
        //        Blocked = !Blocked;
        //    }

        //    if (InputManager.MouseRightClicked)
        //    {
        //        Pathfinder.BFSearch(_mapX, _mapY);
        //    }
        //}

        //Color = Path ? Color.Green : Color.White;
        //Color = Blocked ? Color.Red : Color;
    }


}
