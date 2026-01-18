using UnityEngine;

public class BoardManager : MonoBehaviour
{

    private Board board;

    public int boardWidth;
    public int boardHeight;
    public GameObject tilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.board = new Board(width: boardWidth, height: boardHeight);
        for (int i = 0; i < boardWidth; i++)
        {
            for (int j = 0; j < boardHeight; j++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(i, j, 0), Quaternion.identity);
                tile.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
