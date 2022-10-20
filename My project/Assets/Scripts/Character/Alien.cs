using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Weakness weakness;
    public float attackStats;
    public Health health;
    
    void Start() {
        health = GetComponent<Health>();
    }

    public void reactToAttack(bool isMajor) {
        Debug.Log(gameObject.name + " health deducted");
        if (isMajor) {
            health.deductHealth(weakness.majorHealthDeduction);
        } else {
            health.deductHealth(weakness.minorHealthDeduction);
        }
    }

    void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log(obj.name + " collided");
        if (obj.CompareTag("Player")) {
            Destroy(gameObject);
            obj.GetComponent<Health>().deductHealth(attackStats);
        }
    }
}
