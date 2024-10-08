using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Connect;
using UnityEditor.Search;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float coolDown;
    private float firerate = 1;
    public GameObject bullet;
    private GameObject player;
    


    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if (player && coolDown < 0)
        {
            Shoot();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }
    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, quaternion.identity);
        bulletInstance.GetComponent<Bullet>().targetPos = player.transform.position;
        coolDown = firerate;
    }
}
