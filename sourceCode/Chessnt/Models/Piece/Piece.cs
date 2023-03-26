using Chessnt.Models.Board;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.EnterpriseData;

namespace Chessnt.Pieces
{
    public abstract class PieceBase
    {
        private readonly PieceType _pieceType;
        private readonly PieceColour _colour;
        public PieceBase(PieceType pieceType) {
            this._pieceType = pieceType;
        }
        public PieceType getPieceType { get { return this._pieceType; } }
        public PieceColour getPieceColour { get { return this._colour; } } 

        internal abstract bool isValidMove(Tile currentTile, Tile desiredTile);

        //make all methods like dis
        protected bool _isDiagonalMove(Tile currentTile, Tile desiredTile)
        {
            bool isDiagonalMove = Math.Abs(desiredTile.getPosition.X - currentTile.getPosition.X) == Math.Abs(desiredTile.getPosition.Y - currentTile.getPosition.Y);
            return isDiagonalMove;
        }

        //protected bool _isDiagonalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        //{
        //    bool isDiagonalMove = Math.Abs(desiredRow - currentRow) == Math.Abs(desiredColumn - currentColumn);
        //    return isDiagonalMove;
        //}

        protected bool _isVerticalMove(Tile currentTile, Tile desiredTile)
        {
            bool isVerticalMove = currentTile.getPosition.X == desiredTile.getPosition.X && currentTile.getPosition.Y != desiredTile.getPosition.Y;
            return isVerticalMove;
        }
        /*protected bool _isVerticalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isVerticalMove = currentColumn == desiredColumn && currentRow != desiredRow;
            return isVerticalMove;
        }*/


        protected bool _isHorizontalMove(Tile currentTile, Tile desiredTile) 
        {
            bool isHorizontalMove = currentTile.getPosition.Y == desiredTile.getPosition.Y && currentTile.getPosition.X != desiredTile.getPosition.X;
            return isHorizontalMove;
        }
        /*protected bool _isHorizontalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isHorizontalMove = currentRow == desiredRow && currentColumn != desiredColumn;
            return isHorizontalMove;
        }*/

        //fix this
        protected bool _isSingularDiagonalMove(Tile currentTile, Tile desiredTile)
        {
            bool isDiagonalMove = (desiredTile.getPosition.X == currentTile.getPosition.X - 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y - 1)
                || (desiredTile.getPosition.X == currentTile.getPosition.X && desiredTile.getPosition.Y == currentTile.getPosition.Y -1)
                || (desiredTile.getPosition.X == currentTile.getPosition.X + 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y -1)
                || (desiredTile.getPosition.X == currentTile.getPosition.X - 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y)
                || (desiredTile.getPosition.X == currentTile.getPosition.X + 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y)
                || (desiredTile.getPosition.X == currentTile.getPosition.X - 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y + 1)
                || (desiredTile.getPosition.X == currentTile.getPosition.X && desiredTile.getPosition.Y == currentTile.getPosition.Y +1 )
                || (desiredTile.getPosition.X == currentTile.getPosition.X + 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y + 1);
            return isDiagonalMove; 
        }
        /*protected bool _isSingularDiagonalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isDiagonalMove = Math.Abs(desiredRow - currentRow) == Math.Abs(desiredColumn - currentColumn);
            return isDiagonalMove;
        }*/

        protected bool _isSingularVerticalMove(Tile currentTile, Tile desiredTile)
        {
            bool isVerticalMove = currentTile.getPosition.Y == desiredTile.getPosition.Y && (currentTile.getPosition.X == desiredTile.getPosition.X + 1 || currentTile.getPosition.X == desiredTile.getPosition.X - 1);
            return isVerticalMove;
        }

        /*protected bool _isSingularVerticalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isVerticalMove = currentColumn == desiredColumn && (currentRow == desiredRow + 1 || currentRow == desiredRow - 1);
            return isVerticalMove;
        }*/

        protected bool _isSingularHorizontalMove(Tile currentTile, Tile desiredTile)
        {
            bool isSingularHorizontalMove = currentTile.getPosition.X == desiredTile.getPosition.X && (currentTile.getPosition.Y == desiredTile.getPosition.Y + 1 || currentTile.getPosition.Y == desiredTile.getPosition.Y - 1);
            return isSingularHorizontalMove;
        }

        /*protected bool _isSingularHorizontalMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            bool isHorizontalMove = currentRow == desiredRow && (currentColumn == desiredColumn + 1 || currentColumn == desiredColumn - 1);
            return isHorizontalMove;
        }*/

        protected bool _isKnightMove(Tile currentTile, Tile desiredTile)
        {
            bool isKnightMove = (desiredTile.getPosition.X == currentTile.getPosition.X - 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y - 2)
                || (desiredTile.getPosition.X == currentTile.getPosition.X + 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y - 2)
                || (desiredTile.getPosition.X == currentTile.getPosition.X - 2 && desiredTile.getPosition.Y == currentTile.getPosition.Y - 1)
                || (desiredTile.getPosition.X == currentTile.getPosition.X - 2 && desiredTile.getPosition.Y == currentTile.getPosition.Y + 1)
                || (desiredTile.getPosition.X == currentTile.getPosition.X - 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y + 2)
                || (desiredTile.getPosition.X == currentTile.getPosition.X + 1 && desiredTile.getPosition.Y == currentTile.getPosition.Y + 2)
                || (desiredTile.getPosition.X == currentTile.getPosition.X + 2 && desiredTile.getPosition.Y == currentTile.getPosition.Y + 1)
                || (desiredTile.getPosition.X == currentTile.getPosition.X + 2 && desiredTile.getPosition.Y == currentTile.getPosition.Y - 1);
            return isKnightMove;
        }
    }
}
