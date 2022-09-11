using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
   

    private Vector3 moveDirection;
    private Vector3 velocity;

    public bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    private float gravity = -9.81f;

    [SerializeField] private float jumpHeight;

    
    private CharacterController controller;
    private Animator animator;

    public float OrbsDestroyed = 0;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponentInChildren<Animator>();


    }

    private void Update()
    {
        Move();
        DestroyOrb();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        // checks if player is grounded, and if character isn't grounded apply gravity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

        }

        controller.Move(moveDirection * Time.deltaTime);

        // calculate gravity
        velocity.y += gravity * Time.deltaTime;

        // apply gravity to the player
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        //animator.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        //animator.SetFloat("Speed", 0.5f);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        //animator.SetFloat("Speed", 1);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    public GameObject orb;

    public bool canDestroy;

    void DestroyOrb()
    {
        if (canDestroy && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(orb);
            OrbsDestroyed ++;
        }
    }

}
