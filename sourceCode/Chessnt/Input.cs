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
            Keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            Mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        public Vector2 GetVirtualMouseLocation()
        {
            return Mouse.Position.ToVector2();
        }
    }
}
