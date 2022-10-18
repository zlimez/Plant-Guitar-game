using UnityEngine;

[CreateAssetMenu(menuName="Plant")]
public class Plant : ScriptableObject
{
    public string plantName;
    public float tension;
    // The note of the string made with this plant
    public Notes note;
    public int stockCount;

    public int AddToStock() {
        this.stockCount += 1;
        return this.stockCount;
    }

    public int UseStock() {
        if (this.stockCount == 0) {
            // Inform the user the plant has been used up
        } else {
            // Make the corresponding string
            this.stockCount -= 1;
        }
        return this.stockCount;
    }
}
