using Chessnt.Models.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt;

public class GameManager
{
    private readonly Board _map;

    public GameManager()
    {
        _map = new();
    }

    public void Update()
    {
        _map.Update();
    }

    public void Draw()
    {
        _map.Draw();
    }
}
