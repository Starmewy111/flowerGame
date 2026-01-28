using UnityEngine;
using UnityEngine.InputSystem;

public class InteractController : MonoBehaviour
{

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            //interact
        }
    }
}
