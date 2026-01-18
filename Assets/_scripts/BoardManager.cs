using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private Board board;
    private BoardSpaceController currentlyHighlighted;

    public int boardWidth;
    public int boardHeight;
    public GameObject boardSpacePrefab;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        this.board = new Board(width: boardWidth, height: boardHeight);
        for (int i = 0; i < boardWidth; i++)
        {
            for (int j = 0; j < boardHeight; j++)
            {
                GameObject boardSpace = Instantiate(boardSpacePrefab, new Vector3(i, j, 0), Quaternion.identity);
                boardSpace.transform.parent = this.transform;
            }
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            BoardSpaceController hitBoardSpace = hit.collider.GetComponent<BoardSpaceController>();
            if (hitBoardSpace != null)
            {
                if (currentlyHighlighted != hitBoardSpace)
                {
                    if (currentlyHighlighted != null)
                    {
                        currentlyHighlighted.SetHighlight(false, highlightColor);
                    }
                    currentlyHighlighted = hitBoardSpace;
                    currentlyHighlighted.SetHighlight(true, highlightColor);
                }
            }
            else
            {
                if (currentlyHighlighted != null)
                {
                    currentlyHighlighted.SetHighlight(false, highlightColor);
                    currentlyHighlighted = null;
                }
            }
        }
        else
        {
            if (currentlyHighlighted != null)
            {
                currentlyHighlighted.SetHighlight(false, highlightColor);
                currentlyHighlighted = null;
            }
        }
    }
}
