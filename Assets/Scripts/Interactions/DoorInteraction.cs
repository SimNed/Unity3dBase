using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void Interact()
    {
        bool doorState = animator.GetBool("isOpen");
        animator.SetBool("isOpen", !doorState);
    }
}