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
        public Knight() : base(PieceType.KNIGHT)
        {
        }

        internal override bool isValidMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            throw new NotImplementedException();
        }
    }
}
