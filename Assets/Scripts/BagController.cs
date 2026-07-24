using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{      // The maximum number of items the bag can hold
    public int capacity = 10;

    private List<TreasureData> items = new List<TreasureData>();

        // Adds an item to the bag if there is space available   
    public bool AddItem(TreasureData treasure)
{   
    if (items.Count >= capacity)
    {
        Debug.Log("Bag is full!");
        return false;
    }

    items.Add(treasure);

    Debug.Log("Added " + treasure.displayName + " to the bag.");

    return true;
}
}