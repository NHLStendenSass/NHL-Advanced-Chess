using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    internal class King : PieceBase
    {

        private static int size;
        public King(PieceColour _pieceColour) : base(PieceType.KING, size) { _pieceColour = this.getPieceColour; }

        internal override bool isValidMove(Tile currentTile, Tile desiredTile)
        {
            bool isSingularHorizontalMove = this._isSingularHorizontalMove(currentTile, desiredTile);
            bool isSingularVerticalMove = this._isSingularVerticalMove(currentTile, desiredTile);
            bool isSingularDiagonalMove = this._isSingularDiagonalMove(currentTile, desiredTile);

            return isSingularDiagonalMove || isSingularHorizontalMove || isSingularVerticalMove;
        }
    }
}
