using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chessnt;

public static class Globals
{
    public static float Time { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Texture2D PixelTexture { get; set; }
    public static Texture2D rookTexture { get; set; }
    public static Texture2D bishopTexture { get; set; }
    public static Texture2D kingTexture { get; set; }
    public static Texture2D pawnTexture { get; set; }
    public static Texture2D queenTexture { get; set; }
    public static Texture2D knightTexture { get; set; }
    public static Point WindowSize { get; set; }

    public static void Update(GameTime gt)
    {
        Time = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}
