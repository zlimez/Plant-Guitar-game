using UnityEngine;

public class PlantWrapper : Countable<Plant>
{
    public static StringInventory stringsInventory;
    public PlantWrapper(Plant plant, int stock) : base(stock) {
        this.data = plant;
    }

    public override bool UseStock() {
        bool noneLeft = base.UseStock();
        Strings convertedString = PlantConverter.ConvertPlantToString(data);
        stringsInventory.AddExistingItem(convertedString);
        return noneLeft;
    }

    public string GetPlantName() {
        return data.plantName;
    }

    public float GetPlantTension() {
        return data.tension;
    }

    public Sprite GetPlantSprite() {
        return data.plantSprite;
    }
}
