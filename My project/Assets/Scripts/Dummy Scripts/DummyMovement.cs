using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2) transform.position + Vector2.down * Time.deltaTime;
    }
}
