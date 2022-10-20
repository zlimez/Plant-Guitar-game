using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serves to check that whether the chord is played in an "effective interval".
public class ChordRelay : MonoBehaviour
{
    public bool inBlob;

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.CompareTag("Blob")) {
            inBlob = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj) {
        if (obj.CompareTag("Blob")) {
            inBlob = false;
        }
    }

    public void RelayChordEvent(GameEvent effectiveChordPlayed) {
        if (inBlob) {
            effectiveChordPlayed.TriggerEvent();
        }
    }
}
