using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

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
    public Singleton St;
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        St = FindObjectOfType<Singleton>();
        Debug.Log(St);
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
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            St.coins = St.coins + 1;
            print("I have" + St.coins + "coins");
            Destroy(collision.gameObject);
        }
    }
}