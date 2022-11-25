using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private InteractionManagerSubscriptionEventChannelSO interactionManagerSubscriptionEventChannel;
    
    public IInteractable currentInteraction;

    private void OnEnable()
    {
        interactionManagerSubscriptionEventChannel.OnEventRaised += SetCurrentInteraction;
    }

    private void OnDisable()
    {
        interactionManagerSubscriptionEventChannel.OnEventRaised -= SetCurrentInteraction;
    }

    private void SetCurrentInteraction(IInteractable interaction)
    {
        this.currentInteraction = interaction;
    }

    public IInteractable GetCurrentInteraction()
    {
        return this.currentInteraction;
    } 
}
