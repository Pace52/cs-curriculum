using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool overworld;
    public bool platformer;
    // Movement variables
    public float xSpeed = 5f;
    private float xVector = 0f;
    public float ySpeed = 5f;
    private float yVector = 0f;
    private Rigidbody2D rb;
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (platformer)
        {
            ySpeed = 0;
        }
        
       // Handle input
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");
       // Calculate xVector based on input
       xVector = xSpeed * horizontalInput * Time.deltaTime;
       yVector = ySpeed * verticalInput * Time.deltaTime;
       transform.Translate(xVector, yVector, 0);
    }
    int coin
    OnTrigger2D(Collider other)
    {
        if(other tagged "coin")
            {
            print("I have" + coin + "coins");
}