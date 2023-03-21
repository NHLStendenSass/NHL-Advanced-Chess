using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt;

public class GameManager
{
    //private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private ChessBoard _chessBoard;
    private Texture2D whiteTexture;
    private Texture2D blackTexture;

    public GameManager()
    {
        _chessBoard = new ChessBoard(whiteTexture, blackTexture);
    }

    public void LoadContent()
    {
        whiteTexture = Globals.Content.Load<Texture2D>("solid_white");
        blackTexture = Globals.Content.Load<Texture2D>("solid_black");
    }

    public void Update()
    {
        _chessBoard.Update();
    }

    public void Draw()
    {
        _chessBoard.Draw(spriteBatch);
    }
}
