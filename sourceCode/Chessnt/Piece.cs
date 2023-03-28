using Microsoft.VisualBasic;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Chessnt.Chess.Managers;

namespace Chessnt
{

    enum ChessPiece
    {
        Pawn,
        King,
        Bishop,
        Knight,
        Rook,
        Queen
    }

    abstract class Piece : OptionsButton
    {
        public int NumberOfMoves { get; private set; } = 0;
        protected List<ChessButton> legals;
        protected Texture2D legalsTexture;
        public int Row { get; set; }
        public int Col { get; set; }
        public ChessPiece ChessPiece { get; protected set; }
        protected ChessBoard board;
        ChessColor color;
        internal ChessColor ChessColor { get => color; private set => color = value; }

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
            base.Draw(spriteBatch);
        }
    }
}