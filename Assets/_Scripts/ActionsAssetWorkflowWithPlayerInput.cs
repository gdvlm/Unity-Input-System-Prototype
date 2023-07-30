using UnityEngine;
using UnityEngine.InputSystem;

public class ActionsAssetWorkflowWithPlayerInput : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed = 5;
    
     private Rigidbody2D _rigidbody2D;
     private Vector3 _movement;    
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + (_movement * moveSpeed));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
}
