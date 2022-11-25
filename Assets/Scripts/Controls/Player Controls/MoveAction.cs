using UnityEngine;

public class MoveAction : PlayerControls
{
    private GameCamera referentialGameCamera;

    [SerializeField] GameCameraProvider gameCameraProvider;

    protected override void OnEnable()
    {
        base.OnEnable();
        gameCameraProvider.OnGameCameraChanged += SetReferentialGameCamera;
    } 

    private void Start()
    {
        Action = CurrentPlayerInput.actions["Move"];
    }

    private void FixedUpdate()
    {
        this.ProcessAction(Action.ReadValue<Vector3>());
    }

    private void ProcessAction(Vector3 direction)
    {    
        
        CurrentPlayerAnimator.SetBool("isMoving", direction != Vector3.zero);

        if(direction != Vector3.zero)
        {
            direction = Quaternion.AngleAxis(referentialGameCamera.transform.eulerAngles.y, Vector3.up) * direction * Time.fixedDeltaTime;
            
            Quaternion rotation = Quaternion.LookRotation(direction);
            rotation = Quaternion.RotateTowards(CurrentPlayerRigidBody.rotation, rotation, CurrentPlayer.CurrentRotationSpeed * Time.fixedDeltaTime);
            
            CurrentPlayerRigidBody.MovePosition(CurrentPlayerRigidBody.position + direction.normalized * CurrentPlayer.CurrentSpeed * Time.fixedDeltaTime);
            CurrentPlayerRigidBody.MoveRotation(rotation);
        }
    }

    private void SetReferentialGameCamera(GameCamera gameCamera)
    {
        referentialGameCamera = gameCamera;
    } 
}
