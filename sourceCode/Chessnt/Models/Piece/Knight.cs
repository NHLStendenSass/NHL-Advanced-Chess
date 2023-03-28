using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    internal class Knight : PieceBase
    {

        private static int size;
        public Knight(PieceColour _pieceColour) : base(PieceType.KNIGHT, size) { _pieceColour = this.getPieceColour; }

        internal override bool isValidMove(Tile currentTile, Tile desiredTile)
        {
            bool isKnightMove = this._isKnightMove(currentTile, desiredTile);
            return isKnightMove;
        }
    }
}
