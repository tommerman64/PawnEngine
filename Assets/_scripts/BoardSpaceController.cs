using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BoardSpaceController : MonoBehaviour
{
    private Color originalColor;
    private Renderer rend;
    private bool isPlaced = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void SetHighlight(bool isHighlighted, Color highlightColor)
    {
        if (!isPlaced)
        {
            rend.material.color = isHighlighted ? highlightColor : originalColor;
        }
    }

    public void SetPlaced(Color placedColor)
    {
        isPlaced = true;
        rend.material.color = placedColor;
    }

    void OnMouseDown()
    {
        // TODO: Implement board space click logic
        Debug.Log("Board space clicked!");
    }
}
