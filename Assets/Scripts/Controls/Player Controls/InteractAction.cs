using UnityEngine;

public class InteractAction : Controls
{
    [SerializeField] private InteractionManager interactionManager;
    
    private void Start()
    {
        Action = CurrentPlayerInput.actions["Interact"];
        
        Action.started += ctx => ProcessAction();
    }

    private void ProcessAction()
    {   
        if (interactionManager.GetCurrentInteraction() != null)
            interactionManager.GetCurrentInteraction().Interact();
    }
}
