using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    Boolean isPressed = false;
    float velocity;
    [SerializeField]
    GameObject bouncyBall;
    [SerializeField]
    Transform spawner;
    //spawns a ball in the downward facing direction 
    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
        {
            GameObject ball = Instantiate(bouncyBall, spawner.position, spawner.rotation);
            ball.GetComponent<Rigidbody>().AddForce(spawner.forward * velocity);
            isPressed = true;
        }
    }

    //destroys balls and resets the boolean
    private void OnTriggerExit(Collider other)
    {
        if(isPressed)
        {
            Destroy(bouncyBall);
            isPressed = false;
        }
    }


}
