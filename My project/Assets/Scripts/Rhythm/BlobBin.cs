using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log(obj.name + " should be recycled");
        if (obj.CompareTag("Blob")) {
            Destroy(obj.gameObject);
        }
    }
}
