using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Used to configure the plant item GUI for inventory
public class PlantItem : MonoBehaviour
{
    public Image plantRenderer;
    public TextMeshProUGUI nameHolder;
    public TextMeshProUGUI tensionHolder;
    public TextMeshProUGUI stockHolder;

    public void AssignPlant(PlantWrapper plant) {
        nameHolder.SetText(plant.GetPlantName());
        tensionHolder.SetText("Tension: " + plant.GetPlantTension());
        stockHolder.SetText("Stock: " + plant.stock);
        plantRenderer.sprite = plant.GetPlantSprite();
    }
}
