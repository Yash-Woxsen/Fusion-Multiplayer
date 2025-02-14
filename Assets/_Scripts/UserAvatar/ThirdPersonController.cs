using UnityEngine;
using Fusion;
public class ThirdPersonController : NetworkBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked; 
            Cursor.visible = Cursor.lockState == CursorLockMode.None;
        }
    }
    public Transform green;
    public float rotationSpeed = 10f; // 
    public float moveSpeed = 10f;
    public CharacterController controller;
    public override void Spawned()
    {
        if(HasStateAuthority == false)
            return;

        green = Camera.main.transform;
    }
    public override void FixedUpdateNetwork()
    {
        if(HasStateAuthority == false)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = green.forward * verticalInput + green.right * horizontalInput;
        move.y = 0;

        Debug.DrawRay(green.position, move * 5, Color.green);

        if (move.magnitude > 0)
        {
            // Create a rotation that faces the move direction
            Quaternion targetRotation = Quaternion.LookRotation(move);
            // Rotate towards the target direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Runner.DeltaTime * rotationSpeed);
        }

        controller.Move(move * Runner.DeltaTime * moveSpeed);
    }
}