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
        public Bishop() : base(PieceType.BISHOP)
        {
        }

        internal override bool isValidMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isDiagonalMove = this._isDiagonalMove(currentRow, currentColumn, desiredRow, desiredColumn);
            
            return isDiagonalMove;
        }
    }
}
