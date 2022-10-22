using UnityEngine;

public class Health : MonoBehaviour
{
    public GameEvent death;
    public float health;
    public HealthBar healthBar;

    void Start() {
        if (healthBar != null) {
            healthBar.SetMaxValue(health);
            healthBar.SetValue(health);
        }
    }

    public void deductHealth(float amount) {
        health = Mathf.Max(health -= amount, 0);
        if (healthBar != null)
        healthBar.SetValue(health);
        if (health == 0) {
            // death.TriggerEvent();
            if (gameObject.CompareTag("Enemy")) {
                Destroy(gameObject);
            }
        }
    }
}
