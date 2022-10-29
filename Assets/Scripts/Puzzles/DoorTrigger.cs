using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    Boolean isOpen = false;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            door.transform.position += new Vector3(0, 4, 0);    //increase the Y position of the door by 4 units
            isOpen = true; 
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if(isOpen)
        {
            door.transform.position -= new Vector3(0, 4, 0);
            isOpen=false;
        }
    }
}
