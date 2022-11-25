using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Player player;
    
    [SerializeField] private Broadcaster<Player> broadcaster;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        PlayerStatsSO playerStats = player.PlayerStats;

        player.CurrentSpeed = playerStats.DefaultSpeed;
        player.CurrentRotationSpeed = playerStats.DefaultRotationSpeed;

        broadcaster.Broadcast(player);
    }
}
