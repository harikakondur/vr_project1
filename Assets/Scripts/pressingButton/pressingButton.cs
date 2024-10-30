using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class pressingButton : MonoBehaviour
{
    public InputActionReference rightTrigger;
    public float jumpForce = 10.0f;
    public CharacterController charController;
    private float verticalVelocity = 0.0f;
    private float gravity = -9.81f;
    public AudioClip jumpSFX;


    void Start()
    {
        rightTrigger.action.performed += Jump;
    }

    void Update()
    {
        if (charController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalVelocity, 0);
        charController.Move(gravityMove * Time.deltaTime);
    }

    private void Jump(InputAction.CallbackContext __)
    {
        if (charController.isGrounded)
        {
            verticalVelocity = jumpForce;
            GetComponent<AudioSource>().PlayOneShot(jumpSFX);

        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("nextSceneTile")) 
        {
            SceneManager.LoadScene("Scenes/jumpPad");
        }
    }
}
