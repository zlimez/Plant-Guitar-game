public class GuitarAssembly : Guitar
{
    public GameEvent prepareToAddString;
    public GameEvent prepareToRemoveString;
    public int selectedString = -1;
    
    public void SelectString(int index) {
        selectedString = index;
        if (stringObjects[selectedString] == null) {
            prepareToAddString.TriggerEvent();
        } else {
            prepareToRemoveString.TriggerEvent();
        }
    }

    public void AddString(Strings guitarString) {
        strings[selectedString] = guitarString;
        stringObjects[selectedString].GetComponent<StringPlucker>().AssignString(guitarString);
        // Deselect
        selectedString = -1;
    }

    public void RemoveString() {
        strings[selectedString] = null;
        stringObjects[selectedString].GetComponent<StringPlucker>().RemoveString();
    }
}
