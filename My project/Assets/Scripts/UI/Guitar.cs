using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : MonoBehaviour
{
    public AudioSource amp;
    public Strings[] strings;

    public void AddString(int index, Strings guitarString) {
        strings[index] = guitarString;
    }

    public void RemoveString(int index) {
        strings[index] = null;
    }

    public void PlayString(int index) {
        if (strings[index] == null) {
            // No string at the tapped position
        } else {
            amp.PlayOneShot(strings[index].clip);
            strings[index].NotePlayed.TriggerEvent();
        }
    }
}
