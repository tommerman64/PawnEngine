using UnityEngine;

public class BoardManager : MonoBehaviour
{

    private Board board;

    public int boardWidth;
    public int boardHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.board = new Board(width: boardWidth, height: boardHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
