using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float footstepRate = 1.5f;
    public float stepCooldown = 0;
    public bool hasJumped;
    public bool prevSprint;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;

            //Jump sound
            FindObjectOfType<AudioManager>().Play("Jump");
            hasJumped = true;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        //Checks if player has landed and plays the sound
        if (characterController.isGrounded && hasJumped)
        {
            FindObjectOfType<AudioManager>().Play("Land");
            hasJumped = false;
        }
        
        //Footstep sounds
        if (Time.time > stepCooldown && (moveDirection.x != 0 || moveDirection.z != 0))
        {
            //Random footstep sound out of 4
            //switch((int)Random.Range(0, 4))
            //{
            //    case (0):
            //        FindObjectOfType<AudioManager>().Play("Footstep1");
            //        return;

            //    case (1):
            //        FindObjectOfType<AudioManager>().Play("Footstep2");
            //        return;

            //    case (2):
            //        FindObjectOfType<AudioManager>().Play("Footstep3");
            //        return;

            //    case (3):
            //        FindObjectOfType<AudioManager>().Play("Footstep4");
            //        return;
            //}

            FindObjectOfType<AudioManager>().Play("Footstep1");

            stepCooldown = Time.time + footstepRate;
        }

        //sprint noise
        //if (isRunning)
        //{
        //    FindObjectOfType<AudioManager>().Play("Sprint");
        //}
    }
}
