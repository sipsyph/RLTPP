using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text refDirectoryText, forwardText, backwardText, leftText, rightText;
    CharacterController characterController;
    private Animator animator;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;

    private float rotationSpeed = 3.0f;
    public float gravity = 20.0f;

    public Transform playerCharacter;

    private Vector3 moveDirection = Vector3.zero;

    private Vector3 origPosition;

    public static bool shouldResetPosition;

    private bool forward, backward, left, right;

    void Start()
    {
        refDirectoryText.text = "Ref. Directory: "+Application.dataPath+"/mvmntTxt.txt";
        origPosition = transform.position;
        animator = playerCharacter.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        DeriveMovementFromTextFile("mvmntTxt.txt");
        MovementAnimations();
        if(shouldResetPosition)
        {
            transform.position = origPosition;
            shouldResetPosition = false;
        }
    }

    void DeriveMovementFromTextFile(string fileName)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);

        StreamReader SR = new StreamReader(filePath);
        if(SR.ReadLine().Equals("t"))
        {
            forward = true;
            forwardText.text = "Forward: TRUE";
            moveDirection = Vector3.forward;
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }else{
            forward = false;
            forwardText.text = "Forward: FALSE";
        }

        if(SR.ReadLine().Equals("t"))
        {
            backward = true;
            backwardText.text = "Backward: TRUE";
            moveDirection = Vector3.back;
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }else{
            backward = false;
            backwardText.text = "Backward: FALSE";
        }

        if(SR.ReadLine().Equals("t"))
        {
            left = true;
            leftText.text = "Left: TRUE";
            moveDirection = Vector3.left;
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }else{
            left = false;
            leftText.text = "Left: FALSE";
        }

        if(SR.ReadLine().Equals("t"))
        {
            right = true;
            rightText.text = "Right: TRUE";
            moveDirection = Vector3.right;
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }else{
            right = false;
            rightText.text = "Right: FALSE";
        }

        if(!forward && !backward && !left && !right)
        {
            moveDirection = Vector3.zero;
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void WasdMovement()
    {
        if (characterController.isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }


        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void MovementAnimations()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W");
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A");
            //transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime) );
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S");
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D");
            //transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime) );
            animator.SetTrigger("Walking1Trigger");
            animator.ResetTrigger("IdleTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
            animator.ResetTrigger("Walking1Trigger");
        }
    }
}
