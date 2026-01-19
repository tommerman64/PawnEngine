using UnityEngine;
using UnityEngine.UI;

public class SelectedTileUI : MonoBehaviour
{
    public Image tileIcon;
    public Text costText;
    public Text hpText;

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
