using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Used to configure the plant item GUI for inventory
public class PlantItem : MonoBehaviour
{
    public Image plantRenderer;
    public TextMeshProUGUI nameHolder;
    public PlantWrapper plant;
    public static PlantItemDetailPanel plantItemDetailsPanel;

    public void AssignPlant(PlantWrapper plant) {
        nameHolder.SetText(plant.GetPlantName());
        plantRenderer.sprite = plant.GetPlantSprite();
        this.plant = plant;
    }

    public void OpenPanel() {
        plantItemDetailsPanel.SetPlant(plant);
        plantItemDetailsPanel.gameObject.SetActive(true);
    }
}
