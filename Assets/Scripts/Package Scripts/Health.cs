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
}
