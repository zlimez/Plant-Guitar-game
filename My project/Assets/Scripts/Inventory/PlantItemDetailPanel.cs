using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantItemDetailPanel : MonoBehaviour
{
    public TextMeshProUGUI nameHolder;
    public TextMeshProUGUI tensionHolder;
    public TextMeshProUGUI stockHolder;
    public Image plantImageHolder;
    public PlantWrapper plant;
    public static Inventory<PlantWrapper, Plant> plantInventory;

    public void SetPlant(PlantWrapper plant) {
        nameHolder.SetText(plant.GetPlantName());
        tensionHolder.SetText("Tension: " + plant.GetPlantTension() + "N");
        stockHolder.SetText("Stock: " + plant.stock);
        plantImageHolder.sprite = plant.GetPlantSprite();
        this.plant = plant;
    }

    public void ConvertPlant() {
        plantInventory.UseExistingItem(plant.data);
    }
}
