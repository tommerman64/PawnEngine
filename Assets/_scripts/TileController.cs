using UnityEngine;

public class TileController : MonoBehaviour
{
    private Color originalColor;
    public Color highlightColor = Color.yellow;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = highlightColor;
    }

    void OnMouseExit()
    {
        rend.material.color = originalColor;
    }

    void OnMouseDown()
    {
        // TODO: Implement tile click logic
        Debug.Log("Tile clicked!");
    }
}
