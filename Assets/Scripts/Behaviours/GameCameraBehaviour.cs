using UnityEngine;

public class GameCameraBehaviour : MonoBehaviour
{
    private GameCamera gameCamera;

    [SerializeField] private Broadcaster<GameCamera> broadcaster; 

    private void Awake()
    {
        gameCamera = GetComponent<GameCamera>();
    }

    private void Start()
    {
        broadcaster.Broadcast(gameCamera);
    }
}
