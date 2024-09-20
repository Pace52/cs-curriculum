using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public int coins = 0;
    public static Singleton St;

    void Awake()
    {
        if (St != null && St != this)
        {
            Destroy(gameObject);
        }
        else
        {
            St = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}