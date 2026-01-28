using System;
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

        if (_rb == null)
            throw new Exception($"Rigid body does not exist! {gameObject.name}");
    }
    

    public void Movement(InputAction.CallbackContext ctx)
    { 
        Vector2 dir = ctx.ReadValue<Vector2>();
        _rb.linearVelocity = dir * _movementSpeed;
    }
}
