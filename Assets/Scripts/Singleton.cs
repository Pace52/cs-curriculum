using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public int coins = 0;
    private int health = 10;
    public static Singleton St;
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI healthtext;

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

    public void ChangeHealth(int cht)
    {
        health += cht;
    }
}