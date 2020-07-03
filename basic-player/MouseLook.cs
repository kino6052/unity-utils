using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Camera playerCamera;
    // Start is called before the first frame update
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerBody();
        UpdatePlayerCamera();
    }

    void UpdatePlayerBody() {
        if (playerBody == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void UpdatePlayerCamera() {
        if (playerCamera == null) return;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 20f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
