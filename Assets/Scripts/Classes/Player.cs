using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerStatsSO PlayerStats { get; private set; }
    
    public float CurrentSpeed { get; set; }
    public float CurrentRotationSpeed { get; set; }
}