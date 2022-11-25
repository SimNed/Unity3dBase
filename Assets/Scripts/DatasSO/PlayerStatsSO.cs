using UnityEngine;

[CreateAssetMenu(fileName="PlayerStats", menuName="Scriptable Object/Stats/Player Stats")]

public class PlayerStatsSO : ScriptableObject
{
    [field: SerializeField] public float DefaultSpeed { get; set; }
    [field: SerializeField] public float FastSpeed { get; set; }
    [field: SerializeField] public float SlowSpeed { get; set; }
    
    [field: SerializeField] public float DefaultRotationSpeed { get; set; }
}
