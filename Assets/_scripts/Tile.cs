using UnityEngine;

public class Tile
{
    public int owningPlayerIndex;
    public TileDefinition tileDefinition;

    public int damageTaken;

    public Tile(TileDefinition definition, int playerIndex)
    {
        this.owningPlayerIndex = playerIndex;
        this.tileDefinition = definition;
        this.damageTaken = 0;
    }

    public void OnTurnStart()
    {
        
    }

    public void OnHit()
    {
        
    }
    
    public int remainingHealth
    {
        get { return this.damageTaken - this.tileDefinition.HP; }
    }
}
