using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPlucker : MonoBehaviour
{
    public AudioSource amp;
    public SpriteRenderer stringRenderer;
    public Strings thisString;

    public void PlayNote() {
        amp.PlayOneShot(thisString.clip);
        thisString.NotePlayed.TriggerEvent();
    }

    public void AssignString(Strings assignedString) {
        this.thisString = assignedString;
        stringRenderer.sprite = assignedString.image;
    }

    public void RemoveString() {
        if (this.thisString == null) {
            Debug.Log("An empty string should not be able to be removed");
        }
        this.thisString = null;
        stringRenderer.sprite = null;
    }
}
