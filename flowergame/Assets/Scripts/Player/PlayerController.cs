using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    public Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    

    public void Movement(InputAction.CallbackContext ctx)
    { 
        Vector2 dir = ctx.ReadValue<Vector2>();
        _rb.linearVelocity = dir * _movementSpeed;
            
    }
}
