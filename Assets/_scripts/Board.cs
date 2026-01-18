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
        
    }

    public void AdvancePawns()
    {
        
    }

    public void AddPawn(Pawn p)
    {
        this.pawns.Add(p);
    }
}
