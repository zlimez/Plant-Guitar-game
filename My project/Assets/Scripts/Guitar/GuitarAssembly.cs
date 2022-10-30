public class GuitarAssembly : Guitar
{
    public GameEvent prepareToAddString;
    public GameEvent prepareToRemoveString;
    public int selectedString = -1;
    
    public void SelectString(int index) {
        selectedString = index;
        if (strings[selectedString] == null) {
            prepareToAddString.TriggerEvent();
        } else {
            prepareToRemoveString.TriggerEvent();
        }
    }

    public void AddString(Strings guitarString) {
        strings[selectedString] = guitarString;
        stringObjects[selectedString].GetComponent<StringPlucker>().AssignString(guitarString);
        // A string is attached at this index since not deselected it can be removed again.
        prepareToRemoveString.TriggerEvent();
    }

    public Strings RemoveString() {
        strings[selectedString] = null;
        prepareToAddString.TriggerEvent();
        return stringObjects[selectedString].GetComponent<StringPlucker>().RemoveString();
    }
}
