using System;
using UnityEngine;


public class Health : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] private int maxHealth = 100;
    
    // Declaring a event as a field (this announces to listeners).
    public event Action OnDeath;
    
    void Awake()
    {
        // Sets the current health
        currentHealth = maxHealth;
    }
    
    // Function that applies damage to specific user + checks if the current health reaches 0.
    public void Hit(int damage)
    {
        // Checks if the current health is already 0.
        if (currentHealth <= 0)
        {
            return;
        }
        
        // Deal damage to the health.
        currentHealth -= damage;
        
        // Check if the health has reached 0 or lower after getting dealt damage.
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath?.Invoke();
        }
    }
}
