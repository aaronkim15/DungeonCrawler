using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    
    private Health health;
    // This function is run the moment the player object is loaded into the scene
    private void Awake()
    {
        // Get the Health component
        health = GetComponent<Health>();
        
        // Subscribe (add) to Health's death event with a method below
        health.OnDeath += HandleDeath;
    }

    // Deletes the HandleDeath method from the OnDeath event.
    private void OnDestroy()
    {
        // Unsubscribe from health death event
        health.OnDeath -= HandleDeath; 
    }
    
    // Handles player death
    private void HandleDeath()
    {
        // Loads the 'SampleScene' scene using SceneManager
        SceneManager.LoadScene("Testing_Sandbox");
        
    }

    void Update()
    {
       
    }
}
