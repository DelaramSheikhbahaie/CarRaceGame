using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StartMenue : MonoBehaviour
{
    public GameObject[] cars;
    public Transform camera;
    public AudioSource backSound;
    
    private float startDelay=0.5f;
    private float delay=0.8f;
    private int randomIndex;
    private Vector3 randomCarPosition;
    private float zAxis;

    private void Awake()
    {
        backSound.Play();
    }

    void Start()
    {
        
        InvokeRepeating("Traffic" ,startDelay,delay);
    }
    
    void Update()
    {
        zAxis = camera.position.z;
    }

    void Traffic()
    {
        randomIndex = Random.Range(0, cars.Length);
        randomCarPosition= new Vector3(Random.Range(-25,5), 0 , zAxis+50);
        Vector3 rotation = new Vector3(0, 180, 0);
        if(zAxis+50<=650)
            Instantiate(cars[randomIndex], randomCarPosition, Quaternion.Euler(rotation));
    }
    
}
