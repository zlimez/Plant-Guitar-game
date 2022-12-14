using UnityEngine;

public class GuitarAssembly : Guitar
{
    public static Inventory<StringWrapper, Strings> stringsInventory;
    public GameEvent prepareToAddString;
    public GameEvent prepareToRemoveString;
    public GameEvent allStringsAssigned;
    public GameEvent guitarNotReady;
    public int selectedString = -1;
    public int numOfAssignedStrings = 0;
    
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
        if (++numOfAssignedStrings == numOfStrings) {
            allStringsAssigned.TriggerEvent();
        }
        // A string is attached at this index since not deselected it can be removed again.
        prepareToRemoveString.TriggerEvent();
    }

    public void RemoveString() {
        Debug.Log("Removing " + selectedString);
        Strings removedString = strings[selectedString];
        stringsInventory.AddItem(removedString);
        strings[selectedString] = null;
        if (numOfAssignedStrings-- == numOfStrings) {
            guitarNotReady.TriggerEvent();
        }
        prepareToAddString.TriggerEvent();
        stringObjects[selectedString].GetComponent<StringPlucker>().RemoveString();
    }

    // Triggered by scene change to main stage
    public void SaveGuitarConfig() {
        GameManager.instance.SaveGuitarConfig(this);
    }
}
