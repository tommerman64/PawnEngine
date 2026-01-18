using System.Collections.Generic;
using UnityEngine;

public class Board
{

    public class BoardSpace
    {
        Tile PlacedTile;
    }

    public BoardSpace[][] boardSpaces;
    private List<Pawn> pawns;


    public Board(int width, int height)
    {
        boardSpaces = new BoardSpace[width][];
        for (int i = 0; i < width; i++)
        {
            boardSpaces[i] = new BoardSpace[height];
            for (int j = 0; j < height; j++)
            {
                boardSpaces[i][j] = new BoardSpace();
            }
        }
        this.pawns = new List<Pawn>();
    }

    public void AdvancePawns()
    {

    }

    public void AddPawn(Pawn p)
    {
        this.pawns.Add(p);
    }
}
