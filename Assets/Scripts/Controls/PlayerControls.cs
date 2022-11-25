using UnityEngine;

public abstract class PlayerControls : Controls
{
    [SerializeField] private PlayerControlsSubscriptionEventChannelSO playerControlsSubscriptionEventChannel;

    protected Player CurrentPlayer { get; private set; }
    
    protected Transform CurrentPlayerTransform { get; private set; }
    protected Rigidbody CurrentPlayerRigidBody { get; private set; }
    protected Animator CurrentPlayerAnimator { get; private set; }
    
    protected PlayerStatsSO CurrentPlayerStats { get; private set; }

    protected virtual void OnEnable()
    {
        playerControlsSubscriptionEventChannel.OnEventRaised += SetCurrentPlayerReferences;
    }

    private void SetCurrentPlayerReferences(Player player)
    {
        CurrentPlayer = player;
        
        CurrentPlayerTransform = player.transform;
        CurrentPlayerRigidBody = player.GetComponent<Rigidbody>();
        CurrentPlayerAnimator = player.GetComponent<Animator>();
        
        CurrentPlayerStats = player.PlayerStats;
    }
}