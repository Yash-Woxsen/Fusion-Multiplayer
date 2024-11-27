using UnityEngine;
using Fusion;

public class ThirdPersonCamera : NetworkBehaviour
{
    public Transform cameraPivot;
    public Transform cameraHandle;
    private Vector2 LookRotation;

    void LateUpdate()
    {
        if(HasStateAuthority == false)
            return;
        

        Vector2 lookRotationDelta = new Vector2(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"));
        LookRotation = ClampLookRotation(LookRotation + lookRotationDelta);
        cameraPivot.rotation = Quaternion.Euler(LookRotation);

        Camera.main.transform.SetPositionAndRotation(cameraHandle.position, cameraHandle.rotation);
    }

    private Vector2 ClampLookRotation(Vector2 lookRotation)
    {
        lookRotation.x = Mathf.Clamp(lookRotation.x, -30f, 70f);
        return lookRotation;
    }
}


