using UnityEngine;

public class RotateCameraAction : PlayableCameraControls
{
    private float yRotation;
    private float xRotation;

    private void Start()
    {
        Action = CurrentPlayerInput.actions["RotateCamera"];
    }

    private void FixedUpdate()
    {
        this.ProcessAction(Action.ReadValue<Vector3>());
    }

    private void ProcessAction(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            float yRotationValue = direction.x * PlayableCameraSensitivityX * Time.deltaTime;
            float xRotationValue = direction.y * PlayableCameraSensitivityY * Time.deltaTime;
   
            yRotation += yRotationValue;
            xRotation = Mathf.Clamp(xRotation - xRotationValue, -40, 40);

            PlayableCameraRigidbody.MoveRotation(Quaternion.Euler(xRotation, yRotation, 0));   
        }
    }
}










































     /*
                Quaternion addRotation = Quaternion.Euler(direction.y, direction.x, 0);
                currentGameCamera.transform.rotation = targetRotation * addRotation;
        */
            /*
            float yRotationValue = direction.x * _currentGameCameraConfig.GetSensitivity() * Time.deltaTime;
            float xRotationValue = direction.y * _currentGameCameraConfig.GetSensitivity() * Time.deltaTime;
   
            yRotation += yRotationValue;
            xRotation -= xRotationValue;

            _currentGameCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);    
            */