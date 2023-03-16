using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    public class TextOutline
    {
        private SpriteFont _buttonFont;

        public TextOutline(SpriteFont spriteFont)
        {
            this._buttonFont= spriteFont;
        }

        public void DrawTextOutLine(String text, float x, float y, float scale, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_buttonFont, text, new Vector2(x, y) + new Vector2(1 * scale, 1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(x, y) + new Vector2(-1 * scale, 1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(x, y) + new Vector2(-1 * scale, -1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
            spriteBatch.DrawString(_buttonFont, text, new Vector2(x, y) + new Vector2(1 * scale, -1 * scale), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 1f);
        }
    }
}
