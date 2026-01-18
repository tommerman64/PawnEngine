using UnityEngine;
using UnityEngine.InputSystem;

public class BoardManager : MonoBehaviour
{
    private Board board;
    private BoardSpaceController currentlyHighlighted;
    private BoardSpaceController[][] boardSpaceControllers;

    public int boardWidth;
    public int boardHeight;
    public GameObject boardSpacePrefab;
    public Color highlightColor = Color.yellow;
    public Color P1Color;
    public Color P2Color;

    void Start()
    {
        this.board = new Board(width: boardWidth, height: boardHeight);
        boardSpaceControllers = new BoardSpaceController[boardWidth][];
        for (int i = 0; i < boardWidth; i++)
        {
            boardSpaceControllers[i] = new BoardSpaceController[boardHeight];
            for (int j = 0; j < boardHeight; j++)
            {
                GameObject boardSpace = Instantiate(boardSpacePrefab, new Vector3(i, j, 0), Quaternion.identity);
                boardSpace.transform.parent = this.transform;
                boardSpaceControllers[i][j] = boardSpace.GetComponent<BoardSpaceController>();
            }
        }
    }

    void Update()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        int x = Mathf.RoundToInt(mouseWorldPos.x);
        int y = Mathf.RoundToInt(mouseWorldPos.y);

        BoardSpaceController newHighlighted = null;

        if (x >= 0 && x < boardWidth && y >= 0 && y < boardHeight)
        {
            newHighlighted = boardSpaceControllers[x][y];
        }

        if (currentlyHighlighted != newHighlighted)
        {
            if (currentlyHighlighted != null)
            {
                currentlyHighlighted.SetHighlight(false, highlightColor);
            }

            if (newHighlighted != null)
            {
                newHighlighted.SetHighlight(true, highlightColor);
            }

            currentlyHighlighted = newHighlighted;
        }

        Player currentPlayer = GameManager.Instance.GetCurrentPlayer();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (currentlyHighlighted != null)
            {
                TileDefinition selectedTile = currentPlayer.GetSelectedTile();
                if (selectedTile != null && currentPlayer.CanAfford(selectedTile) && !board.IsOccupied(x,y))
                {
                    currentPlayer.SpendResources(selectedTile.Cost);
                    board.PlaceTile(x, y, selectedTile, GameManager.Instance.currentPlayerIndex);

                    Color placedColor = GameManager.Instance.currentPlayerIndex == 0 ? P1Color : P2Color;
                    boardSpaceControllers[x][y].SetPlaced(placedColor);
                }
                else
                {
                    if (selectedTile != null && !currentPlayer.CanAfford(selectedTile))
                    {
                        Debug.Log("Not enough resources!");
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentPlayer.SelectPreviousTile();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentPlayer.SelectNextTile();
        }
    }
}
