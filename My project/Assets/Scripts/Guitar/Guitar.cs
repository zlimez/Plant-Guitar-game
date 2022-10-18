using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : MonoBehaviour
{
    // The field is by right not necessary only to make null check in PlayString more convenient
    public Strings[] strings;
    public GameObject[] stringObjects;

    void Update() {
        // As for now, 1 to 3 then 8-0 on keyboard is mapped to playing strings 1 to 6
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            PlayString(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            PlayString(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            PlayString(2);
        } 
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            PlayString(3);
        } 
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            PlayString(4);
        } 
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            PlayString(5);
        }
    }

    public void PlayString(int index) {
        if (strings[index] == null) {
            // No string at the tapped position
        } else {
            stringObjects[index].GetComponent<StringPlucker>().PlayNote();
        }
    }
}
