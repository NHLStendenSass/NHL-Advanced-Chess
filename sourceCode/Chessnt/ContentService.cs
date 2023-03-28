namespace Chessnt
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Media;
    using System;
    using System.Collections.Generic;

    namespace Chess.Managers
    {
        class ContentService
        {
            public Dictionary<string, Texture2D> Textures { get; private set; }
            public Dictionary<string, SpriteFont> Fonts { get; private set; }
            public Dictionary<string, Song> MusicBank { get; private set; }
            public Dictionary<string, SoundEffect> SoundBank { get; private set; }


            private static ContentService _instance;
            private ContentManager _content;

            private ContentService()
            {
                Textures = new Dictionary<string, Texture2D>();
                Fonts = new Dictionary<string, SpriteFont>();
            }

            public static ContentService Instance //Not optimal but only want there to ever exist one ContentSerive, hence a singleton class
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new ContentService();
                    }
                    return _instance;
                }
            }

            public void LoadContent(ContentManager Content, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
            {
                if (_content != null)
                {
                    throw new Exception($"Method '{System.Reflection.MethodBase.GetCurrentMethod().Name}' can only be called once");
                }
                _content = Content;

                AddTexture("WhiteEmpty", "Empty");
                AddTexture("Circle", "Circle");

                Texture2D texture = _content.Load<Texture2D>("ChessPieces");

                Texture2D target = new Texture2D(graphicsDevice, 100, 100);
                Color[] data = new Color[100 * 100];

                Rectangle sourceRectangle = new Rectangle(32, 67, 100, 100);
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "BlackKing");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 210;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "BlackQueen");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 388;
                sourceRectangle.Y = 71;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "BlackRook");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 565;
                sourceRectangle.Y = 67;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "BlackBishop");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 745;
                sourceRectangle.Y = 72;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "BlackKnight");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 920;
                sourceRectangle.Y = 71;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "BlackPawn");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.Y = 216;
                sourceRectangle.X = 32;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "WhiteKing");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 211;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "WhiteQueen");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 389;
                sourceRectangle.Y = 219;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "WhiteRook");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 566;
                sourceRectangle.Y = 215;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "WhiteBishop");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 745;
                sourceRectangle.Y = 221;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "WhiteKnight");
                target = new Texture2D(graphicsDevice, 100, 100);

                sourceRectangle.X = 920;
                sourceRectangle.Y = 220;
                texture.GetData(0, sourceRectangle, data, 0, data.Length);
                target.SetData(data);
                AddTexture(target, "WhitePawn");
            }

            private void AddTexture(Texture2D texture, string key)
            {
                Textures.Add(key, texture);
            }

            private void AddTexture(string fileDirectory, string key = null)
            {
                if (key == null)
                {
                    Textures.Add(fileDirectory, _content.Load<Texture2D>(fileDirectory));
                }
                else
                {
                    Textures.Add(key, _content.Load<Texture2D>(fileDirectory));
                }
            }
        }
    }


}