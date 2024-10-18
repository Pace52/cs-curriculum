using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<GameObject> points;
    public int pointer = 0;
    public GameObject player;
    public States state = States.Wander;
    public Singleton St;
    private float enemy_cooldown;
    public Vector3 mtpv;
    public string direction;
    public Animator mobileEnemy;
    
    public enum States
    {
        Wander,
        Chase,
        Attack,
        Die
    }
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        St = FindObjectOfType<Singleton>();
    }
    void Update()
    {
        if (Math.Abs(mtpv.x) > Math.Abs(mtpv.y))
        {
            if (mtpv.x > 0)
            {
                direction = "Right";
            }

            if (mtpv.x < 0)
            {
                direction = "Left";
            }
        }
        if (Math.Abs(mtpv.y) > Math.Abs(mtpv.x))
        {
            if (mtpv.y > 0)
            {
                direction = "Up";
            }

            if (mtpv.y < 0)
            {
                direction = "Down";
            }
        }
        if (state == States.Wander)
        {
            mobileEnemy.Play("Walk" + direction);
            Debug.Log("Wandering");
            if (Vector3.Distance(transform.position, points[pointer].transform.position) <= .015)
            {
                pointer++;
                pointer %= points.Count;
            }
            transform.position = Vector3.MoveTowards(transform.position, points[pointer].transform.position, 1 * Time.deltaTime);
        }

        if (state == States.Chase)
        {
            mobileEnemy.Play("Walk" + direction);
            mtpv = (player.transform.position - transform.position);
            Debug.Log("Chasing");
            transform.position = Vector3.MoveTowards(current: transform.position, target: player.transform.position,
                maxDistanceDelta: 1f * Time.deltaTime);
            if (Vector3.Distance(a: transform.position, b: player.transform.position) < 1.3f)
            {
                state = States.Attack;
            }
        }

        if (state == States.Attack)
        {
            mobileEnemy.Play("Attack" + direction);
            Debug.Log("Attacking");
            enemy_cooldown -= Time.deltaTime;
            if (player && enemy_cooldown < 0)
            {
                St.ChangeHealth(cht:-1);
                enemy_cooldown = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            state = States.Chase;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state = States.Wander;
        }
    }
}
