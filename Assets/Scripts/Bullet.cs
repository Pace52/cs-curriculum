using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5;
    public Vector3 targetPos;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPos - transform.position).normalized * (Time.deltaTime * speed));
        if (this.transform.position == targetPos)
        {
            Destroy(gameObject);
        }
    }
}
