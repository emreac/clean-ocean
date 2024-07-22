using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI Slider
    public float maxHealth = 100f; // Maximum health value
    private float currentHealth; // Current health value

    void Start()
    {
        // Initialize health values
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthSlider.value = currentHealth;

        if (currentHealth <= 0f)
        {
            // Handle player death
            Debug.Log("Player is dead!");
            // Implement death logic here (e.g., respawn, game over screen, etc.)
        }
    }

    // Method to heal
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthSlider.value = currentHealth;
    }

    // Method to set health (useful for starting health, respawns, etc.)
    public void SetHealth(float health)
    {
        currentHealth = health;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthSlider.value = currentHealth;
    }
}
