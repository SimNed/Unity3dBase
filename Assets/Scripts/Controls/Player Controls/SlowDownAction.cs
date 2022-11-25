using UnityEngine;

public class SlowDownAction : PlayerControls
{
    private void Start()
    {
        Action = CurrentPlayerInput.actions["SlowDown"];

        Action.started += ctx => ProcessAction();
        Action.canceled += ctx => CancelAction();
    }

    private void ProcessAction()
    {
        CurrentPlayer.CurrentSpeed = CurrentPlayerStats.SlowSpeed;
        CurrentPlayerAnimator.SetBool("isSlowDown", true);
    }

    private void CancelAction()
    {
        CurrentPlayer.CurrentSpeed = CurrentPlayerStats.DefaultSpeed;
        CurrentPlayerAnimator.SetBool("isSlowDown", false);
    }
}