using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Singleton St;
    // Start is called before the first frame update
    private void Start()
    {
        St = FindObjectOfType<Singleton>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            St.ChangeHealth(-1);
        }

        if (other.gameObject.CompareTag("Fireball"))
        {
            St.ChangeHealth(cht:-1);
        }
    }
}
