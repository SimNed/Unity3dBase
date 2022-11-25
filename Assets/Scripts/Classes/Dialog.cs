using UnityEngine;

[System.Serializable]

public class Dialog
{
    [field: SerializeField] public TextAsset TextFile { get; private set; }
    [field: SerializeField] public bool IsSayingOnce { get; private set; }
}