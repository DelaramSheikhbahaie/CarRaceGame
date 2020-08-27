using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public String switchCamera;
    public GameObject player;
    
    private Vector3 firstPersonCam;
    private Vector3 secondPersonCam;
    private bool first = true;
    private bool second = false;

    private Vector3 firstPersonView = new Vector3(0, 5, -11);
    private Vector3 secondPersonView = new Vector3(0, 3, 0);
    
    void Start()
    {
        
    }
    
    void LateUpdate()
    {
        firstPersonCam = player.transform.position + firstPersonView;
        secondPersonCam = player.transform.position + secondPersonView;
        
        if (Input.GetButtonDown(switchCamera))
             {
                 first = !first;
                 second = !second;
                 
             }
        if(first)
            transform.position = firstPersonCam;
        if (second)
            transform.position = secondPersonCam;
        
    }
}

