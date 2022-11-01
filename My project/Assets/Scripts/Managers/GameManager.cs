using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton used to pass data around (Temp solution)
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Strings[] strings;
    public Plant[] dummyPlants;
    public int[] dummyPlantStocks;
    public Strings[] dummyStrings;
    public int[] dummyStringStocks;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
    
        DontDestroyOnLoad(gameObject);

        instance = this;
    }

    public void SaveGuitarConfig(GuitarAssembly assembledGuitar) {
        this.strings = assembledGuitar.strings;
    }

    public void SaveInventoryStatus(InventoryManager inventoryManager) {
        List<PlantWrapper> allPlants = inventoryManager.plantInventory.GetItems();
        List<StringWrapper> allStrings = inventoryManager.stringInventory.GetItems();
        dummyPlants = new Plant[allPlants.Count];
        dummyPlantStocks = new int[allPlants.Count];
        dummyStrings = new Strings[allStrings.Count];
        dummyStringStocks = new int[allStrings.Count];

        for (int i = 0; i < allPlants.Count; i++) {
            dummyPlants[i] = allPlants[i].data;
            dummyPlantStocks[i] = allPlants[i].stock;
        }

        for (int i = 0; i < allStrings.Count; i++) {
            dummyStrings[i] = allStrings[i].data;
            dummyStringStocks[i] = allStrings[i].stock;
        }
    }
}
