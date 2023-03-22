using Chessnt.Models.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt;

public class GameManager
{
    //private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private ChessBoard _chessBoard;

    public GameManager()
    {
        _chessBoard = new ChessBoard(8, 8, 64);
    }

    public void LoadContent()
    {
    }

    public void Update()
    {
    }

    public void Draw()
    {
        _chessBoard.Draw(spriteBatch);
    }
}
