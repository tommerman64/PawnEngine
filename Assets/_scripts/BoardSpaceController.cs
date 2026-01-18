using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Collider))]
public class BoardSpaceController : MonoBehaviour
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
        // TODO: Implement board space click logic
        Debug.Log("Board space clicked!");
    }
}
