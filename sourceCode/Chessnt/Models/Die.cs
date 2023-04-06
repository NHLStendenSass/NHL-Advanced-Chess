﻿using Chessnt.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    public class Die
    {
        private Texture2D _texture;
        private int _value;
        private Vector2 _position;
        private bool _isRolling;
        private int _rollCounter;
        private int _rollSpeed;
        private int _maxRollCount;
        private int _width = 260;
        private int _height = 300;
        private TextOutline _textOutline;
        private SpriteFont _font;
        private int _dieRolledCount;

        public Die(Texture2D texture, Vector2 position, ContentManager content)
        {
            _font = content.Load<SpriteFont>("diceFont");
            _textOutline = new TextOutline(_font);
            _texture = texture;
            _position = position;
            _isRolling = false;
            _rollCounter = 0;
            _rollSpeed = 5;
            _maxRollCount = 100;
            _value = 1;
            _dieRolledCount = 0;
        }
        public int getWidth()
        { return _width; }
        public int getHeight()
        { return _height; }
        public int getValue()
        { return _value; }
        public int getDieRolledCount()
        { return _dieRolledCount; }
        public void Roll()
        {
            _isRolling = true;
            _rollCounter = 0;
        }

        public bool IsRolling()
        { return _isRolling; }

        public void Update()
        {
            if (_isRolling)
            {
                _rollCounter++;

                if (_rollCounter <= _maxRollCount)
                {
                    if (_rollCounter % _rollSpeed == 0)
                    {
                        _value = new Random().Next(1, 21);
                    }
                }
                else
                {
                    _isRolling = false;
                    _value = new Random().Next(1, 21);
                    _dieRolledCount++;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font, SpriteFont outlineFont)
        {
            Rectangle destRect = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
            spriteBatch.Draw(_texture, destRect, Color.White);
            spriteBatch.DrawString(outlineFont, _value.ToString(), new Vector2(_position.X + _width / 2.07f, _position.Y + _height / 2.06f), Color.Black, 0f, new Vector2(font.MeasureString(_value.ToString()).X / 2, font.MeasureString(_value.ToString()).Y / 2), 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, _value.ToString(), new Vector2(_position.X + _width / 2, _position.Y + _height / 2), Color.White, 0f, new Vector2(font.MeasureString(_value.ToString()).X / 2, font.MeasureString(_value.ToString()).Y / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}
