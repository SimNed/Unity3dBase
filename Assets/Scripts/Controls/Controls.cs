using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Controls : MonoBehaviour
{
    protected PlayerInput CurrentPlayerInput { get; private set; }
    protected InputAction Action { get; set; }

    private void Awake()
    {
        CurrentPlayerInput = GetComponentInParent<PlayerInput>();
    }
}
