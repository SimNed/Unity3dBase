using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [field: SerializeField] public Vector3 OffsetPosition { get; private set; }
    [field: SerializeField] public Vector3 OffsetRotation { get; private set; }
}
