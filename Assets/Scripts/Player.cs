using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private Health health;
    // This function is ran immediately, instead of being ran once this script is called.
    private void Awake()
    {
        // TODO: get the Health component
        health = GetComponent<Health>();
        
        // TODO: subscribe to Health's death event with a method below

    }

    // Destroys player and r
    private void OnDestory()
    {
        // TODO: unsubscribe from health death event
    }
    
    // handles player death
    private void HandleDeath()
    {
        
    }
}
