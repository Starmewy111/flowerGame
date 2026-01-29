using System;
using System.Collections.Generic;
using Interfaces;
using Library;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class InteractController : MonoBehaviour
{ 
    [SerializeField] private Transform _target;
    [SerializeField] private LayerMask _interactableLayers;
    [SerializeField] private Vector2 _interactArea;

    [SerializeField] private UnityEvent _onInteract;
    
    public Collider2D[] interactableObjects { get; private set; }
    private bool inRange;

    private void Awake()
    {
        if(_target == null)
            throw new Exception($"{nameof(InteractController)} requires a target GameObject");
    }
    
    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Vector2 currentPos = transform.position;
            interactableObjects = Physics2D.OverlapAreaAll(currentPos - _interactArea, currentPos + _interactArea, _interactableLayers);
            
            Transform[] objectDistances = new Transform[interactableObjects.Length];
            for (int i = 0; i < interactableObjects.Length; i++)
            {
                objectDistances[i] = interactableObjects[i].transform;
            }
            
            Transform interacted = helpers.ClosestToTarget(_target, objectDistances);
            
            if (interacted == null)
                throw new Exception("No interactable object found");
            
            interacted.GetComponent<IInteractable>().Interact()?.Invoke();
            _onInteract?.Invoke();
        }
    }
    
    private void OnDrawGizmos()
    {
        Vector2 currentPos = transform.position;
        Vector3 from = currentPos - _interactArea;
        Vector3 to = currentPos + _interactArea;

        //Gizmos.color;
        Gizmos.DrawLine(from, new Vector3(to.x, from.y));
        Gizmos.DrawLine(new Vector3(to.x, from.y), to);
        Gizmos.DrawLine(to, new Vector3(from.x, to.y));
        Gizmos.DrawLine(new Vector3(from.x, to.y), from);
        Gizmos.DrawLine(from, to);
    }
}
