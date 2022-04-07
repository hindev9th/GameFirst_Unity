using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;
    public GameObject Smoke1,Smoke2;
    public float runSpeed = 30f;
    float horizontalMove = 0f, 
        VerticalMove =0f;


    private Player player;

    private void Awake(){
        player = GetComponent<Player>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!player._isDie){
            horizontalMove = joystick.Horizontal * runSpeed;
            VerticalMove = joystick.Vertical * runSpeed;

            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
                horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
                VerticalMove = Input.GetAxisRaw("Vertical")*runSpeed;
            }
        }
        animator.SetFloat("Speed", (Mathf.Abs(VerticalMove)) !=0 ? Mathf.Abs(VerticalMove) : Mathf.Abs(horizontalMove));

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, VerticalMove * Time.fixedDeltaTime);
    }
}
