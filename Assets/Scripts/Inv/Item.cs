using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite itemSprite;
    public string itemName;
    public int itemID;
    public string itemDesc;

}

