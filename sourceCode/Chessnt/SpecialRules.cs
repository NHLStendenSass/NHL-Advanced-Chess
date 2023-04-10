using Chessnt.Chess.Managers;
using Chessnt.Models.Board;
using Chessnt.Models.Pieces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnt
{
    public class SpecialRules
    {
        public SpecialRules() { }

        public void doSelectedRule(int dieValue, ChessBoard board, MessageBox messageBox)
        {
            switch (dieValue)
            {
                case 1: 
                    doRuleOne(board);
                    messageBox.Message = "One of your pawns turns into a queen!\nBut only if you have one.";
                    break;
                    
                case 2:
                    doRuleTwo(board);
                    messageBox.Message = "One of your pawns turns into a rook!\nBut only if you have one.";
                    break;
                case 3:
                    doRuleThree(board);
                    messageBox.Message = "One of your pawns turns into a bishop!\nBut only if you have one.";
                    break;
                case 4:
                    doRuleFour(board);
                    messageBox.Message = "One of your pawns turns into a knight!\nBut only if you have one.";
                    break;
                case 5:
                    doRuleFive(board);
                    messageBox.Message = "Oops. One of your queens turns into a pawn!\nBut only if you have one.";
                    break;
                case 6:
                    doRuleSix(board);
                    messageBox.Message = "Oops. One of your rooks turns into a pawn!\nBut only if you have one.";
                    break;
                case 7:
                    doRuleSeven(board);
                    messageBox.Message = "Oops. One of your bishops turns into a pawn!\nBut only if you have one.";
                    break;
                case 8:
                    doRuleEight(board);
                    messageBox.Message = "Oops. One of your knights turns into a pawn!\nBut only if you have one."; 
                    break;
                case 9:
                    doRuleNine(board);
                    messageBox.Message = "You lose your turn. Unfortunate.\nIn return, your opponent has no rolls this turn.";
                    break;
            }
        }

        public void doRuleOne(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Pawn, ChessPiece.Queen);
        }
        public void doRuleTwo(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Pawn, ChessPiece.Rook);
        }
        public void doRuleThree(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Pawn, ChessPiece.Bishop);
        }
        public void doRuleFour(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Pawn, ChessPiece.Knight);
        }
        public void doRuleFive(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Queen, ChessPiece.Pawn);

        }
        public void doRuleSix(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Rook, ChessPiece.Pawn);

        }
        public void doRuleSeven(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Bishop, ChessPiece.Pawn);
        }
        public void doRuleEight(ChessBoard board)
        {
            replacePiece(board, ChessPiece.Knight, ChessPiece.Pawn);
        }
        public void doRuleNine(ChessBoard board)
        {
            board.getWhites().UnmarkAll();
            board.getBlacks().UnmarkAll();
            if (board.Turn == Turn.Player1) board.Turn = Turn.Player2;
            else board.Turn = Turn.Player1;
        }

        private void replacePiece(ChessBoard board, ChessPiece piece, ChessPiece newPiece)
        {
            List<Piece> pieceToReplace = new List<Piece>();
            Piece chosenPiece = null;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.getBoard()[i, j] != null)
                    {
                        if (board.Turn == Turn.Player1)
                        {
                            if (board.GetPiece(i, j).ChessPiece == piece && board.GetPiece(i, j).ChessColor == ChessColor.White)
                            {
                                pieceToReplace.Add(board.GetPiece(i, j));
                            }
                        }

                        else if (board.Turn == Turn.Player2)
                        {
                            if (board.GetPiece(i, j).ChessPiece == piece && board.GetPiece(i, j).ChessColor == ChessColor.Black)
                            {
                                pieceToReplace.Add(board.GetPiece(i, j));
                            }
                        }
                    }
                }
            }
            if (board.Turn == Turn.Player1)
            {
                if (pieceToReplace.Count > 0)
                {
                    chosenPiece = pieceToReplace[new Random().Next(0, pieceToReplace.Count)];
                    board.getWhites().Remove(board.getBoard()[chosenPiece.Row, chosenPiece.Col]);
                    switch (newPiece)
                    {
                        case ChessPiece.Queen:
                            Piece x = new Queen(new Sprite2D(ContentService.Instance.Textures["WhiteQueen"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.White, board);
                            x.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x;
                            board.getWhites().Add(x);
                            break;
                        case ChessPiece.Rook:
                            Piece x1 = new Rook(new Sprite2D(ContentService.Instance.Textures["WhiteRook"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.White, board);
                            x1.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x1;
                            board.getWhites().Add(x1);
                            break;
                        case ChessPiece.Bishop:
                            Piece x2 = new Bishop(new Sprite2D(ContentService.Instance.Textures["WhiteBishop"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.White, board);
                            x2.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x2;
                            board.getWhites().Add(x2);
                            break;
                        case ChessPiece.Knight:
                            Piece x3 = new Knight(new Sprite2D(ContentService.Instance.Textures["WhiteKnight"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.White, board);
                            x3.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x3;
                            board.getWhites().Add(x3);
                            break;
                        case ChessPiece.Pawn:
                            Piece x4 = new Pawn(new Sprite2D(ContentService.Instance.Textures["WhitePawn"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.White, board);
                            x4.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x4;
                            board.getWhites().Add(x4);
                            break;
                    }

                    board.getBoard()[chosenPiece.Row, chosenPiece.Col].MarkAnimation = new ButtonAnimation(null, new Rectangle(board.getBoard()[chosenPiece.Row, chosenPiece.Col].Bounds.Location, new Point(Constants.MARKED_PIECESIZE, Constants.MARKED_PIECESIZE)), null, true);
                    board.getBoard()[chosenPiece.Row, chosenPiece.Col].UnMarkAnimation = new ButtonAnimation(null, new Rectangle(board.getBoard()[chosenPiece.Row, chosenPiece.Col].Bounds.Location, new Point(Constants.PIECESIZE, Constants.PIECESIZE)), null, true);
                    board.getBoard()[chosenPiece.Row, chosenPiece.Col].CalculateLegalMoves();
                    pieceToReplace.Clear();
                    chosenPiece = null;
                }
            }
            else if (board.Turn == Turn.Player2)
            {
                if (pieceToReplace.Count > 0)
                {
                    chosenPiece = pieceToReplace[new Random().Next(0, pieceToReplace.Count)];
                    board.getBlacks().Remove(board.getBoard()[chosenPiece.Row, chosenPiece.Col]);
                    switch (newPiece)
                    {
                        case ChessPiece.Queen:
                            Piece x = new Queen(new Sprite2D(ContentService.Instance.Textures["BlackQueen"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.Black, board);
                            x.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x;
                            board.getBlacks().Add(x);
                            break;
                        case ChessPiece.Rook:
                            Piece x1 = new Rook(new Sprite2D(ContentService.Instance.Textures["BlackRook"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.Black, board);
                            x1.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x1;
                            board.getBlacks().Add(x1);
                            break;
                        case ChessPiece.Bishop:
                            Piece x2 = new Bishop(new Sprite2D(ContentService.Instance.Textures["BlackBishop"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.Black, board);
                            x2.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x2;
                            board.getBlacks().Add(x2);
                            break;
                        case ChessPiece.Knight:
                            Piece x3 = new Knight(new Sprite2D(ContentService.Instance.Textures["BlackKnight"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.Black, board);
                            x3.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x3;
                            board.getBlacks().Add(x3);
                            break;
                        case ChessPiece.Pawn:
                            Piece x4 = new Pawn(new Sprite2D(ContentService.Instance.Textures["BlackPawn"], new Rectangle(0, 0, Constants.PIECESIZE, Constants.PIECESIZE)), chosenPiece.Row, chosenPiece.Col, ChessColor.Black, board);
                            x4.Center(board.Grid[chosenPiece.Row, chosenPiece.Col].Bounds);
                            board.getBoard()[chosenPiece.Row, chosenPiece.Col] = x4;
                            board.getBlacks().Add(x4);
                            break;
                    }

                    board.getBoard()[chosenPiece.Row, chosenPiece.Col].MarkAnimation = new ButtonAnimation(null, new Rectangle(board.getBoard()[chosenPiece.Row, chosenPiece.Col].Bounds.Location, new Point(Constants.MARKED_PIECESIZE, Constants.MARKED_PIECESIZE)), null, true);
                    board.getBoard()[chosenPiece.Row, chosenPiece.Col].UnMarkAnimation = new ButtonAnimation(null, new Rectangle(board.getBoard()[chosenPiece.Row, chosenPiece.Col].Bounds.Location, new Point(Constants.PIECESIZE, Constants.PIECESIZE)), null, true);
                    board.getBoard()[chosenPiece.Row, chosenPiece.Col].CalculateLegalMoves();
                    pieceToReplace.Clear();
                    chosenPiece = null;
                }
            }
        }
    }
}
