using UnityEngine;
using TMPro;

public class SelectedTileUI : MonoBehaviour
{
    public SpriteRenderer tileIcon;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI hpText;

    void Update()
    {
        Player currentPlayer = GameManager.Instance.GetCurrentPlayer();
        if (currentPlayer != null)
        {
            TileDefinition selectedTile = currentPlayer.GetSelectedTile();
            if (selectedTile != null)
            {
                tileIcon.sprite = selectedTile.TileIcon;
                costText.text = "Cost: " + selectedTile.Cost.ToString();
                hpText.text = "HP: " + selectedTile.HP.ToString();
            }
        }
    }
}
