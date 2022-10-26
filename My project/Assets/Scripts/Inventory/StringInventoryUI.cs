using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringInventoryUI : InventoryUI<StringWrapper, Strings>
{
    public override void InitInventoryUI(Inventory<StringWrapper, Strings> inventory) {
        foreach (StringWrapper aString in inventory.items) {
            GameObject itemIcon = Instantiate(itemPrefab, grid);
            itemIcon.GetComponent<StringItem>().AssignString(aString);
            itemIcons[aString.data] = itemIcon;
        }
    }

    public override void AddItem(StringWrapper item) {
        GameObject itemIcon = Instantiate(itemPrefab, grid);
        itemIcon.GetComponent<StringItem>().AssignString(item);
        itemIcons[item.data] = itemIcon;
    }

    public override void UpdateItem(StringWrapper item) {
        itemIcons[item.data].GetComponent<StringItem>().AssignString(item);
    }
}
