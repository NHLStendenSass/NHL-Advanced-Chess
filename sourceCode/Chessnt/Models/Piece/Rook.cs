using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    internal class Rook : PieceBase
    {

        private static int size;
        public Rook(PieceColour _pieceColour) : base(PieceType.ROOK, size) { _pieceColour = this.getPieceColour; }

        internal override bool isValidMove(Tile currentTile, Tile desiredTile)
        {
            bool isVerticalmove = this._isVerticalMove(currentTile, desiredTile);
            bool isHorizontalMove = this._isHorizontalMove(currentTile, desiredTile);

            return isVerticalmove || isHorizontalMove;
        }
    }
}
