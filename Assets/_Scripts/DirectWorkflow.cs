using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectWorkflow : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed = 5;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _movement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null)
        {
            print("Keyboard was null");
            return;
        }

        HandleMovement(keyboard);
    }

    void FixedUpdate()
    {
        if (_movement != Vector3.zero)
        {
            _rigidbody2D.MovePosition(transform.position + _movement);
        }
    }

    private void HandleMovement(Keyboard keyboard)
    {
        _movement = GetDirection(keyboard);
    }

    private Vector3 GetDirection(Keyboard keyboard)
    {
        if (keyboard.wKey.isPressed)
        {
            Vector3 upwardMovement = Vector3.up * moveSpeed;
            if (keyboard.aKey.isPressed)
            {
                return Vector3.left * moveSpeed + upwardMovement;        
            } else if (keyboard.dKey.isPressed)
            {
                return Vector3.right * moveSpeed + upwardMovement;            
            }            
            
            return upwardMovement;
        }
        
        if (keyboard.sKey.isPressed)
        {
            Vector3 downwardMovement = Vector3.down * moveSpeed;
            if (keyboard.aKey.isPressed)
            {
                return Vector3.left * moveSpeed + downwardMovement;        
            }
            else if (keyboard.dKey.isPressed)
            {
                return Vector3.right * moveSpeed + downwardMovement;            
            }         
            
            return downwardMovement;            
        }
        
        if (keyboard.aKey.isPressed)
        {
            return Vector3.left * moveSpeed;        
        }
        
        if (keyboard.dKey.isPressed)
        {
            return Vector3.right * moveSpeed;            
        }

        return Vector3.zero;
    }
}
