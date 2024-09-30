using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Connect;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float coolDown;
    private float firerate = 10;
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && coolDown <= 0)
        {
            GameObject instance = Instantiate(bullet, transform.position, quaternion.identity);
            instance.GetComponent<Bullet>().targetPos = other.transform.position;
            coolDown = firerate;
            firerate = Time.deltaTime;
        }
    }
}
