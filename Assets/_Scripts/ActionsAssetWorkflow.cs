using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class ActionsAssetWorkflow : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float moveSpeed = 5;
    [SerializeField] private InputActionAsset actions;
    
    private Rigidbody2D _rigidbody2D;
    private InputAction _moveAction;
    private Vector3 _movement;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _moveAction = actions.FindActionMap("gameplay").FindAction("movement");
    }

    void Update()
    {
        _movement = _moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + (_movement * moveSpeed));
    }

    void OnEnable()
    {
        actions.FindActionMap("gameplay").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("gameplay").Disable();
    }
}
