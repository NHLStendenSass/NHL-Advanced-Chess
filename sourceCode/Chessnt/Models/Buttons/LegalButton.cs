using Chessnt.Models.Board;
using Microsoft.Xna.Framework.Input;
using System;

namespace Chessnt
{

    public enum LegalButtonState
    {
        Unmarked,
        Marked
    }

    public class LegalButton : ChessButton
    {
        public LegalButtonState MarkedState { get; private set; }

        public ButtonAnimation MarkAnimation { get; set; }
        public ButtonAnimation UnMarkAnimation { get; set; }

        public event EventHandler Marked;
        public event EventHandler UnMarked;

        public bool AllowClickToUnmark = true;

        public LegalButton(Sprite2D sprite) : base(sprite)
        {
        }

        public override void Update(Input currentInput, Input previousInput)
        {
            if (Contains(currentInput.GetVirtualMouseLocation()))//check mouse position on top of button
            {
                if (currentInput.Mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)//check if clicked
                {
                    State = ButtonCondition.Pressed;
                    if (ClickAnimation != null) Animate(ClickAnimation);
                    if (AllowClickToUnmark && MarkedState == LegalButtonState.Marked)
                    {
                        UnMark();
                    }
                    else if (MarkedState != LegalButtonState.Marked)
                    {
                        Mark();
                    }
                    OnClick(EventArgs.Empty);
                }
                else if (State != ButtonCondition.Hovered && MarkedState != LegalButtonState.Marked)
                {
                    if (State == ButtonCondition.None)
                    {
                        if (HoverAnimation != null) Animate(HoverAnimation);
                        OnHover(EventArgs.Empty);
                    }
                    State = ButtonCondition.Hovered;
                }
            }
            else if (State != ButtonCondition.None && MarkedState != LegalButtonState.Marked)
            {
                if (UnHoverAnimation != null) Animate(UnHoverAnimation);
                OnUnHover(EventArgs.Empty);
                State = ButtonCondition.None;
            }
        }

        public override void Update(MouseState currentInput, Input previousInput)
        {
            if (Contains(currentInput.Position))
            {
                if (currentInput.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    State = ButtonCondition.Pressed;
                    if (ClickAnimation != null) Animate(ClickAnimation);
                    if (AllowClickToUnmark && MarkedState == LegalButtonState.Marked)
                    {
                        UnMark();
                    }
                    else if (MarkedState != LegalButtonState.Marked)
                    {
                        Mark();
                    }
                    OnClick(EventArgs.Empty);
                }
                else if (State != ButtonCondition.Hovered && MarkedState != LegalButtonState.Marked)
                {
                    if (State == ButtonCondition.None)
                    {
                        if (HoverAnimation != null) Animate(HoverAnimation);
                        OnHover(EventArgs.Empty);
                    }
                    State = ButtonCondition.Hovered;
                }
            }
            else if (State != ButtonCondition.None && MarkedState != LegalButtonState.Marked)
            {
                if (UnHoverAnimation != null) Animate(UnHoverAnimation);
                OnUnHover(EventArgs.Empty);
                State = ButtonCondition.None;
            }
        }

        public void Mark()
        {
            if (MarkAnimation != null) Animate(MarkAnimation);
            MarkedState = LegalButtonState.Marked;
            OnMarked(EventArgs.Empty);

        }

        public void UnMark()
        {
            if (UnMarkAnimation != null) Animate(UnMarkAnimation);
            MarkedState = LegalButtonState.Unmarked;
            OnUnMarked(EventArgs.Empty);
        }

        protected virtual void OnMarked(EventArgs e)
        {
            EventHandler handler = Marked;
            handler?.Invoke(this, e);
        }

        protected virtual void OnUnMarked(EventArgs e)
        {
            EventHandler handler = UnMarked;
            handler?.Invoke(this, e);
        }
    }
}