
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // initalizing variables
    [SerializeField] private float moveSpeed = 5f;

    private CharacterController controller;

    private InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // TODO: get the CharacterController attached to this GameObject
        controller = GetComponent<CharacterController>();
        // TODO: find the "Move" action from the project-wide input actions
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: read the Move actions current value as Vector2
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        // TODO: build a Vector3 direction on the floor (X and Z), with Y = 0
        Vector3 direction = new Vector3(moveValue.x, 0, moveValue.y);
        // TODO: scale it by moveSpeed and Time.deltaTime
        Vector3 movement = direction * (moveSpeed * Time.deltaTime);
        // TODO: pass the result to the CharacterController to move
        controller.Move(movement);
        
        // TODO: only rotate if the direction isn't zero (look up Vector3.sqrMagnitude or compare against Vector3.zero)
        if (direction != Vector3.zero)
        {
            // TODO: turn the direction into a rotation with Quaternion.LookRotation
            Quaternion turnRotate = Quaternion.LookRotation(direction);
            
            // TODO: set transform.rotation to that rotation
            transform.rotation = turnRotate;
        }
    }
}
