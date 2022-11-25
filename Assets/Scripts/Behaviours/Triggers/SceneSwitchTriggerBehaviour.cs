using UnityEngine;

public class SceneSwitchTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private string destinationSceneName;

    [SerializeField] private Broadcaster<string> broadcaster;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Player>())
            broadcaster.Broadcast(destinationSceneName);
    }
}