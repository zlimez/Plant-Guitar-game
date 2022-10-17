using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Weakness weakness;
    public Health health;
    public float movingSpeed;
    
    void Start() {
        health = GetComponent<Health>();
    }

    void Update() {
        // Move downwards
        transform.position += new Vector3(0, movingSpeed, 0) * Time.deltaTime;
    }

    void reactToChord() {
        if (LevelManager.CHORD_PLAYED == weakness.majorWeakness) {
            health.deductHealth(weakness.majorHealthDeduction);
        } else if (LevelManager.CHORD_PLAYED == weakness.minorWeakness) {
            health.deductHealth(weakness.minorHealthDeduction);
        }
    }
}
