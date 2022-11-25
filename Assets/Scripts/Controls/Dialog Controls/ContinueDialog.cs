using UnityEngine;

public class ContinueDialog : DialogControls
{
    private void Start()
    {
        Action = CurrentPlayerInput.actions["ContinueDialog"];
        
        Action.started += ctx => ProcessAction();
    }

    private void ProcessAction()
    {
        DialogManager.ContinueDialog();
    }
}
