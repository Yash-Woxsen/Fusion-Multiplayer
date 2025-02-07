using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;

    void Start()
    {
        // Lock the cursor at the start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Toggle cursor lock state with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        // Handle movement
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            moveY = -moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveY = moveSpeed * Time.deltaTime;
        }

        transform.Translate(moveX, moveY, moveZ);

        // Handle mouse look only if cursor is locked
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
            transform.Rotate(-mouseY, mouseX, 0);

            // Clamp rotation to avoid flipping
            Vector3 clampedRotation = transform.eulerAngles;
            clampedRotation.z = 0;
            transform.eulerAngles = clampedRotation;
        }
    }
}