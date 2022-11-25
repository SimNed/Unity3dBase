using UnityEngine;

public class PlayableCamera : GameCamera
{
	[field: SerializeField] public Rigidbody Target { get; private set; }

	[field: SerializeField] public float SensitivityX { get; private set; }
	[field: SerializeField] public float SensitivityY { get; private set; }
}
