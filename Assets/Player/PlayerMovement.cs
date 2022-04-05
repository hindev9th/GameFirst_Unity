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



    void Start(){
        Smoke1.SetActive(false);
        Smoke2.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        
        
        
        horizontalMove = joystick.Horizontal * runSpeed;
        VerticalMove = joystick.Vertical * runSpeed;

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
            horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
            VerticalMove = Input.GetAxisRaw("Vertical")*runSpeed;
        }
            

        animator.SetFloat("Speed", (Mathf.Abs(VerticalMove)));
        
        if (Input.GetAxis("Horizontal") != 0 )
            animator.SetFloat("Speed", (Mathf.Abs(horizontalMove)));
         

        if(animator.GetFloat("Speed") >0){
            Smoke1.SetActive(true);
            Smoke2.SetActive(true);
        }else{
            Smoke1.SetActive(false);
            Smoke2.SetActive(false);
        }
        
        
        


    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, VerticalMove * Time.fixedDeltaTime);
    }
}
