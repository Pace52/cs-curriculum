using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public List<GameObject> points;
    public int pointer = 0;
    public GameObject player;
    public States state = States.Wander;

    public enum States
    {
        Wander,
        Chase,
        Attack
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        if (state == States.Wander)
        {
            Debug.Log("Wandering");
            if (Vector3.Distance(a: transform.position, b: points[pointer].transform.position) < 0.01f)
            {
                pointer++;
                pointer %= points.Count;
            }
            transform.position = Vector3.MoveTowards(current: transform.position, target: points[pointer].transform.position,
                maxDistanceDelta: 1 * Time.deltaTime);
        }

        if (state == States.Chase)
        {
            Debug.Log("Chasing");
            transform.position = Vector3.MoveTowards(current: transform.position, target: player.transform.position,
                maxDistanceDelta: 1f * Time.deltaTime);
            if (Vector3.Distance(a: transform.position, b: points[pointer].transform.position) < 1f)
            {
                state = States.Attack;
            }
        }

        if (state == States.Attack)
        {
            Debug.Log("Attacking");
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
