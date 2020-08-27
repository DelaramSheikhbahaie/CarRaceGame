using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
     private Vector3 startPos;
     private float repeatLength;
       
        void Start()
        {
            startPos = transform.position;
            repeatLength = GetComponent<BoxCollider>().size.z / 2;
        }
    
        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < startPos.x - repeatLength)
            {
                transform.position = startPos;
            }
        }
}
