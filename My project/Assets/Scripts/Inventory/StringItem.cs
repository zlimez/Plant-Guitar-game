using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Used to configure the string item GUI in inventory
public class StringItem : MonoBehaviour
{
    // This item's index in the inventory for deletion and addition purpose
    public int index;
    public TextMeshPro stringName;
    public TextMeshPro stock;
    public Image stringRenderer;
    public void AssignString(StringWrapper wrappedString) {
        stringRenderer.sprite = wrappedString.GetStringSprite();
        stock.SetText("Stock: " + wrappedString.stock);
        stringName.SetText(wrappedString.GetStringName());
    }
}
