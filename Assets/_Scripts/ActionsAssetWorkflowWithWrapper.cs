using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ActionsAssetWorkflowWithWrapper : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed = 5;
    
    private Rigidbody2D _rigidbody2D;
    private InputActions _inputActions;
    private Vector3 _movement;

    void Awake()
    {
        _inputActions = new InputActions();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _movement = _inputActions.gameplay.movement.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + (_movement * moveSpeed));
    }

    void OnEnable()
    {
        _inputActions.gameplay.Enable();
    }

    void OnDisable()
    {
        _inputActions.gameplay.Disable();
    }
}
