﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charContr;

    private float xDir;
    private float zDir;
    private float yDir;

    private Vector3 moveDirection;

    public float speed = 10f;
    private bool isGrounded;
    public Transform grandCheck;
    public LayerMask groundLayer;
    public float groundDist = 0.2f;
    public float jump = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(grandCheck.position, groundDist, groundLayer);

        if(isGrounded && yDir <0)
        {
            yDir = -2f;
        }

        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        yDir += Physics.gravity.y*Time.deltaTime;

        moveDirection = transform.right * xDir * speed + transform.forward * zDir * speed + transform.up * yDir;

        charContr.Move(moveDirection * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            yDir = Mathf.Sqrt(jump * -2f * Physics.gravity.y);
        }


    }
}
