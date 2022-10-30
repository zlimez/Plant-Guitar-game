using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Used to configure the string item GUI in inventory
public class StringItem : MonoBehaviour
{
    // Altered by prepareToAddString Game Event
    public static Inventory<StringWrapper, Strings> stringInventory;
    public TextMeshProUGUI info;
    public StringWrapper wrappedString;
    public Image stringRenderer;

    public void AssignString(StringWrapper wrappedString) {
        stringRenderer.sprite = wrappedString.GetStringIcon();
        info.SetText(wrappedString.GetStringName() + ": " + wrappedString.stock);
        this.wrappedString = wrappedString;
    }

    // Triggered by OnClick()
    public void ApplyString() {
        Debug.Log("Tries to apply string");
        if (InventoryManager.isAddStringState) {
            Debug.Log("Can apply string");
            stringInventory.UseExistingItem(wrappedString.data);
        }
    }
}
