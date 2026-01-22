using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BoardManager boardManager;
    public Transform selectedTileUI;

    void Start()
    {
        // Center camera on the board
        float boardWidth = boardManager.boardWidth;
        float boardHeight = boardManager.boardHeight;
        Camera.main.transform.position = new Vector3((boardWidth - 1) / 2f, (boardHeight - 1) / 2f, -10);

        // Adjust camera to fit the board
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = boardWidth / boardHeight;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = boardHeight / 2;
        }
        else
        {
            float newSize = boardWidth / 2;
            Camera.main.orthographicSize = newSize / screenRatio;
        }

        // Align UI to bottom left
        if (selectedTileUI != null)
        {
            Renderer uiRenderer = selectedTileUI.GetComponentInChildren<Renderer>();
            if (uiRenderer != null)
            {
                Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
                Vector3 extents = uiRenderer.bounds.extents;
                selectedTileUI.position = new Vector3(bottomLeft.x + extents.x, bottomLeft.y + extents.y, selectedTileUI.position.z);
            }
        }
    }

}
