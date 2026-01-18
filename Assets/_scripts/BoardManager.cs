using UnityEngine;

public class BoardManager : MonoBehaviour
{

    private Board board;

    public int boardWidth;
    public int boardHeight;
    public GameObject boardSpacePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {

    }
}
