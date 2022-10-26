using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Should eventually be dynamically generated from user input.
// Made as scriptable object to easily create dummy data.
[CreateAssetMenu(menuName = "Plant")]
public class Plant : ScriptableObject
{
    public string plantName;
    public float tension;
    // The note of the string made with this plant
    public Sprite plantSprite;

    public override bool Equals(object other) {
        if ((other == null) || ! this.GetType().Equals(other.GetType())) {
            return false;
        } else {
            Plant otherPlant = (Plant) other;
            return this.plantName == otherPlant.plantName;
        }
    }

    public override int GetHashCode() {
        return plantName.GetHashCode();
    }
}
