using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    internal class MarkableButtonPanel
    {
        private List<OptionsButton> _panel;

        public MarkableButtonPanel()
        {
            _panel = new List<OptionsButton>();
        }

        public int GetMarkedIndex()
        {
            for (int i = 0; i < _panel.Count; i++)
            {
                if (_panel[i].MarkedState == OptionButtonState.Marked)
                {
                    return i;
                }
            }
            return -1;
        }

        public void UnmarkAll()
        {
            for (int i = 0; i < _panel.Count; i++)
            {
                _panel[i].UnMark();
            }
        }

        public void Add(OptionsButton button)
        {
            _panel.Add(button);
            _panel[_panel.Count - 1].AllowClickToUnmark = false;
        }

        public void Remove(OptionsButton ob)
        {
            _panel.Remove(ob);
            UnmarkAll();
        }


        public void Update(Input current, Input previous)
        {
            int marked = -1;
            for (int i = 0; i < _panel.Count; i++)
            {
                OptionsButton btn = _panel[i];
                OptionButtonState state = btn.MarkedState;
                btn.Update(current, previous);
                if (btn.MarkedState != state)
                {
                    marked = i;
                }
            }
            if (marked != -1)
            {
                for (int i = 0; i < _panel.Count; i++)
                {
                    if (i != marked)
                    {
                        _panel[i].UnMark();
                    }
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var btn in _panel)
            {
                btn.Draw(spriteBatch);
            }
        }
    }
}
