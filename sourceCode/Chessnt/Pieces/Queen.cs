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
        public Queen() : base(PieceType.QUEEN)
        {

        }

        internal override bool isValidMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isDiagonalMove = this._isDiagonalMove(currentRow, currentColumn, desiredRow, desiredColumn);
            bool isVerticalmove = this._isVerticalMove(currentRow, currentColumn, desiredRow, desiredColumn);
            bool isHorizontalMove = this._isHorizontalMove(currentRow, currentColumn, desiredRow, desiredColumn);

            return isDiagonalMove || isVerticalmove || isHorizontalMove;
        }
    }
}
