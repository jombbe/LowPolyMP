using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementV2 : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    public float stantardMoveSpeed = 2.0f;
    public float runSpeed;

    [SerializeField]
    float StandtardRunSpeed = 4.0f;

    [SerializeField]
    public float Gravity = -9.81f;
    [SerializeField]
    public float jumpHeight = 3.0f;

    public CharacterController characterController;
    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    PlayerAnimController playeranimController;


    Vector3 velocity;
    public bool isAiming;
    public bool isRunning;
    public bool isGrounded;

    [SerializeField] private bool isWalking;


    public void Start()
    {
        playeranimController = FindObjectOfType<PlayerAnimController>();
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * moveSpeed * Time.deltaTime);
        isWalking = true;


        if (Input.GetKey(KeyCode.LeftShift) && !isAiming)
        {
            moveSpeed = StandtardRunSpeed;
            isRunning = true;


        }
        else
        {
            moveSpeed = stantardMoveSpeed;
            isRunning = false;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);
        }

        velocity.y += Gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = 0.8f;
        }
        else
        {
            characterController.height = 1.32f;
        }
    }
}

