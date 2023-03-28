using Chessnt.Models.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Devices;
using Windows.Security.EnterpriseData;

namespace Chessnt.Pieces
{
    public abstract class PieceBase
    {
        private readonly PieceType _pieceType;
        private readonly PieceColour _colour;
        public Tile _startingTile;
        private readonly int _size;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public PieceBase(PieceType pieceType, int size) {
            _pieceType = pieceType;
            _size = size;
        }
        public PieceType getPieceType { get { return this._pieceType; } }
        public PieceColour getPieceColour { get { return this._colour; } }
        public int getSize { get { return this._size; } }
        public Tile getStartingTile { get { return this._startingTile; } }
        public void setStartingTile(Tile startingTile) 
        {
            _startingTile = startingTile;   
        }

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
        public void Draw(SpriteBatch _spriteBatch)
        {

            Texture2D _texture2D = null;
            Color _colour = Color.Transparent;
            switch (_pieceType)
            {
                case PieceType.ROOK:
                    _texture2D = Globals.Content.Load<Texture2D>("Rook1.png");
                    _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
                    break;
                case PieceType.KING:
                    _texture2D = Globals.Content.Load<Texture2D>("King1.png");
                    _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
                    break;
                case PieceType.QUEEN:
                    _texture2D = Globals.Content.Load<Texture2D>("Queen1.png");
                    _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
                    break;
                case PieceType.PAWN:
                    _texture2D = Globals.Content.Load<Texture2D>("Pawn1.png");
                    _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
                    break;
                case PieceType.KNIGHT:
                    _texture2D = Globals.Content.Load<Texture2D>("Knight1.png");
                    _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
                    break;
                case PieceType.BISHOP:
                    _texture2D = Globals.Content.Load<Texture2D>("Bishop1.png");
                    _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
                    break;
            }
            if(this.getPieceColour == PieceColour.WHITE)
            {
                _colour = Color.White;
                _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
            } 
            else
            {
                _colour = Color.Black;
                _startingTile.setPosition(_startingTile.getPosition.X, _startingTile.getPosition.Y);
            }
            _spriteBatch.Draw(_texture2D, new Rectangle((int)_startingTile.getPosition.X, (int)_startingTile.getPosition.Y, _size, _size), _colour);
        }
    }
}
