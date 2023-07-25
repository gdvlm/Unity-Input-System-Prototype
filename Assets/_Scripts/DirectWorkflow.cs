using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectWorkflow : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed = 5;

    private Rigidbody2D _rigidbody2D;

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

    private void HandleMovement(Keyboard keyboard)
    {
        Vector3 movement = GetDirection(keyboard);
        _rigidbody2D.MovePosition(transform.position + movement);
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
