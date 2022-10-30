using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory<T, U> where T : Countable<U>
{
    // For Inventroy UI rendering reference
    public List<T> items;
    // For item conversion e.g plant to string, add stock to string
    public Dictionary<U, T> itemDict = new Dictionary<U, T>();
    public InventoryUI<T, U> inventoryUI;

    public void SetItems(List<T> items) {
        this.items = items;
        itemDict.Clear();
        foreach (T item in items) {
            itemDict[item.data] = item;
        }
        inventoryUI.InitInventoryUI(this);
    }

    public void AddItem(U itemData) {
        if (itemDict.ContainsKey(itemData)) {
            itemDict[itemData].AddToStock();
            inventoryUI.UpdateItem(itemDict[itemData]);
        } else {
            T newItem = (T) new Countable<U>(itemData, 1);
            items.Add(newItem);
            itemDict[itemData] = newItem;
            inventoryUI.AddItem(itemDict[itemData]);
        }
    }

    public void UseExistingItem(U itemData) {
        if (itemDict.ContainsKey(itemData)) {
            Debug.Log("Item exists");
        }
        bool noneLeft = itemDict[itemData].UseStock();
        if (noneLeft) {
            items.Remove(itemDict[itemData]);
            itemDict.Remove(itemData);
            inventoryUI.RemoveItem(itemData);
        } else {
            inventoryUI.UpdateItem(itemDict[itemData]);
        }
    }
}
