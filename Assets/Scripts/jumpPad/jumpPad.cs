using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 20.0f;
    public CharacterController charController;
    private float verticalVelocity = 0.0f;
    private float gravity = -9.81f;
    public AudioClip jumpSFX;


    private void Update()
    {
        if (charController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; 
        }

        verticalVelocity += gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalVelocity, 0);
        charController.Move(gravityMove * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("jumpPad"))
        {
            Debug.Log("on pad");
            verticalVelocity = jumpForce;
            GetComponent<AudioSource>().PlayOneShot(jumpSFX);
        }
    }
}