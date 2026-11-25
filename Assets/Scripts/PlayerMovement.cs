
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Initalizing variables
    [SerializeField] private float moveSpeed = 5f;

    private CharacterController controller;

    private InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Get the CharacterController attached to this GameObject
        controller = GetComponent<CharacterController>();
        // Find the "Move" action from the project-wide input actions
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // Read the Move actions current value as Vector2
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        // Build a Vector3 direction on the floor (X and Z), with Y = 0
        Vector3 direction = new Vector3(moveValue.x, 0, moveValue.y);
        // Scale it by moveSpeed and Time.deltaTime
        Vector3 movement = direction * (moveSpeed * Time.deltaTime);
        // Pass the result to the CharacterController to move
        controller.Move(movement);
        
        // Only rotate if the direction isn't zero (look up Vector3.sqrMagnitude or compare against Vector3.zero)
        if (direction != Vector3.zero)
        {
            // Turn the direction into a rotation with Quaternion.LookRotation
            Quaternion turnRotate = Quaternion.LookRotation(direction);
            
            // Set transform.rotation to that rotation
            transform.rotation = turnRotate;
        }
    }
}
