using System.Collections.Generic;
using UnityEngine;

public class Board
{

    public class BoardSpace
    {
        public Tile PlacedTile;
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

    public void PlaceTile(int x, int y, TileDefinition tileDefinition, int playerIndex)
    {
        if (x >= 0 && x < boardSpaces.Length && y >= 0 && y < boardSpaces[0].Length)
        {
            if (!IsOccupied(x, y))
            {
                Tile newTile = new Tile(tileDefinition, playerIndex);
                boardSpaces[x][y].PlacedTile = newTile;
            }
        }
    }

    public bool IsOccupied(int x, int y)
    {
        if (x >= 0 && x < boardSpaces.Length && y >= 0 && y < boardSpaces[0].Length)
        {
            return boardSpaces[x][y].PlacedTile != null;
        }
        return false;
    }

    public void AdvancePawns()
    {

    }

    public void AddPawn(Pawn p)
    {
        this.pawns.Add(p);
    }
}
