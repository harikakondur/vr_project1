using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraJump : MonoBehaviour
{
    public float jumpForce = 3.0f;
    public CharacterController charController;
    private float verticalVelocity = 0.0f;
    private float gravity = -9.81f;
    private float lastCameraYPosition;
    private bool shouldJump = false;

    void Start()
    {
        lastCameraYPosition = Camera.main.transform.position.y;
    }

    void Update()
    {
        float currentCameraYPosition = Camera.main.transform.position.y;

        // main camera y displacement
        if (Mathf.Abs(currentCameraYPosition - lastCameraYPosition) > 0.1f)
        {
            shouldJump = true;
        }

        // if grounded dont jump
        if (charController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        if (shouldJump){
            verticalVelocity = jumpForce;
            verticalVelocity += gravity * Time.deltaTime;
            Vector3 gravityMove = new Vector3(0, verticalVelocity, 0);
            charController.Move(gravityMove * Time.deltaTime);
            shouldJump = false;
        }

        lastCameraYPosition = currentCameraYPosition;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.CompareTag("nextSceneTile")) 
        {
            SceneManager.LoadScene("Scenes/buttonPressScene");
        }
    }
}