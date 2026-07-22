using UnityEngine;

[CreateAssetMenu(
    fileName = "New Treasure",
    menuName = "Treasure Hoarder/Treasure Data"
)]
public class TreasureData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public int goldValue;
    public int spawnWeight;
}