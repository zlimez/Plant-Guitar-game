using System;
using UnityEngine;

public class Alien : MonoBehaviour
{
    // Every alien has a unique weakness
    public Weakness weakness;
    public float attackStats;
    public Health health;
    
    void Start() {
        health = GetComponent<Health>();
    }

    public void reactToAttack(bool isMajor) {
        // Debug.Log(gameObject.name + " health deducted");
        if (isMajor) {
            health.deductHealth(weakness.majorHealthDeduction);
        } else {
            health.deductHealth(weakness.minorHealthDeduction);
        }
    }

    void OnTriggerEnter2D(Collider2D obj) {
        // Debug.Log(obj.name + " collided");
        if (obj.CompareTag("Player")) {
            Destroy(gameObject);
            obj.GetComponent<Health>().deductHealth(attackStats);
        }
    }

    public override string ToString()
    {
        return String.Format("Alien weakness: {0}, attack: {1}", weakness, attackStats);
    }
}
