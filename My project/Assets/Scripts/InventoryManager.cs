using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public PlantInventoryUI plantInventoryUI;
    public StringInventoryUI stringInventoryUI;
    public PlantItemDetailPanel converterPanel;
    public PlantConverter plantConverter;

    // Dummy data
    public Plant[] dummyPlants;
    public int[] dummyPlantStocks;
    public Strings[] dummyStrings;
    public int[] dummyStringStocks;

    void Start() {
        InitInventory();
    }

    // Populate with dummy data for inventory
    public void InitInventory() {
        List<PlantWrapper> plantItems = new List<PlantWrapper>();
        List<StringWrapper> stringItems = new List<StringWrapper>();
        for (int i = 0; i < dummyPlantStocks.Length; i++) {
            plantItems.Add(new PlantWrapper(dummyPlants[i], dummyPlantStocks[i]));
        }

        for (int i = 0; i < dummyStrings.Length; i++) {
            stringItems.Add(new StringWrapper(dummyStrings[i], dummyStringStocks[i]));
        }

        Inventory<PlantWrapper, Plant> plantInventory = new Inventory<PlantWrapper, Plant>();
        Inventory<StringWrapper, Strings> stringInventory = new Inventory<StringWrapper, Strings>();
        plantInventory.inventoryUI = plantInventoryUI;
        stringInventory.inventoryUI = stringInventoryUI;
        plantInventory.SetItems(plantItems);
        stringInventory.SetItems(stringItems);

        PlantItem.plantItemDetailsPanel = converterPanel;
        PlantWrapper.stringsInventory = stringInventory;
        PlantWrapper.plantConverter = plantConverter;
        PlantItemDetailPanel.plantInventory = plantInventory;
        // plantInventoryUI.InitInventoryUI(plantInventory);
    }
}
