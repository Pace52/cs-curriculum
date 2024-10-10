using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public static Singleton St;

    public int maxhealth = 10;
    public int coins = 0;
    public int health = 10;
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI healthtext;
    public string coinstring;
    public string healthstring;

    public void Start()
    {
        
    }

    void Update()
    {
        cointext.text = coinstring;
        coinstring = "Coins: " + coins;
        healthtext.text = healthstring;
        healthstring = "Health: " + health;
    }

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
        print(health);
        if (health == 0)
        {
            print("You died");
        }
        if (health > maxhealth)
        {
            health = maxhealth;
        }
        if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health = 10;
            coins = 0;
        }
    }
}