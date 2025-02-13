using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CameraZoom cameraZoom;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private float speedMove;
    [SerializeField] private float forceJump;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float smoothChangeSpeed;
    [SerializeField] private Animator playerAnimator;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float addSpeedX;
    private float addSpeedY;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        CharacterSwitcher.OnSwitchCharacter += SetCharacterAnimator;
    }
    private void OnDisable()
    {
        CharacterSwitcher.OnSwitchCharacter -= SetCharacterAnimator;
    }
    private void SetCharacterAnimator(Animator anim)
    {
        playerAnimator = anim;
    }

    private void Update()
    {
        Move();

        CheckFps();

        if(moveJoystick.Horizontal != 0f || moveJoystick.Vertical != 0f)
        {
            playerAnimator.SetBool("isMoving", true);

            playerAnimator.SetFloat("VelocityX", moveJoystick.Horizontal);
            playerAnimator.SetFloat("VelocityY", moveJoystick.Vertical);

        }
        else
        {
            playerAnimator.SetBool("isMoving", false);

            playerAnimator.SetFloat("VelocityX", 0);
            playerAnimator.SetFloat("VelocityY", 0);
        }
    }

    private void CheckFps()
    {
        if(cameraZoom.isFpsView)
        {
            playerBody.gameObject.SetActive(false);
        }
        else
        {
            playerBody.gameObject.SetActive(true);
        }
    }

    private void Move()
    {
        Vector3 forwardDir = playerCamera.TransformDirection(Vector3.forward);
        Vector3 rightDir = playerCamera.TransformDirection(Vector3.right);
        
        float currentSpeedY = speedMove * moveJoystick.Vertical;     
        float currentSpeedX = speedMove * moveJoystick.Horizontal;

        if(moveJoystick.Vertical >= 0.9f)
        {
            addSpeedX = Mathf.Lerp(addSpeedX, 1.8f, Time.deltaTime * smoothChangeSpeed);
        }
        else
        {
            addSpeedX = Mathf.Lerp(addSpeedX, 1f, Time.deltaTime * smoothChangeSpeed);
        }

        if(moveJoystick.Horizontal >= 0.9f)
        {
            addSpeedY = Mathf.Lerp(addSpeedY, 1.8f, Time.deltaTime * smoothChangeSpeed);
        }
        else
        {
            addSpeedY = Mathf.Lerp(addSpeedY, 1f, Time.deltaTime * smoothChangeSpeed);
        }

        moveDirection = (forwardDir * currentSpeedY * addSpeedY) + (rightDir * currentSpeedX * addSpeedX);

        transform.Translate(new Vector3(moveDirection.x, 0, moveDirection.z) * Time.deltaTime);      

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            toRotation.x = 0f;
            toRotation.z = 0f;

            playerBody.rotation = Quaternion.RotateTowards(playerBody.rotation, toRotation, rotateSpeed * Time.deltaTime);
        } 
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerAnimator.SetTrigger("isJump");
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("isGrounded", true);
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("isGrounded", false);
            isGrounded = false;
        }
    }
}
