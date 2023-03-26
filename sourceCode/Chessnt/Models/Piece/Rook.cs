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
        public Rook() : base(PieceType.ROOK)
        {
            
        }

        internal override bool isValidMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isVerticalmove = this._isVerticalMove(currentRow, currentColumn, desiredRow, desiredColumn);
            bool isHorizontalMove = this._isHorizontalMove(currentRow, currentColumn, desiredRow, desiredColumn);

            return isVerticalmove || isHorizontalMove;
        }
    }
}
