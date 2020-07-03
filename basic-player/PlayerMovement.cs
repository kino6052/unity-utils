using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float sensitivity = 10f;
    public float gravity = -9.81f;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInputs();
        ApplyGravity();
        CheckForJump();
    }

    void CheckForInputs() {
        if (controller == null) return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * sensitivity * Time.deltaTime);
    }

    void ApplyGravity() {
        if (controller == null) return;
        float prevY = controller.transform.position.y;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime * 5f);
        float curY = controller.transform.position.y;
        if (prevY == curY) velocity.y = 0;
    }

    void CheckForJump() {
        if (controller == null) return;
        if (Input.GetButtonDown("Jump") && velocity.y > -2f && velocity.y <= 0f) {
            velocity.y = 2f;
        }
    }
}
