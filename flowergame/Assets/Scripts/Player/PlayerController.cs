using System;
using Library;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _interactingSpeed;
    public float currentSpeed{get; private set;}
    public Vector2 dir {get; private set;}
    
    public bool isInteracting;
    
    public Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (_rb == null)
            throw new Exception($"Rigid body does not exist! {gameObject.name}");
    }
    

    public void Movement(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            dir = ctx.ReadValue<Vector2>();
        }
        else
        {
            dir = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        currentSpeed = isInteracting ? _interactingSpeed : _movementSpeed;
        _rb.linearVelocity = dir * currentSpeed;
    }
    
    public void IsInteracting() => isInteracting = helpers.FlipFlop(isInteracting);
}
