using UnityEngine;

public class PlantWrapper : Countable<Plant>
{
    public static Inventory<StringWrapper, Strings> stringsInventory;
    public static PlantConverter plantConverter;

    public PlantWrapper() : base() {}
    
    public PlantWrapper(Plant plant, int stock) : base(plant, stock) {}

    public override bool UseStock() {
        bool noneLeft = base.UseStock();
        Strings convertedString = plantConverter.ConvertPlantToString(data);
        stringsInventory.AddItem(convertedString);
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
