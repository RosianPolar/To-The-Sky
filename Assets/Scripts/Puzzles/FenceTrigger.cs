using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    Boolean isOpen = false;
    public Boolean staysOpen;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)                                                 //if the door is not open
        {
            door.transform.Rotate(0, 90, 0, Space.Self);    //increase the Y position of the door by 4 units
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (isOpen && !staysOpen)                                  //if the door is open and is not meant to stay open after being pressed
        {
            door.transform.Rotate(0, 90, 0, Space.Self); //decrease the Y position of the door by 4 units
            isOpen = false;
        }
    }
}
