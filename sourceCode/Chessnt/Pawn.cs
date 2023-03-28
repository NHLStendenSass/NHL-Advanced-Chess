using Microsoft.VisualBasic;

namespace Chessnt
{
    class Pawn : Piece
    {
        public Pawn(Sprite2D sprite, int row, int col, ChessColor color, ChessBoard board)
            : base(sprite, row, col, color, board)
        {
            ChessPiece = ChessPiece.Pawn;
        }
    }
}