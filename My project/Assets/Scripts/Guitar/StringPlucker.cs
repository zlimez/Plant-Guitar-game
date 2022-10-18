using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPlucker : MonoBehaviour
{
    public AudioSource amp;
    public SpriteRenderer stringRenderer;
    private Strings thisString;

    public void PlayNote() {
        amp.PlayOneShot(thisString.clip);
        thisString.NotePlayed.TriggerEvent();
    }

    public void AssignString(Strings assignedString) {
        this.thisString = assignedString;
        stringRenderer.sprite = assignedString.image;
    }

    public void RemoveString() {
        this.thisString = null;
        stringRenderer.sprite = null;
    }
}
