using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class BoardSpaceController : MonoBehaviour
{
    private Color originalColor;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void SetHighlight(bool isHighlighted, Color highlightColor)
    {
        rend.material.color = isHighlighted ? highlightColor : originalColor;
    }

    void OnMouseDown()
    {
        // TODO: Implement board space click logic
        Debug.Log("Board space clicked!");
    }
}
