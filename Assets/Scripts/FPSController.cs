using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 4f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float footstepRate = 1.25f;
    public float stepCooldown = 0;
    public bool hasJumped;
    public bool prevSprint;

    private bool paused = false;
    public GameObject PauseMenu;
    public GameObject ControlsMenu;
    public GameObject EndGameMenu;
    private bool gameEnd = false;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        EndGameMenu.SetActive(false);

        Time.timeScale = 1;
        canMove = true;
        characterController.enabled = true;

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

        //bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (walkingSpeed) * Input.GetAxis("Horizontal") : 0;
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
            int stepNum = (int)Random.Range(0, 4);

            switch (stepNum)
            {
                case (0):
                    FindObjectOfType<AudioManager>().Play("Footstep1");
                    break;

                case (1):
                    FindObjectOfType<AudioManager>().Play("Footstep2");
                    break;

                case (2):
                    FindObjectOfType<AudioManager>().Play("Footstep3");
                    break;

                case (3):
                    FindObjectOfType<AudioManager>().Play("Footstep4");
                    break;
            }

            //if (stepNum == 0)
            //{
            //    FindObjectOfType<AudioManager>().Play("Footstep1");
            //}
            //else if (stepNum == 1)
            //{
            //    FindObjectOfType<AudioManager>().Play("Footstep2");
            //}

            //FindObjectOfType<AudioManager>().Play("Footstep1");

            stepCooldown = Time.time + footstepRate;
        }

        //sprint noise
        //if (isRunning)
        //{
        //    FindObjectOfType<AudioManager>().Play("Sprint");
        //}

        if (Input.GetButton("Cancel"))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                canMove = false;
                characterController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                paused = true;

                PauseMenuButton();
            }
            //else
            //{
            //    Time.timeScale = 1;
            //    canMove = true;
            //    characterController.enabled = true;
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false;
            //    paused = false;

            //    BackToGame();
            //}
        }

        if (transform.position.x <= -58 && transform.position.x >= -69 &&
            transform.position.z <= 39 && transform.position.z >=25
            && !gameEnd)
        {
            gameEnd = true;
            paused = true;
            Time.timeScale = 0;
            canMove = false;
            characterController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            EndGameScreen();
        }
    }

    public void EndGameScreen()
    {
        EndGameMenu.SetActive(true);
    }

    public void BackToGame()
    {
        Time.timeScale = 1;
        canMove = true;
        characterController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        paused = false;
        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(false);

    }

    public void PauseMenuButton()
    {
        PauseMenu.SetActive(true);
        ControlsMenu.SetActive(false);

    }

    public void ControlsMenuButton()
    {
        PauseMenu.SetActive(false);
        ControlsMenu.SetActive(true);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
