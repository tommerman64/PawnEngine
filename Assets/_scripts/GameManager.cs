using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Player[] players;
    public int currentPlayerIndex;
    public List<TileDefinition> availableTiles;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (availableTiles.Count < 2)
        {
            Debug.LogError("GameManager: Not enough available tiles assigned in the inspector!");
            return;
        }
        players = new Player[2];
        players[0] = new Player(10, new List<TileDefinition> { availableTiles[0], availableTiles[1] });
        players[1] = new Player(10, new List<TileDefinition> { availableTiles[0], availableTiles[1] });
        currentPlayerIndex = 0;
    }

    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            EndTurn();
        }
    }

    public void EndTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        players[currentPlayerIndex].StartTurn();
    }

    public Player GetCurrentPlayer()
    {
        return players[currentPlayerIndex];
    }
}
