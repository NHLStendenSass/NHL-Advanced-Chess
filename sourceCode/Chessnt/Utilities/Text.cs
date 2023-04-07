using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Utilities
{
    public class Text
    {
        public string Content { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public float Scale { get; set; }
        public int FontSize { get; set; }
        public Color Color { get; set; }

        public Text(string content, int x, int y, float scale, int fontSize, Color color)
        {
            Content = content;
            X = x;
            Y = y;
            Scale = scale;
            FontSize = fontSize;
            Color = color;
        }
    }
}
