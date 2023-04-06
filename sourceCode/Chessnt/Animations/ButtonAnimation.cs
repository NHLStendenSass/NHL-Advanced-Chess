using Microsoft.Xna.Framework;

namespace Chessnt
{
    public class ButtonAnimation
    {
        public float? Angle = null;
        public Rectangle? Bounds { get; set; } = null;
        public Color? Color { get; set; } = null;
        public bool OnlyImpactSize { get; set; } = false;

        public ButtonAnimation(float? angle, Rectangle? bounds, Color? color, bool onlyImpactSize)
        {
            Angle = angle;
            Bounds = bounds;
            Color = color;
            OnlyImpactSize = onlyImpactSize;
        }
    }
}