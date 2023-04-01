﻿using Microsoft.VisualBasic;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Chessnt.Chess.Managers;

namespace Chessnt
{
    public enum ChessPiece
    {
        Pawn,
        King,
        Bishop,
        Knight,
        Rook,
        Queen
    }

    public abstract class Piece : OptionsButton
    {
        public int NumberOfMoves { get; private set; } = 0;
        protected List<ChessButton> legals;
        protected Texture2D legalsTexture;
        public int Row { get; set; }
        public int Col { get; set; }
        public ChessPiece ChessPiece { get; protected set; }
        protected ChessBoard board;

        ChessColor color;
        public ChessColor ChessColor { get => color; private set => color = value; }

        public Piece(Sprite2D sprite, int row, int col, ChessColor color, ChessBoard board)
            : base(sprite)
        {
            legals = new List<ChessButton>();
            this.Row = row;
            this.Col = col;
            legalsTexture = ContentService.Instance.Textures["Circle"];
            this.ChessColor = color;
            this.board = board;
            Marked += (s, e) => { Center(new Rectangle(Col * 110, Row * 110, 110, 110)); };
            UnMarked += (s, e) => { Center(new Rectangle(Col * 110, Row * 110, 110, 110)); };
        }

        public override void Update(Input currentInput, Input previousInput)
        {
            if (MarkedState == OptionButtonState.Marked)
            {
                for (int i = 0; i < legals.Count; i++)
                {
                    legals[i].Update(currentInput, previousInput);
                }
            }
            base.Update(currentInput, previousInput);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.MarkedState == OptionButtonState.Marked)
            {
                DrawLegalMoves(spriteBatch);
            }
            base.Draw(spriteBatch);
        }

        public void Move(int row, int col)
        {
            NumberOfMoves++;
            board.Move(this, row, col);
            Bounds = new Rectangle(col * 110, row * 110, 80, 80);
            Center(new Rectangle(col * 110, row * 110, 80,80));
        }

        protected void AddLegalMove(int r, int c)
        {
            ChessButton b = new ChessButton(new Sprite2D(legalsTexture, new Rectangle(c * 110, r * 110, 110, 110), Color.DarkSlateGray));
            b.Click += (s, e) => { Move(r, c); };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            legals.Add(b);
        }

        public abstract void CalculateLegalMoves();

        public abstract bool SetsCheck();

        public void DrawLegalMoves(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < legals.Count; i++)
            {
                legals[i].Draw(spriteBatch);
            }
            base.Draw(spriteBatch);
        }
    }
}