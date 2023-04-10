using Chessnt.Models.Board;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;

namespace Chessnt
{
    class Pawn : Piece
    {
        public Pawn(Sprite2D sprite, int row, int col, ChessColor color, ChessBoard board)
            : base(sprite, row, col, color, board)
        {
            ChessPiece = ChessPiece.Pawn;
        }

        public override void CalculateLegalMoves()
        {
            Legals.Clear();
            if (NumberOfMoves == 0 && (Row == 6 && ChessColor == ChessColor.White) || (Row == 1 && ChessColor == ChessColor.Black))
            {
                if (ChessColor == ChessColor.White && board.IsEmpty(Row-1, Col) && board.IsEmpty(Row-2, Col))
                {
                    if (board.IsLegalMove(this, Row-2, Col) && board.getBoard()[Row - 2, Col] is not King)
                    {
                        AddLegalMove(Row-2, Col);
                    }
                }
                else if (ChessColor == ChessColor.Black && board.IsEmpty(Row+1, Col) && board.IsEmpty(Row+2, Col))
                {
                    if (board.IsLegalMove(this, Row+2, Col) && board.getBoard()[Row + 2, Col] is not King)
                    {
                        AddLegalMove(Row+2, Col);
                    }
                }
            }
            if (ChessColor == ChessColor.White && board.IsEmpty(Row - 1, Col))
            {
                if (board.IsLegalMove(this, Row - 1, Col) && board.getBoard()[Row - 1, Col] is not King)
                {
                    AddLegalMove(Row - 1, Col);
                }
            }
            else if (ChessColor == ChessColor.Black && board.IsEmpty(Row + 1, Col))
            {
                if (board.IsLegalMove(this, Row + 1, Col) && board.getBoard()[Row + 1, Col] is not King)
                {
                    AddLegalMove(Row + 1, Col);
                }
            }
            if (Col != 0)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col - 1) && board.GetPiece(Row - 1, Col - 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row - 1, Col - 1) && board.getBoard()[Row - 1, Col - 1] is not King)
                    {
                        AddLegalMove(Row - 1, Col - 1);
                    }
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col - 1) && board.GetPiece(Row + 1, Col - 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row + 1, Col - 1) && board.getBoard()[Row + 1, Col - 1] is not King)
                    {
                        AddLegalMove(Row + 1, Col - 1);
                    }
                }
            }
            if (Col != 7)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col + 1) && board.GetPiece(Row - 1, Col + 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row - 1, Col + 1) && board.getBoard()[Row - 1, Col + 1] is not King)
                    {
                        AddLegalMove(Row - 1, Col + 1);
                    }
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col + 1) && board.GetPiece(Row + 1, Col + 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row + 1, Col + 1) && board.getBoard()[Row + 1, Col + 1] is not King)
                    {
                        AddLegalMove(Row + 1, Col + 1);
                    }
                }
            }
            //En passant
            if (Col != 0)
            {
                if (Row == 3 && ChessColor == ChessColor.White && !board.IsEmpty(Row, Col - 1) && board.IsEmpty(Row - 1, Col - 1))
                {
                    Piece p = board.GetPiece(Row, Col - 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row - 1, Col - 1, p))
                    {
                        AddEnPassantMove(p, Row - 1, Col - 1);
                    }
                }
                else if (Row == 4 && ChessColor == ChessColor.Black && !board.IsEmpty(Row, Col - 1) && board.IsEmpty(Row + 1, Col - 1))
                {
                    Piece p = board.GetPiece(Row, Col - 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row + 1, Col - 1, p))
                    {
                        AddEnPassantMove(p, Row + 1, Col - 1);
                    }
                }
            }
            if (Col != 7)
            {
                if (Row == 3 && ChessColor == ChessColor.White && !board.IsEmpty(Row, Col + 1) && board.IsEmpty(Row - 1, Col + 1))
                {
                    Piece p = board.GetPiece(Row, Col + 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row - 1, Col + 1, p))
                    {
                        AddEnPassantMove(p, Row - 1, Col + 1);
                    }
                }
                else if (Row == 4 && ChessColor == ChessColor.Black && !board.IsEmpty(Row, Col + 1) && board.IsEmpty(Row + 1, Col + 1))
                {
                    Piece p = board.GetPiece(Row, Col + 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row + 1, Col + 1, p))
                    {
                        AddEnPassantMove(p, Row + 1, Col + 1);

                    }
                }
            }
        }

        public override bool SetsCheck()
        {
            if (Col != 0)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col - 1) && board.GetPiece(Row - 1, Col - 1).ChessColor != ChessColor && board.GetPiece(Row - 1, Col - 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col - 1) && board.GetPiece(Row + 1, Col - 1).ChessColor != ChessColor && board.GetPiece(Row + 1, Col - 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
            }
            if (Col != 7)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col + 1) && board.GetPiece(Row - 1, Col + 1).ChessColor != ChessColor && board.GetPiece(Row - 1, Col + 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col + 1) && board.GetPiece(Row + 1, Col + 1).ChessColor != ChessColor && board.GetPiece(Row + 1, Col + 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
            }
            return false;
        }

        protected void AddEnPassantMove(Piece p, int r, int c)
        {
            ChessButton b = new ChessButton(new Sprite2D(legalsTexture, new Rectangle(c * 110-5, r * 110-10, 110, 110), Color.DarkSlateGray));
            b.Click += (s, e) => { p.Move(r, c); Move(r, c);  };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            Legals.Add(b);
        }
    }
}