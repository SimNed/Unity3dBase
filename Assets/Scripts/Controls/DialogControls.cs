using UnityEngine;

public abstract class DialogControls : Controls
{
    [field: SerializeField] protected DialogManager DialogManager { get; private set; }
}