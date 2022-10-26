using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Used to configure the string item GUI in inventory
public class StringItem : MonoBehaviour
{
    public TextMeshProUGUI info;
    public Image stringRenderer;

    public void AssignString(StringWrapper wrappedString) {
        stringRenderer.sprite = wrappedString.GetStringSprite();
        info.SetText(wrappedString.GetStringName() + ": " + wrappedString.stock);
    }
}
