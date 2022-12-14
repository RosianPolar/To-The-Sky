using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShieldScript : MonoBehaviour
{
    public GameObject playerShield;
    public static bool ShieldIsOff = true;
    
    void Start(){
        playerShield.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
    // activate and deactivate shield with the "1" key
     if (Input.GetKeyDown(KeyCode.Alpha1))
     {
        if (ShieldIsOff)
        {
            ShieldOn();
        }
        else {
            ShieldOff();
        }
     }   
    }
    // turn shield on
    public void ShieldOn(){
        playerShield.SetActive(true);
        ShieldIsOff = false;
    }
    // turn shield off
    public void ShieldOff(){
        playerShield.SetActive(false);
        ShieldIsOff = true;
    }
}
