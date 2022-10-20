using UnityEngine;

public class Health : MonoBehaviour
{
    public GameEvent death;
    public float health;

    public void deductHealth(float amount) {
        health = Mathf.Max(health -= amount, 0);
        if (health == 0) {
            // death.TriggerEvent();
            if (gameObject.CompareTag("Enemy")) {
                Destroy(gameObject);
            }
        }
    }
}
