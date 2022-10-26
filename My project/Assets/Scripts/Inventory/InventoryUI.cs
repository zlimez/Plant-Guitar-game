using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryUI<T, U> : MonoBehaviour where T : Countable<U>
{
    public GameObject itemPrefab;
    public Transform grid;
    public Dictionary<U, GameObject> itemIcons = new Dictionary<U, GameObject>();

    public abstract void InitInventoryUI(Inventory<T, U> inventory) ;

    public abstract void AddItem(T item);
    
    public abstract void UpdateItem(T item);

    public void RemoveItem(U itemData) {
        Destroy(itemIcons[itemData]);
        itemIcons.Remove(itemData);
    }
}
