using UnityEngine;

public class PlayableCameraBehaviour : MonoBehaviour
{
    private PlayableCamera playableCamera;

    [SerializeField] private Broadcaster<GameCamera> broadcaster;
    
    private Rigidbody rigidbody;
    private Rigidbody target;

    private Vector3 offsetCameraPosition;
    private Vector3 offsetCameraRotation;

    private void Awake()
    {
        playableCamera = GetComponent<PlayableCamera>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = playableCamera.Target;

        offsetCameraPosition = playableCamera.OffsetPosition;
        offsetCameraRotation = playableCamera.OffsetRotation;

        broadcaster.Broadcast(playableCamera);
    }

    private void FixedUpdate()
    { 
        rigidbody.position = target.position;
    }
}