using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int currentResources;
    public List<TileDefinition> hand;
    public int selectedTileIndex;

    public Player(int startingResources, List<TileDefinition> startingHand)
    {
        this.currentResources = startingResources;
        this.hand = startingHand;
        this.selectedTileIndex = 0;
    }

    public void StartTurn()
    {
        // Maybe add some logic here later for turn start effects
    }

    public TileDefinition GetSelectedTile()
    {
        if (hand.Count == 0)
        {
            return null;
        }
        return hand[selectedTileIndex];
    }

    public void SelectNextTile()
    {
        if (hand.Count > 0)
        {
            selectedTileIndex = (selectedTileIndex + 1) % hand.Count;
        }
    }

    public void SelectPreviousTile()
    {
        if (hand.Count > 0)
        {
            selectedTileIndex = (selectedTileIndex - 1 + hand.Count) % hand.Count;
        }
    }

    public bool CanAfford(TileDefinition tile)
    {
        return currentResources >= tile.Cost;
    }

    public void SpendResources(int amount)
    {
        currentResources -= amount;
    }
}
