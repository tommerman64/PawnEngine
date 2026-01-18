using UnityEngine;

[CreateAssetMenu(fileName = "TileDefinition", menuName = "Scriptable Objects/TileDefinition")]
public class TileDefinition : ScriptableObject
{
    public int Cost;
    public int HP;

    public Sprite TileIcon;
    
}
