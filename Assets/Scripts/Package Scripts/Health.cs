using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Singleton singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = FindObjectOfType<Singleton>();
    }
    
    private void OnCollisionEnter2D()
    // Update is called once per frame
    void Update()
    {
        
    }
}
