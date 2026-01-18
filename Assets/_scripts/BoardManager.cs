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
    }
}
