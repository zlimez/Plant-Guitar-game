using UnityEngine;

public class PinSelection : MonoBehaviour
{
    public int index;
    public GuitarAssembly assembly;
    
    void OnMouseDown() {
        Debug.Log("Pin " + index + " selected");
        assembly.SelectString(index);
    }
}
