using Chessnt.Chess.Managers;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;

namespace Chessnt
{
    enum Turn
    {
        Player1,
        Player2
    }
    enum ChessColor
    {
        Black,
        White
    }
    public class ChessBoard
    {
        MarkableButtonPanel whites;
        MarkableButtonPanel blacks;

        private readonly int _numRows;
        private readonly int _numCols;
        private readonly int _tileSize;
        private int x;
        private int y;

        Sprite2D[,] grid;

        Piece[,] board;

        public ChessBoard(int numRows, int numCols, int tileSize)
        {

            _numRows = numRows;
            _numCols = numCols;
            _tileSize = tileSize;

            int boardWidth = numCols * tileSize;
            int boardHeight = numRows * tileSize;

            x = (Game1.Instance.GraphicsDevice.Viewport.Width - boardWidth) / 2;
            y = (Game1.Instance.GraphicsDevice.Viewport.Height - boardHeight) / 2;

            Texture2D gridSquares = ContentService.Instance.Textures["Empty"];
            grid = new Sprite2D[numRows, numCols];
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    grid[i, j] = new Sprite2D(gridSquares, new Rectangle(j * tileSize, i * tileSize, tileSize, tileSize), Color.DarkGray);
                    if ((i + j) % 2 == 0) grid[i, j].Color = Color.White;
                }
            }

            InitializePieces();
        }

        private void InitializePieces()
        {
            board = new Piece[8, 8];

            whites = new MarkableButtonPanel();
            blacks = new MarkableButtonPanel();

            int pieceSize = 80;
            int markSize = 90;

            for (int i = 0; i < 8; i++)
            {
                Piece temp = new Pawn(new Sprite2D(ContentService.Instance.Textures["WhitePawn"], new Rectangle(0, 0, pieceSize, pieceSize)), 6, i, ChessColor.White, this);
                temp.Center(grid[6, i].Bounds);
                board[6, i] = temp;
            }

            for (int i = 0; i < 8; i++)
            {
                Piece temp = new Pawn(new Sprite2D(ContentService.Instance.Textures["BlackPawn"], new Rectangle(0, 0, pieceSize, pieceSize)), 1, i, ChessColor.Black, this);
                temp.Center(grid[1, i].Bounds);
                board[1, i] = temp;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null) continue;
                    board[i, j].MarkAnimation = new ButtonAnimation(null, new Rectangle(board[i, j].Bounds.Location, new Point(markSize, markSize)), null, true);
                    board[i, j].UnMarkAnimation = new ButtonAnimation(null, new Rectangle(board[i, j].Bounds.Location, new Point(pieceSize, pieceSize)), null, true);
                    if (board[i, j].ChessColor == ChessColor.Black) blacks.Add(board[i, j]);
                    else whites.Add(board[i, j]);
                }
            }
        }

        public bool IsEmpty(int r, int c)
        {
            return board[r, c] == null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j].Draw(spriteBatch);
                }
            }
            whites.Draw(spriteBatch);
            blacks.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, Input curInput, Input prevInput)
        {
        }
    }
}
