using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public List<GameObject> points;
    public int pointer = 0;
    public GameObject player;
    public States state;

    public enum States
    {
        Wander,
        Chase
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(a:transform.position, b:points[pointer].transform.position < 0.01f)
        {
            pointer++;
            pointer %= points.Count;
        }
    }
}
