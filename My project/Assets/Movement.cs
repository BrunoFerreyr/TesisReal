using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;//rango para detectar suelo
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight;

    #region new movement

    Camera actualCamera = null;
    float moveSpeed = 2f;
    float rotationSpeed = 200f;

    float rotationInput = 0;
    float movementInput = 0;

    Vector3 cameraForward = Vector3.zero;
    Vector3 cameraRight = Vector3.zero;

    Vector3 moveDirection = Vector3.zero;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualCamera = Camera.main;
        if(actualCamera == null)
        {
            Debug.LogError("No active camera found in the Scene!");
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        rotationInput = Input.GetAxis("Horizontal");
        movementInput = Input.GetAxis("Vertical");

        /*transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);*/

        cameraForward = actualCamera.transform.forward;
        cameraRight = actualCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 move = cameraForward * movementInput + cameraRight * rotationInput;
        //suma el movimiento hacia costados + el forward, osea hacia delante.
        controller.Move(move * speed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            // Calculate the rotation to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(move);
            // Smoothly rotate the character towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        /* moveDirection = cameraForward * movementInput + cameraRight * rotationInput;

         transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
         Debug.Log(SpeechRecognizer.doingAction);
         if (move != Vector3.zero)
         {
             // Calculate the rotation to face the movement direction
             Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
             // Smoothly rotate the character towards the target rotation
             transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
         }

         /*
         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
         if(isGrounded && velocity.y < 0)
         {
             velocity.y = -2f;
         }
         float x = Input.GetAxis("Horizontal");
         float z = Input.GetAxis("Vertical");

         Vector3 move = transform.right * x + transform.forward * z;
         //suma el movimiento hacia costados + el forward, osea hacia delante.
         controller.Move(move * speed * Time.deltaTime);

         if(Input.GetButtonDown("Jump") && isGrounded)
         {
             velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
         }
         velocity.y += gravity * Time.deltaTime;
         controller.Move(velocity * Time.deltaTime);
         */
    }   
}
