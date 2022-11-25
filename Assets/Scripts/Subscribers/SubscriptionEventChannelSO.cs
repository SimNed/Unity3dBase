using UnityEngine;
using UnityEngine.Events;

public class SubscriptionEventChannelSO<T> : ScriptableObject
{
    public UnityAction<T> OnEventRaised;

    public void RaiseEvent(T t = default(T))
    {
        OnEventRaised?.Invoke(t);
    }
}
