using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    private GameObject vehicle;
    private float zAxis;
    private int speed = 15;
    void Start()
    {
        vehicle = GameObject.FindWithTag("Player");
        vehicle.GetComponent<Transform>();
        
    }
    void Update()
    {
        zAxis=vehicle.transform.position.z;
       
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
        
        if(transform.position.z < zAxis - 30)
            Destroy(gameObject);
    }
}
