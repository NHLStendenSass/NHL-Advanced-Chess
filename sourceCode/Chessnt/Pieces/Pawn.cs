using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    internal class Pawn : PieceBase
    {
        public Pawn() : base(PieceType.PAWN)
        {
        }

        internal override bool isValidMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isSingularVerticalMove = this._isSingularVerticalMove(currentRow, currentColumn, desiredRow, desiredColumn);
            //Make it so that first turn can move two tiles

            return isSingularVerticalMove;
        }
    }
}
