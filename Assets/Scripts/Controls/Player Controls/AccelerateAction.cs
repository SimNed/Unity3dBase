using UnityEngine;

public class AccelerateAction : PlayerControls
{
    private void Start()
    {
        Action = CurrentPlayerInput.actions["Accelerate"];
        
        Action.started += ctx => ProcessAction();
        Action.canceled += ctx => CancelAction();
    }

    private void ProcessAction()
    {
        CurrentPlayer.CurrentSpeed = CurrentPlayerStats.FastSpeed;
        CurrentPlayerAnimator.SetBool("isAccelerating", true);
    }

    private void CancelAction()
    {
        CurrentPlayer.CurrentSpeed = CurrentPlayerStats.DefaultSpeed;
        CurrentPlayerAnimator.SetBool("isAccelerating", false);
    }
}
