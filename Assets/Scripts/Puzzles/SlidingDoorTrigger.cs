using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    Boolean isOpen = false;
    
    
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            door.transform.localPosition += new Vector3(4, 0 , 0);    //increase the Y position of the door by 4 units
            isOpen = true; 
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if(isOpen)
        {
            door.transform.localPosition -= new Vector3(4, 0, 0);   //decrease the Y position of the door by 4 units
            isOpen=false;
        }
    }
}
