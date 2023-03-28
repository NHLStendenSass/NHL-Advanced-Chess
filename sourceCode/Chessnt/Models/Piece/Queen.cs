using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    internal class Queen : PieceBase
    {

        private static int size;
        public Queen(PieceColour _pieceColour) : base(PieceType.QUEEN, size) { _pieceColour = this.getPieceColour; }

        internal override bool isValidMove(Tile currentTile, Tile desiredTile)
        {
            bool isDiagonalMove = this._isDiagonalMove(currentTile, desiredTile);
            bool isVerticalmove = this._isVerticalMove(currentTile, desiredTile);
            bool isHorizontalMove = this._isHorizontalMove(currentTile, desiredTile);

            return isDiagonalMove || isVerticalmove || isHorizontalMove;
        }
    }
}
