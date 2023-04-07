﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Models.Pieces
{
    class Queen : Piece
    {
        public Queen(Sprite2D sprite, int row, int col, ChessColor color, ChessBoard board)
            : base(sprite, row, col, color, board)
        {
            ChessPiece = ChessPiece.Queen;
        }

        #region ChessMethods
        public override void CalculateLegalMoves()
        {
            Legals.Clear();
            for (int i = 1; i <= Math.Min(Row, Col); i++)
            {
                if (board.IsLegalMove(this, Row - i, Col - i) && board.getBoard()[Row - i, Col - i] is not King)
                {
                    AddLegalMove(Row - i, Col - i);
                }
                if (!board.IsEmpty(Row - i, Col - i)) break;
            }
            for (int i = 1; i <= 7 - Math.Max(Row, Col); i++)
            {
                if (board.IsLegalMove(this, Row + i, Col + i) && board.getBoard()[Row + i, Col + i] is not King)
                {
                    AddLegalMove(Row + i, Col + i);
                }
                if (!board.IsEmpty(Row + i, Col + i)) break;
            }
            for (int i = 1; i <= Math.Min(Row, 7 - Col); i++)
            {
                if (board.IsLegalMove(this, Row - i, Col + i) && board.getBoard()[Row - i, Col + i] is not King)
                {
                    AddLegalMove(Row - i, Col + i);
                }
                if (!board.IsEmpty(Row - i, Col + i)) break;
            }
            for (int i = 1; i <= Math.Min(7 - Row, Col); i++)
            {
                if (board.IsLegalMove(this, Row + i, Col - i) && board.getBoard()[Row + i, Col - i] is not King)
                {
                    AddLegalMove(Row + i, Col - i);
                }
                if (!board.IsEmpty(Row + i, Col - i)) break;
            }
            for (int i = Row - 1; i >= 0; i--)
            {
                if (board.IsLegalMove(this, i, Col) && board.getBoard()[i, Col] is not King)
                {
                    AddLegalMove(i, Col);
                }
                if (!board.IsEmpty(i, Col)) break;
            }
            for (int i = Col - 1; i >= 0; i--)
            {
                if (board.IsLegalMove(this, Row, i) && board.getBoard()[Row, i] is not King)
                {
                    AddLegalMove(Row, i);
                }
                if (!board.IsEmpty(Row, i)) break;
            }
            for (int i = Row + 1; i < 8; i++)
            {
                if (board.IsLegalMove(this, i, Col) && board.getBoard()[i, Col] is not King)
                {
                    AddLegalMove(i, Col);
                }
                if (!board.IsEmpty(i, Col)) break;
            }
            for (int i = Col + 1; i < 8; i++)
            {
                if (board.IsLegalMove(this, Row, i) && board.getBoard()[Row, i] is not King)
                {
                    AddLegalMove(Row, i);
                }
                if (!board.IsEmpty(Row, i)) break;
            }
        }

        public override bool SetsCheck()
        {
            for (int i = 1; i <= Math.Min(Row, Col); i++)
            {
                if (board.IsEmpty(Row - i, Col - i)) continue;
                Piece p = board.GetPiece(Row - i, Col - i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            for (int i = 1; i <= 7 - Math.Max(Row, Col); i++)
            {
                if (board.IsEmpty(Row + i, Col + i)) continue;
                Piece p = board.GetPiece(Row + i, Col + i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            for (int i = 1; i <= Math.Min(Row, 7 - Col); i++)
            {
                if (board.IsEmpty(Row - i, Col + i)) continue;
                Piece p = board.GetPiece(Row - i, Col + i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            for (int i = 1; i <= Math.Min(7 - Row, Col); i++)
            {
                if (board.IsEmpty(Row + i, Col - i)) continue;
                Piece p = board.GetPiece(Row + i, Col - i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            for (int i = Row - 1; i >= 0; i--)
            {
                if (board.IsEmpty(i, Col)) continue;
                Piece p = board.GetPiece(i, Col);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                break;
            }
            for (int i = Col - 1; i >= 0; i--)
            {
                if (board.IsEmpty(Row, i)) continue;
                Piece p = board.GetPiece(Row, i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                break;
            }
            for (int i = Row + 1; i < 8; i++)
            {
                if (board.IsEmpty(i, Col)) continue;
                Piece p = board.GetPiece(i, Col);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                break;
            }
            for (int i = Col + 1; i < 8; i++)
            {
                if (board.IsEmpty(Row, i)) continue;
                Piece p = board.GetPiece(Row, i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                break;
            }
            return false;
        }
        #endregion
    }
}
