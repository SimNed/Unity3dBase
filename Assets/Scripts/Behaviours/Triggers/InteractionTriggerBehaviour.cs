using UnityEngine;

public class InteractionTriggerBehaviour : MonoBehaviour
{
    private IInteractable interaction;

    [SerializeField] private Broadcaster<IInteractable> broadcaster;

    private void Awake()
    {
        interaction = GetComponentInParent<IInteractable>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Player>())
            broadcaster.Broadcast(interaction);
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.GetComponent<Player>())
            broadcaster.Broadcast();
    }

    private void OnDisable()
    {
        broadcaster.Broadcast();
    }
}