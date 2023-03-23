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
        public King() : base(PieceType.KING)
        {
        }

        internal override bool isValidMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isSingularHorizontalMove = this._isSingularHorizontalMove(currentRow, currentColumn, desiredRow, desiredColumn);
            bool isSingularVerticalMove = this._isSingularVerticalMove(currentRow, currentColumn, desiredRow, desiredColumn);
            bool isSingularDiagonalMove = this._isSingularDiagonalMove(currentRow, currentColumn, desiredRow, desiredColumn);

            return isSingularDiagonalMove || isSingularHorizontalMove || isSingularVerticalMove;
        }
    }
}
