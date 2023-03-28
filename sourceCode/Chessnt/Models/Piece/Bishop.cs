using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    internal class Bishop : PieceBase
    {
        private static int size;
        public Bishop(PieceColour _pieceColour) : base(PieceType.BISHOP, size) { _pieceColour = this.getPieceColour; }

        internal override bool isValidMove(Tile currentTile, Tile desiredTile)
        {
            bool isDiagonalMove = this._isDiagonalMove(currentTile, desiredTile);
            
            return isDiagonalMove;
        }
    }
}
