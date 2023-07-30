using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class EmbeddedActionsWorkflow : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed = 5;
    [SerializeField] private InputAction moveAction;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _movement;
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _movement = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + (_movement * moveSpeed));
    }

    public void OnEnable()
    {
        moveAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
    }
}
