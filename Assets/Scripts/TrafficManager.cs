using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject live;
    public Transform vehicle;
    
    private int startDelay=5;
    private float delay=0.8f;
    private int randomIndex;
    private Vector3 randomCarPosition;
    private Vector3 randomCapsulePosition;
    private float zAxis;
    void Start()
    {
        InvokeRepeating("Traffic" ,startDelay,delay);
        InvokeRepeating("LiveCapsule" , 8 , 5);
    }
    
    void Update()
    {
        zAxis = vehicle.position.z;
    }

    void Traffic()
    {
        randomIndex = Random.Range(0, cars.Length);
        randomCarPosition= new Vector3(Random.Range(-25,5), 0 , zAxis+50);
        Vector3 rotation = new Vector3(0, 180, 0);
        if(zAxis+50<=650)
        Instantiate(cars[randomIndex], randomCarPosition, Quaternion.Euler(rotation));
    }

    void LiveCapsule()
    {
        randomCapsulePosition = new Vector3(Random.Range(-25,5), 1 , zAxis+50);
        if(zAxis+50<=650)
            Instantiate(live, randomCapsulePosition, Quaternion.identity);
    }
}
