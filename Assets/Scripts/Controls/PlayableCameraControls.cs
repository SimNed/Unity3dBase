using UnityEngine;

public class PlayableCameraControls : Controls
{
    [field: SerializeField] protected PlayableCamera PlayableCamera { get; private set; }
    [field: SerializeField] private GameCameraProvider GameCameraProvider { get; set; }

    protected Rigidbody PlayableCameraRigidbody { get; private set; }

    protected float PlayableCameraSensitivityX { get; private set; }
    protected float PlayableCameraSensitivityY { get; private set; }

    private void OnEnable()
    {
        GameCameraProvider.OnGameCameraChanged += SetPlayableCameraReferences;
    }

    private void SetPlayableCameraReferences(GameCamera playableCamera)
    {
        PlayableCamera = playableCamera as PlayableCamera;
        PlayableCameraRigidbody = PlayableCamera.GetComponent<Rigidbody>();

        PlayableCameraSensitivityX = PlayableCamera.SensitivityX;
        PlayableCameraSensitivityY = PlayableCamera.SensitivityY;
    }
}
