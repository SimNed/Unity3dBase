using UnityEngine;
using UnityEngine.Events;

public class GameCameraProvider : MonoBehaviour
{
    [SerializeField] private GameCameraProviderSubscriptionEventChannelSO gameCameraProviderSubscriptionEventChannel;    
    [SerializeField] private GameCamera currentGameCamera;

    public UnityAction<GameCamera> OnGameCameraChanged;

    public void RaiseEvent(GameCamera gameCamera)
    {
        OnGameCameraChanged?.Invoke(gameCamera);
    }

    private void OnEnable()
    {
        gameCameraProviderSubscriptionEventChannel.OnEventRaised += SetCurrentGameCamera;
    }

    private void OnDisable()
    {
        gameCameraProviderSubscriptionEventChannel.OnEventRaised -= SetCurrentGameCamera;
    }

    private void SetCurrentGameCamera(GameCamera gameCamera)
    {
        this.currentGameCamera = gameCamera;
        RaiseEvent(gameCamera);
    }
}

