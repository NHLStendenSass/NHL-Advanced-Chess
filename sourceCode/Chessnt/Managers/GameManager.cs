using Chessnt.Models.Board;
using Chessnt.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Chessnt;

public class GameManager
{
    //private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    public static List<PieceBase> pieces = new List<PieceBase>();
    private ChessBoard _chessBoard;
    private bool isMoved;
    private PieceBase currentPiece;
    private static int currentTurn;
    private GraphicsDeviceManager _graphics;

    private static readonly List<PieceBase> WhitePieces = new List<PieceBase>();
    private static readonly List<PieceBase> BlackPieces = new List<PieceBase>();

    private static readonly List<Queen> QueenPieces = new List<Queen>();
    private static readonly List<King> KingPieces = new List<King>();
    private static readonly List<Pawn> PawnPieces = new List<Pawn>();
    private static readonly List<Knight> KnightPieces = new List<Knight>();
    private static readonly List<Rook> RookPieces = new List<Rook>();
    private static readonly List<Bishop> BishopPieces = new List<Bishop>();
    public GameManager()
    {
        _chessBoard = new ChessBoard(8, 8, 64);
    }

    public void LoadContent()
    {
            
    }

    public void Update()
    {
    }

    private static void AddPiece(PieceBase newPiece)
    {
        pieces.Add(newPiece);
        //AddToTeam(newPiece);
    }

    public void Draw()
    {
        _chessBoard.Draw(spriteBatch);
        for(int i = 0; i < pieces.Count; i++) 
        {

        }
    }
}
