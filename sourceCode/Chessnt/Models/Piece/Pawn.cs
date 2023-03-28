using Chessnt.Models.Board;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt.Pieces
{
    internal class Pawn : PieceBase
    {
        private static int size;
        private Texture2D pawnTexture;
        private Tile startingTile;

        public Pawn(PieceColour _pieceColour) : base(PieceType.PAWN, size) 
        { 
            _pieceColour = this.getPieceColour;
            size = this.getSize;
        }
        public int getSize { get { return size; } }
        internal override bool isValidMove(Tile currentTile, Tile desiredTile)
        {
            bool isSingularVerticalMove = this._isSingularVerticalMove(currentTile, desiredTile);
            //Make it so that first turn can move two tiles
            //Make it so that it can attack diagonally
            return isSingularVerticalMove;
        }
    }
}
