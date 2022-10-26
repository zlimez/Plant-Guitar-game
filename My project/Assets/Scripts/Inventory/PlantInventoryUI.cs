using UnityEngine;

public class PlantInventoryUI : InventoryUI<PlantWrapper, Plant>
{
    public override void InitInventoryUI(Inventory<PlantWrapper, Plant> inventory) {
        foreach (PlantWrapper plant in inventory.items) {
            GameObject itemIcon = Instantiate(itemPrefab, grid);
            itemIcon.GetComponent<PlantItem>().AssignPlant(plant);
            itemIcons[plant.data] = itemIcon;
        }
    }

    public override void AddItem(PlantWrapper item) {
        GameObject itemIcon = Instantiate(itemPrefab, grid);
        itemIcon.GetComponent<PlantItem>().AssignPlant(item);
        itemIcons[item.data] = itemIcon;
    }

    public override void UpdateItem(PlantWrapper item) {
        itemIcons[item.data].GetComponent<PlantItem>().AssignPlant(item);
    }
}