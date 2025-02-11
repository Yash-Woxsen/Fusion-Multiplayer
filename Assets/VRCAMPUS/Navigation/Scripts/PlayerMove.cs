using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Camera playerCamera;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (playerBody == null)
        {
            playerBody = transform;
        }
    }

    void Update()
    {
        MovePlayer();
        LookAround();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = playerCamera.transform.right * x + playerCamera.transform.forward * z;
        move.y = 0; // Keep the movement horizontal
        playerBody.Translate(move * speed * Time.deltaTime, Space.World);
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
