using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static bool isAddStringState;
    public PlantInventoryUI plantInventoryUI;
    public StringInventoryUI stringInventoryUI;
    public Inventory<StringWrapper, Strings> stringInventory;
    public Inventory<PlantWrapper, Plant> plantInventory;
    public PlantItemDetailPanel converterPanel;
    public PlantConverter plantConverter;
    public GuitarAssembly assembly;


    void Start() {
        InitInventory();
    }

    // Populate with dummy data for inventory
    public void InitInventory() {
        List<PlantWrapper> plantItems = new List<PlantWrapper>();
        List<StringWrapper> stringItems = new List<StringWrapper>();
        GameManager gameManager = GameManager.instance;
        for (int i = 0; i < gameManager.dummyPlantStocks.Length; i++) {
            plantItems.Add(new PlantWrapper(gameManager.dummyPlants[i], gameManager.dummyPlantStocks[i]));
        }

        for (int i = 0; i < gameManager.dummyStrings.Length; i++) {
            stringItems.Add(new StringWrapper(gameManager.dummyStrings[i], gameManager.dummyStringStocks[i]));
        }

        plantInventory = new Inventory<PlantWrapper, Plant>();
        stringInventory = new Inventory<StringWrapper, Strings>();
        plantInventory.inventoryUI = plantInventoryUI;
        stringInventory.inventoryUI = stringInventoryUI;
        plantInventory.SetItems(plantItems);
        stringInventory.SetItems(stringItems);

        PlantItem.plantItemDetailsPanel = converterPanel;
        PlantWrapper.stringsInventory = stringInventory;
        PlantWrapper.plantConverter = plantConverter;
        PlantItemDetailPanel.plantInventory = plantInventory;

        StringItem.stringInventory = stringInventory;
        StringWrapper.assembly = assembly;
        GuitarAssembly.stringsInventory = stringInventory;
    }

    public void ChangeState(bool changedState) {
        isAddStringState = changedState;
    }

    // Triggered by scene change event
    public void StoreInventoryStatus() {
        GameManager.instance.SaveInventoryStatus(this);
    }
}
