// using System;
// using UnityEngine.InputSystem;
// using UnityEngine;

// public class Jump : MonoBehaviour
// {
//     [SerializeField] private InputActionReference jumpButton;
//     [SerializeField] private float jumpHeight = 4.0f;
//     [SerializeField] private float gravityValue = -9.81f;

//     private CharacterController _characterController;
//     private Vector3 _playerVelocity;

//     private void Awake() => _characterController = GetComponent<CharacterController>();

//     private void OnEnable() => jumpButton.action.performed += Jumping; 
//     private void OnDisable() => jumpButton.action.performed -= Jumping;


//     private void Jumping(InputAction.CallbackContext obj){

//         if(!_characterController.isGrounded) return;

//         _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f *  gravityValue);
//     }

//     private void Updtae(){
//         // checking if player is grounded
//         if(_playerVelocity.y < 0 && _characterController.isGrounded){  
//             _playerVelocity.y = 0;
//         }

//         // movement
//         _playerVelocity.y += gravityValue * Time.deltaTime;
//         _characterController.Move(_playerVelocity * Time.deltaTime);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class advancedMovement : MonoBehaviour
{
    
    public InputActionReference jumpButton = null;
    public CharacterController charController;
    public float jumpHeight;
    private float gravityValue = -9.81f;

    private Vector3 playerVelocity;

    public bool jumpButtonReleased;

    private bool isTouchingGround;
    // Start is called before the first frame update
    void Start()
    {
        jumpButtonReleased = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);
        if (charController.isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
            isTouchingGround = true;
        }

        float jumpVal = jumpButton.action.ReadValue<float>();
        if (jumpVal > 0 && jumpButtonReleased == true) {
            jumpButtonReleased = false;
            Jump();
            isTouchingGround = false;
        } else if (jumpVal == 0){
            jumpButtonReleased = true;
        }
    }

    public void Jump() {
        if (isTouchingGround == false) {
            return;
        }
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }
}
