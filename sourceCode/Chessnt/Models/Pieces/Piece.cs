using Microsoft.VisualBasic;
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
        private List<ChessButton> legals;
        protected Texture2D legalsTexture;
        public int Row { get; set; }
        public int Col { get; set; }
        public ChessPiece ChessPiece { get; protected set; }
        protected ChessBoard board;

        ChessColor color;
        public ChessColor ChessColor { get => color; private set => color = value; }
        public List<ChessButton> Legals { get => legals; set => legals = value; }

        public Piece(Sprite2D sprite, int row, int col, ChessColor color, ChessBoard board)
            : base(sprite)
        {
            Legals = new List<ChessButton>();
            this.Row = row;
            this.Col = col;
            legalsTexture = ContentService.Instance.Textures["Dot"];
            this.ChessColor = color;
            this.board = board;
            UnMarked += (s, e) => { Center(new Rectangle(Col * 110, Row * 110, 110, 110)); };
            Marked += (s, e) => { Center(new Rectangle(Col * 110, Row * 110-5, 110, 110)); };
        }

        public override void Update(Input currentInput, Input previousInput)
        {
            if (MarkedState == OptionButtonState.Marked)
            {
                for (int i = 0; i < Legals.Count; i++)
                {
                    Legals[i].Update(currentInput, previousInput);
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
            Bounds = new Rectangle(col * 110, row * 110, 110, 110);
            Center(new Rectangle(col * 110, row * 110, 110,110));
        }

        protected void AddLegalMove(int r, int c)
        {
            ChessButton b = new ChessButton(new Sprite2D(legalsTexture, new Rectangle(c * 110-5, r * 110-10, 110, 110), Color.Red));
            b.Click += (s, e) => { Move(r, c); };
            b.Hover += (s, e) => { b.Color = Color.IndianRed; };
            b.UnHover += (s, e) => { b.Color = Color.Red; };
            Legals.Add(b);
        }

        public abstract void CalculateLegalMoves();

        public abstract bool SetsCheck();

        public void DrawLegalMoves(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Legals.Count; i++)
            {
                Legals[i].Draw(spriteBatch);
            }
            base.Draw(spriteBatch);
        }
    }
}