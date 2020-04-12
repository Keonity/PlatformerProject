using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 25f;
    public bool hasJumpPotion = false;
    public bool hasSpeedPotion = false;
    public int potionModAmount = 0;

    public AudioClip jumpClip;
    public AudioClip runClip;

    private float potionTimeMax = 10f;
    private float potionTimeCur = 0f;

    float horizontalMove = 0f;

    bool jumpFlag = false; // Determines if we are jumping or not.
    bool jump = false; // Determines whether or not to jump.

    // Update is called once per frame. This is where you pull information, check for things like collision, updating keyboard presses.
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // Input(Checks for input), GetAxisRaw(Checks for what input based on the parameter)

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (horizontalMove > 1 || horizontalMove < -1)
        {
            GetComponent<AudioSource>().UnPause();
        }
        if (horizontalMove == 0)
        {
            GetComponent<AudioSource>().Pause();
        }

        if (jumpFlag)
        {
            animator.SetBool("IsJumping", true);
            jumpFlag = false; // Turns off jumpFlag after you jump.
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (animator.GetBool("IsJumping") == false)
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
    }

    void FixedUpdate() // FixedUpdate is called at a regular interval. Regular Update is called as often as it can.
    {
        //controller.Move is built into Unity.
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //Time.fixedDeltaTime smooths movement. Takes into account framerate.
        
        if(hasJumpPotion && potionTimeCur < potionTimeMax)
        {
            controller.m_JumpForceMod = potionModAmount;
            potionTimeCur += Time.fixedDeltaTime;
        }
        else
        {
            potionTimeCur = 0f;
            controller.m_JumpForceMod = 0;
            hasJumpPotion = false;
        }

        if (jump)
        {
            jumpFlag = true;
        }
    }

    public void onLanding()
    {
        jump = false;
        animator.SetBool("IsJumping", false);
    }
}
