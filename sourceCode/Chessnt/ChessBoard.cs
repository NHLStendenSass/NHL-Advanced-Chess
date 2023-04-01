using Chessnt.Chess.Managers;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;

namespace Chessnt
{
    public enum Turn
    {
        Player1,
        Player2
    }
    public enum ChessColor
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

        bool moveMade = false;

        Sprite2D[,] grid;

        Piece[,] board;

        public Turn Turn { get; private set; } = Turn.Player1;

        public Piece LastPieceMoved;

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

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null) board[i, j].CalculateLegalMoves();
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
            switch (Turn)
            {
                case Turn.Player2:
                    blacks.Update(curInput, prevInput);
                    //Use stockfish to calculate next oponent move
                    //https://github.com/official-stockfish/Stockfish
                    break;
                case Turn.Player1:
                    whites.Update(curInput, prevInput);
                    break;
            }
            if (moveMade)
            {
                whites.UnmarkAll();
                blacks.UnmarkAll();
                if (Turn == Turn.Player1) Turn = Turn.Player2;
                else Turn = Turn.Player1;
                moveMade = false;
            }
        }

        /// <summary>
        /// Checks if a move is legal in the sense that the move does not threaten own king
        /// Does not check if the move itself follows the rules of chess
        /// </summary>
        public bool IsLegalMove(Piece p, int tR, int tC)
        {
            bool ret = false;
            if (IsEmpty(tR, tC) || board[tR, tC].ChessColor != p.ChessColor || board[tR, tC] == p)
            {
                Piece temp = board[tR, tC];
                board[tR, tC] = p;
                board[p.Row, p.Col] = null;
                ret = true;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] == null) continue;
                        if (board[i, j].ChessColor != p.ChessColor && board[i, j].SetsCheck())
                        {
                            ret = false;
                        }
                    }
                }
                board[p.Row, p.Col] = p;
                board[tR, tC] = temp;
            }
            return ret;
        }

        /// <summary>
        /// Checks if a move is legal in the sense that the move does not threaten own king
        /// Does not check if the move itself follows the rules of chess
        /// This method starts by removing p2 from the board before the check
        /// </summary>
        public bool IsLegalMove(Piece p, int tR, int tC, Piece p2)
        {
            board[p2.Row, p2.Col] = null;
            bool ret = IsLegalMove(p, tR, tC);
            board[p2.Row, p2.Col] = p2;
            return ret;
        }

        public void Move(Piece p, int tr, int tc)
        {
            int r = p.Row;
            int c = p.Col;
            LastPieceMoved = p;
            if (!IsEmpty(tr, tc))
            {
                if (p.ChessColor == ChessColor.Black)
                {
                    whites.Remove(board[tr, tc]);
                }
                else
                {
                    blacks.Remove(board[tr, tc]);
                }
            }
            board[tr, tc] = board[r, c];
            board[r, c] = null;
            board[tr, tc].Col = tc;
            board[tr, tc].Row = tr;
            

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                    {
                        board[i, j].CalculateLegalMoves();
                    }
                }
            }
            moveMade = true;

        }

        public bool InGrid(int r, int c)
        {
            return r >= 0 && r < 8 && c >= 0 && c < 8;
        }

        public Piece GetPiece(int r, int c)
        {
            return board[r, c];
        }
    }
}
