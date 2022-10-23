using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory<T, U> where T : Countable<U>
{
    public List<T> items;
    // For item conversion e.g plant to string, add stock to string
    public Dictionary<U, T> itemDict;

    public void SetItems(List<T> items) {
        this.items = items;
    }

    public void AddExistingItem(int itemIndex) {
        items[itemIndex].AddToStock();
    }

    public void AddExistingItem(U itemData) {
        itemDict[itemData].AddToStock();
    }

    public void UseExistingItem(int itemIndex) {
        T item = items[itemIndex];
        U itemData = item.data;
        bool noneLeft = item.UseStock();
        if (noneLeft) {
            items.RemoveAt(itemIndex);
            itemDict.Remove(itemData);
        }
    }
}
