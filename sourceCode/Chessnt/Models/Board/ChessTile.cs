using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt.Models.Board;

public class Tile : Sprite
{
    public const int SIZE = 64;
    private bool isWhite;
    private Vector2 position;
    private Texture2D texture;

    public Tile(bool isWhite, Vector2 position) : base(isWhite, position)
    {
        this.isWhite = isWhite;
        this.position = position;
        this.texture = isWhite ? Globals.Content.Load<Texture2D>("white_tile") : Globals.Content.Load<Texture2D>("black_tile");
    }

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
