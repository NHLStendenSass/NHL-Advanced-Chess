using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    public abstract class PieceBase
    {
        public readonly PieceType pieceType;
        public PieceBase(PieceType pieceType) { 
            this.pieceType = pieceType;
        }

        internal abstract bool isValidMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn);

        protected bool _isDiagonalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isDiagonalMove = Math.Abs(desiredRow - currentRow) == Math.Abs(desiredColumn - currentColumn);
            return isDiagonalMove;
        }

        protected bool _isVerticalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isVerticalMove = currentColumn == desiredColumn && currentRow != desiredRow;
            return isVerticalMove;
        }

        protected bool _isHorizontalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isHorizontalMove = currentRow == desiredRow && currentColumn != desiredColumn;
            return isHorizontalMove;
        }

        //fix this
        protected bool _isSingularDiagonalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isDiagonalMove = Math.Abs(desiredRow - currentRow) == Math.Abs(desiredColumn - currentColumn);
            return isDiagonalMove;
        }

        protected bool _isSingularVerticalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isVerticalMove = currentColumn == desiredColumn && (currentRow == desiredRow + 1 || currentRow == desiredRow - 1);
            return isVerticalMove;
        }

        protected bool _isSingularHorizontalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isHorizontalMove = currentRow == desiredRow && (currentColumn == desiredColumn + 1 || currentColumn == desiredColumn - 1);
            return isHorizontalMove;
        }
    }
}
