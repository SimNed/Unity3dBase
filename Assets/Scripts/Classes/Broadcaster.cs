using UnityEngine;

[System.Serializable]

public class Broadcaster<T>
{
    [SerializeField] private SubscriptionEventChannelSO<T> subscriptionEventChannel;

    public void Broadcast(T t = default(T))
    {
        subscriptionEventChannel.RaiseEvent(t);
    }
}