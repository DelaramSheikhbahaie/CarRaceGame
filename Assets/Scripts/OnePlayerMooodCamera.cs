using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayerMooodCamera : MonoBehaviour
{
    
    public GameObject player;
    
    private Vector3 firstPersonCam;
    private Vector3 secondPersonCam;
    private bool first = false;
    private bool second = true;

    private Vector3 firstPersonView = new Vector3(0, 3, 0);
    private Vector3 secondPersonView = new Vector3(-3, 32, 12);

    void LateUpdate()
    {
        firstPersonCam = player.transform.position + firstPersonView;
        secondPersonCam = player.transform.position + secondPersonView;
        
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            first = !first;
            second = !second;
                 
        }

        if (first)
        {
            transform.position = firstPersonCam;
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        if (second)
        {
            transform.position = secondPersonCam;
            transform.rotation = Quaternion.Euler(90,0,0);
            
        }
            
        
    }
}
