using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    public class Input
    {
        public KeyboardState Keyboard;
        public MouseState Mouse;

        public Input()
        {
            Keyboard = new KeyboardState();
            Mouse = new MouseState();
        }

        public void Update()
        {
            MouseState position = Microsoft.Xna.Framework.Input.Mouse.GetState();
            Keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            Mouse = new MouseState(position.X - 550, position.Y - 110, position.ScrollWheelValue, position.LeftButton, position.MiddleButton, position.RightButton, position.XButton1, position.XButton2);
        }

        public Vector2 GetVirtualMouseLocation()
        {
            return Mouse.Position.ToVector2();
        }
    }
}
